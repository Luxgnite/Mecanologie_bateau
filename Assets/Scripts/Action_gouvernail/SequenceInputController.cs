using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/* Script se chargeant d'identifier les mouvements de stick pour agir en conséquence.
 * Principalement basé sur les scripts suivants : 
 * https://answers.unity.com/questions/1614808/arcade-stick-input-commands-implementation.html
 * https://www.youtube.com/watch?v=JV-PjU4q2EE
 */

/// <summary>
/// Permet de nommer les différentes régions identifiées sur le Joystick
/// </summary>
public enum StickRegion
{
    CENTRE,
    HAUT,
    HAUTGAUCHE,
    HAUTDROITE,
    BAS,
    BASGAUCHE,
    BASDROITE,
    DROITE,
    GAUCHE,
}

/// <summary>
/// Classe en charge de vérifier les contrôles entrés par l'utilisateur et identifier
/// la séquence correspondante, puis déclencher l'action liées
/// </summary>
public class SequenceInputController : MonoBehaviour
{
    [Header("Ensemble des séquences vérifiées par le jeu")]
    public List<Sequence> sequences = new List<Sequence>();
    [Header("Marge de temps laissée pour que la séquence soit considérée valide")]
    public float margeTempsSequence = 0.3f;

    PlayerControls controls;
    //StickRegion enregistrée à la dernière Update
    private StickRegion regionActuelle;
    //StickRegion enregistrée à cette Update
    private StickRegion regionPrecedente;
    //Les séquences vérifiées actuellement par le jeu, les non-conformes ayant été éliminées du processus
    private List<Sequence> sequencesActuelles = new List<Sequence>();
    //Minuteur pour la marge de temps accordées aux séquences
    private float margeTemps;
    //Stock les valeurs du sticks Gauche;
    private Vector2 stickPos;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gouvernail.RotateBarre.performed += ctx => stickPos = ctx.ReadValue<Vector2>();
        controls.Gouvernail.RotateBarre.canceled += ctx => stickPos = Vector2.zero;
        controls.Gouvernail.Message.performed += ctx => OnMessage();
    }

    private void Start()
    {
        EcouterSequences();
    }

    void OnMessage()
    {
        Debug.Log("Key pressed!");
    }

    void OnEnable()
    {
        controls.Gouvernail.Enable();
    }

    void OnDisable()
    {
        controls.Gouvernail.Disable();
    }

    /// <summary>
    /// On écoute les événements envoyées par les séquences pour réinitialiser la surveillance
    /// si l'une d'entre elle est validée.
    /// </summary>
    private void EcouterSequences()
    {
        foreach(Sequence sequence in sequences)
        {
            sequence.onComplet.AddListener(() =>
            {
                ReinitialiserSequences();
            });
        }
    }

    private void Update()
    {
        //Debug.Log(stickPos);

        regionActuelle = ObtenirStickRegion(stickPos);
        Debug.Log(regionActuelle);
        //Si jamais la position actuelle est différente de la précédente, on enclenche la vérification des séquences
        if (regionActuelle != regionPrecedente)
        {
            regionPrecedente = regionActuelle;
            VerifierSequence(regionActuelle);
            //On initialise la marge de temps
            margeTemps = 0;
        }

        //Si jamais on surveille des séquences, alors on commence à chronométre la marge de temps laissée
        if(sequencesActuelles.Count > 0)
        {
            margeTemps += Time.deltaTime;
            //Si la marge est dépassée, on réinitialise la surveille et le chronométrage
            if (margeTemps >= margeTempsSequence)
            {
                ReinitialiserSequences();
                margeTemps = 0;
            }
        }
    }

    /// <summary>
    /// En fonction des coordonnées du stick, détermine une région du stick et la retourne sous format StickRegion
    /// </summary>
    /// <param name="stickPos">Vector2 représentant la position du stick.
    /// X est l'axe horizontal, et Y l'axe vertical.</param>
    /// <returns>Retourne un StickRegion représente la région du stick dans laquelle se situe ce dernier</returns>
    private StickRegion ObtenirStickRegion(Vector2 stickPos)
    {
        if (Mathf.Abs(stickPos.x) < 0.3f && Mathf.Abs(stickPos.y) < 0.3f)
            return StickRegion.CENTRE;

        if (Mathf.Abs(stickPos.x) < 0.3f)
        {
            if (stickPos.y > 0.3f)
                return StickRegion.HAUT;
            if (stickPos.y < -0.3f)
                return StickRegion.BAS;
        }

        if (stickPos.x > 0.3f)
        {
            if (Mathf.Abs(stickPos.y) < 0.3f)
                return StickRegion.DROITE;

            if (stickPos.y > 0.3f)
                return StickRegion.HAUTDROITE;
            if (stickPos.y < -0.3f)
                return StickRegion.BASDROITE;
        }

        if (stickPos.x < -0.3f)
        {
            if (Mathf.Abs(stickPos.y) < 0.3f)
                return StickRegion.GAUCHE;

            if (stickPos.y > 0.3f)
                return StickRegion.HAUTGAUCHE;
            if (stickPos.y < -0.3f)
                return StickRegion.BASGAUCHE;
        }

        return StickRegion.CENTRE;
    }

    /// <summary>
    /// Vérifie pour les séquences actuellement surveillées si l'entrée en argument est l'entrée attendue.
    /// Si aucune séquence n'est surveillée actuellement, alors on commence à surveiller 
    /// toutes les séquences, et on éliminent ceux qui ne correspondent pas.
    /// </summary>
    /// <param name="regionStick">La position du stick qui doit être comparée avec celle attendues
    /// par les séquences surveillées</param>
    private void VerifierSequence(StickRegion regionStick)
    {
        if (sequencesActuelles.Count == 0)
        {
            sequencesActuelles = new List<Sequence>(sequences);
        }

        for (int i = 0; i < sequencesActuelles.Count; i++)
        {
            if(!sequencesActuelles[i].ContinuerSequence(regionStick))
            {
                sequencesActuelles.RemoveAt(i);
                i--;
            }
        }
    }

    /// <summary>
    /// Réinitialise toutes la progression dans les séquences, 
    /// et nettoie les séquences actuellement surveillées.
    /// </summary>
    public void ReinitialiserSequences()
    {
        foreach (Sequence sequence in sequences)
        {
            sequence.ReinitialiserSequence();
        }
        sequencesActuelles.Clear();
    }
}

