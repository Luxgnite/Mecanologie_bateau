using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Référence à l'instance Singleton actuelle
    public static GameManager _instance;

    //Événement lors d'un changement de lieu
    public delegate void LieuAction(Lieu nouveauLieu, Lieu ancienLieu);
    public static event LieuAction OnChangementLieu;

    //Lieu dans lequel le joueur se situe
    public Lieu lieuJoueur;
    //Getter - Setter pour définir le lieu du joueur
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
