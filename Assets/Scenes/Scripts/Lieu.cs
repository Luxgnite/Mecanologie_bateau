using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lieu : MonoBehaviour
{
    public string nomLieu;

    //Lorsque le joueur clique sur une représentation de lieu...
    private void OnMouseDown()
    {
        //...  on change le lieu actuel du joueur par celui-ci
        GameManager._instance.LieuJoueur = this;
    }
}
