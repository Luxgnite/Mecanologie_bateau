using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GourvernailController : MonoBehaviour
{
    public float pasRotationGouvernail = 5f;

    public void rotationDroite()
    {
        Debug.Log("A Tribord!");
        GameManager._instance.GouvernailManager.TournerDroiteGouvernail(pasRotationGouvernail);
    }

    public void rotationGauche()
    {
        Debug.Log("A Tribord!");
        GameManager._instance.GouvernailManager.TournerGaucheGouvernail(pasRotationGouvernail);
    }


}
