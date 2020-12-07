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
                StartCoroutine(AfficherAction(lieuJoueur.nomLieu));
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

    }

    //Coroutine pour effectuer afficherAction avec du délai
    IEnumerator AfficherAction(string nomAction)
    {
        yield return new WaitForSeconds(1f);
        afficherAction(nomAction);
    }

    //Afficher l'action à effectué sur le lieu sélectionné
    void afficherAction(string nomTache)
    {
        SceneManager.LoadScene("Scenes/ScenesTest/Taches/" + nomTache);
    }

    /// <summary>
    /// Afficher la scène de la carte du bateau
    /// </summary>
    public static void afficherCarteBateau()
    {
        SceneManager.LoadScene("Scenes/ScenesTest/Deplacement_personnage");
    }
}
