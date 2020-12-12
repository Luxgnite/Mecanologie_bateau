using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objet de Gestion de l'affichage de la vue pour le déplacement du joueur sur le bateau
/// </summary>
public class CarteManager : MonoBehaviour
{
    //Sprite lorsque le lieu n'est pas le lieu actif du joueur
    public Sprite lieuInactif;
    //Sprite lorsque le lieu est pas le lieu actif du joueur
    public Sprite lieuActif;
    public Lieu[] lieux;

    private void Awake()
    {
        //Abonnement à l'événement
        GameManager.OnChangementLieu += OnChangementLieu;
    }

    private void Start()
    {
        lieux = GetComponentsInChildren<Lieu>();
        OnChangementLieu(GameManager._instance.LieuJoueur, "");
    }

    //Logique à effectuer lorsque l'événement est déclenché
    private void OnChangementLieu(string nouveauLieu, string ancienLieu)
    {
        // On interchange les visuels des lieux inactifs et actifs
        for(int i = 0; i < lieux.Length; i++)
        {
            //On tente de récupérer les exceptions dans le cas où un Lieu n'est plus référencé comme il faut
            try
            {
                //Si l'objet référence le nouveau lieu du joueur, on change son visuel en conséquence
                if (lieux[i].nomLieu == nouveauLieu)
                    lieux[i].GetComponent<SpriteRenderer>().sprite = lieuActif;
                //Si l'objet référence l'ancien lieu du joueur, on change son visuel en conséquence
                else if (lieux[i].nomLieu == ancienLieu)
                    lieux[i].GetComponent<SpriteRenderer>().sprite = lieuInactif;
            }
            catch (MissingReferenceException)
            {
                Debug.Log("Missing Reference to a Lieu");
            }
        }
    }

}
