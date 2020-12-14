using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/// <summary>
/// Gestionnaire de la logique du jeu. Il est le garant de la cohérence du coeur de la logique,
/// accessible depuis n'importe quelle scène (Singleton).
/// </summary>
public class GameManager : MonoBehaviour
{
    //Référence à l'instance Singleton actuelle
    public static GameManager _instance;
    private GouvernailManager gouvernailManager;
    public GouvernailManager GouvernailManager { get { return _instance.gouvernailManager; } }

    //Événement lors d'un changement de lieu
    public delegate void LieuAction(string nouveauLieu, string ancienLieu);
    public static event LieuAction OnChangementLieu;

    [Header("Animator de l'objet utilisé pour faire des fade in/out")] 
    public Animator fadeAnimator;
    [Header("Lieu dans lequel le joueur se situe")]
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

    private void Start()
    {
        gouvernailManager = GetComponentInChildren<GouvernailManager>();
    }

    /// <summary>
    /// Cherche l'élément Fade lors du chargement d'une scène
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadeAnimator = GameObject.Find("Fade").GetComponent<Animator>();
    }

    /// <summary>
    /// Afficher l'action à effectué sur le lieu sélectionné
    /// </summary>
    /// <param name="nomAction">Le nom de l'action à effectuer.
    /// Doit corresponde à un nom de scène, qui nécessite d'être placée dans 'ScenesTest\Taches'</param>
    void AfficherAction(string nomAction)
    {
        ChargerScene("Scenes/ScenesTest/Taches/" + nomAction);
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

    /// <summary>
    /// Pour charger une scène avec du délai
    /// </summary>
    /// <param name="chemin">Chemin vers la scène</param>
    /// <param name="delaiLatence">Temps de latence avant le chargement de la scène</param>
    /// <returns></returns>
    IEnumerator ChargerSceneDelai(string chemin, float delaiLatence)
    {
        //Si le résultat est négatif, alors le yield se fait immédiatement
        yield return new WaitForSeconds(delaiLatence-1);
        fadeAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(chemin);
    }
}
