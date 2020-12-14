using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;


/// <summary>
/// Objet de donnée & interaction, à placer sur un GameObject à cliquer pour que le joueur se déplace
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Lieu : MonoBehaviour, IPointerClickHandler
{
    public string nomLieu;

    //Lorsque le joueur clique sur une représentation de lieu...
    public void OnPointerClick(PointerEventData eventData)
    {
        //...  on change le lieu actuel du joueur par celui-ci
        GameManager._instance.LieuJoueur = this.nomLieu;
    }
}
