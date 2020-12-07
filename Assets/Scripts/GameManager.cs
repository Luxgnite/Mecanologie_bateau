using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Référence à l'instance Singleton actuelle
    public static GameManager _instance;

    //Événement lors d'un changement de lieu
    public delegate void LieuAction(Lieu nouveauLieu, Lieu ancienLieu);
    public static event LieuAction OnChangementLieu;

    //Animator de l'objet utilisé pour faire des fade in/out 
    public Animator fadeAnimator;

    //Lieu dans lequel le joueur se situe
    public Lieu lieuJoueur;
    /// <summary>
    /// Getter - Setter pour définir le lieu du joueur
    /// </summary>
    public Lieu LieuJoueur
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
                Lieu temp = lieuJoueur;
                //Attribution de la nouvelle valeur du lieu du joueur
                lieuJoueur = value;
                //Envoi de l'événement pour signaler un changement de lieu
                OnChangementLieu(lieuJoueur, temp);
                afficherAction(lieuJoueur.nomLieu);
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
    void afficherAction(string nomTache)
    {
        chargerScene("Scenes/ScenesTest/Taches/" + nomTache);
    }

    /// <summary>
    /// Afficher la scène de la carte du bateau
    /// </summary>
    public void afficherCarteBateau()
    {
        chargerScene("Scenes/ScenesTest/Deplacement_personnage");
    }
    
    /// <summary>
    /// Charge la scène correspondant au chemin
    /// </summary>
    /// <param name="chemin">Chemin vers la scène à charger. Ex : "Scenes/Scene1" </param>
    /// <param name="delaiLatence">Temps en seconde de la latence. Si non spécifié, il est égal à 1f </param>
    public void chargerScene(string chemin, float delaiLatence = 1f)
    {
        StartCoroutine(ChargerSceneDelai(chemin, delaiLatence));
    }

    //Coroutine pour effectuer charger une scène avec du délai
    IEnumerator ChargerSceneDelai(string chemin, float delaiLatence)
    {
        yield return new WaitForSeconds(delaiLatence-1);
        fadeAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(chemin);
    }
}
