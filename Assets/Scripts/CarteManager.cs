using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteManager : MonoBehaviour
{
    //Sprite lorsque le lieu n'est pas le lieu actif du joueur
    public Sprite lieuInactif;
    //Sprite lorsque le lieu est pas le lieu actif du joueur
    public Sprite lieuActif;

    private void Awake()
    {
        //Abonnement à l'événement
        GameManager.OnChangementLieu += OnChangementLieu;
    }

    //Logique à effectuer lorsque l'événement est déclenché
    protected virtual void OnChangementLieu(Lieu nouveauLieu, Lieu ancienLieu)
    {
        // On interchange les visuels des lieux inactifs et actifs
        nouveauLieu.GetComponent<SpriteRenderer>().sprite = lieuActif;
        if(ancienLieu != null)
            ancienLieu.GetComponent<SpriteRenderer>().sprite = lieuInactif;
    }
}