/// <summary>
/// Sert à établir une séquence à effectuer pour déclencher une action spécifique.
/// </summary>
[System.Serializable]
public class Sequence
{
    [Header("Ensemble des positions du stick attendues pour déclencher la séquence, dans l'ordre d'apparition.")]
    public List<StickRegion> sequence;
    private int indexActuel;
    [Header("La fonction à appelé lorsque la séquence est validée")]
    public UnityEvent onComplet;

    /// <summary>
    /// Vérifie si l'actuelle position du stick correspond à la séquence, 
    /// et si la séquence est terminé, on appelle la fonction liée à la séquence.
    /// Autrement, on réinitialise la séquence dans le cas où l'entrée en argument ne correspond
    /// pas à la prochaine entrée de la séquence.
    /// </summary>
    /// <param name="stickRegion">Position du stick qui doit être comparée avec celle
    /// attendue avec la séquence.</param>
    /// <returns>Vrai dans le cas où la séquence est continuée,
    /// Faux si l'entrée en argument n'est pas celle attendue et la séquence, réinitialisée.</returns>
    public bool ContinuerSequence(StickRegion stickRegion)
    {
        if(sequence[indexActuel] == stickRegion)
        {
            indexActuel++;
            if(indexActuel >= sequence.Count)
            {
                onComplet.Invoke();
                ReinitialiserSequence();
            }
            return true;
        }
        else
        {
            ReinitialiserSequence();
            return false;
        }
    }

    /// <summary>
    /// Retourne la position du stick de la séquence qui doit être comparée actuellement
    /// </summary>
    /// <returns>Position du stick de la séquence qui doit être comparée actuellement</returns>
    public StickRegion ActuelleEntreeSequence()
    {
        if (indexActuel >= sequence.Count)
            indexActuel = 0;
        return sequence[indexActuel];
    }

    /// <summary>
    /// Réinitialise l'index d'entrée de la séquence vérifiée
    /// </summary>
    public void ReinitialiserSequence()
    {
        indexActuel = 0;
    }
}