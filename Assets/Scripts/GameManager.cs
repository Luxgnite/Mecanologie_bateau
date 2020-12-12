using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestionnaire de la logique du jeu. Il est le garant de la cohérence du coeur de la logique,
/// accessible depuis n'importe quelle scène (Singleton).
/// </summary>
public class GameManager : MonoBehaviour
{
    //Référence à l'instance Singleton actuelle
    public static GameManager _instance;

    //Événement lors d'un changement de lieu
    public delegate void LieuAction(string nouveauLieu, string ancienLieu);
    public static event LieuAction OnChangementLieu;

    //Animator de l'objet utilisé pour faire des fade in/out 
    public Animator fadeAnimator;

    //Lieu dans lequel le joueur se situe
    public string lieuJoueur;
    /// <summary>
    /// Getter - Setter pour définir le lieu du joueur
    /// </summary>
    public string LieuJoueur
    {
        get
        {
            return lieuJoueur;
        }
        set
        {
            if(value != null)
            {
                //Stock l'ancien lieu dans une variable temporaire
                string temp = lieuJoueur;
                //Attribution de la nouvelle valeur du lieu du joueur
                lieuJoueur = value;
                //Envoi de l'événement pour signaler un changement de lieu
                OnChangementLieu(lieuJoueur, temp);
                AfficherAction(lieuJoueur);
            }    
        }
    }
    
    private void Awake()
    {
        //Mise en place du pattern Singleton
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Lorsqu'une scène est chargée
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadeAnimator = GameObject.Find("Fade").GetComponent<Animator>();
    }

    //Afficher l'action à effectué sur le lieu sélectionné
    void AfficherAction(string nomTache)
    {
        ChargerScene("Scenes/ScenesTest/Taches/" + nomTache);
    }

    /// <summary>
    /// Afficher la scène de la carte du bateau
    /// </summary>
    public void AfficherCarteBateau()
    {
        ChargerScene("Scenes/ScenesTest/Deplacement_personnage");
    }
    
    /// <summary>
    /// Charge la scène correspondant au chemin
    /// </summary>
    /// <param name="chemin">Chemin vers la scène à charger. Ex : "Scenes/Scene1" </param>
    /// <param name="delaiLatence">Temps en seconde de la latence. Si non spécifié, il est égal à 1f </param>
    public void ChargerScene(string chemin, float delaiLatence = 1f)
    {
        StartCoroutine(ChargerSceneDelai(chemin, delaiLatence));
    }

    //Coroutine pour effectuer charger une scène avec du délai
    IEnumerator ChargerSceneDelai(string chemin, float delaiLatence)
    {
        //Si le résultat est négatif, alors le yield se fait immédiatement
        yield return new WaitForSeconds(delaiLatence-1);
        fadeAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(chemin);
    }
}
