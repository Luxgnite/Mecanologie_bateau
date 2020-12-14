using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GouvernailManager : MonoBehaviour
{
    public Vector3 Orientation_Gouvernail;
    public float Vitesse_Rotation_Gouvernail = 10;

    public  Vector3 Orientation_Bateau_Empty;
    GameObject Bateau;
    GameObject Bateau_Empty;
    //Angle que le gourvernail doit effectuer
    public float angleATourner;

    // Start is called before the first frame update
    void Start()
    {
        Bateau = GameObject.Find("Bateau");
        Bateau_Empty = GameObject.Find("Bateau_Empty");

        Orientation_Bateau_Empty = Bateau_Empty.transform.localEulerAngles;
        Orientation_Gouvernail = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {        

        /*if (Input.GetKey(KeyCode.Z))
            TournerGaucheGouvernail();
        if (Input.GetKey(KeyCode.S))
            TournerDroiteGouvernail();*/
        if (/*!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S)*/ angleATourner == 0 && Orientation_Gouvernail.z != 0f)
            Orientation_Gouvernail_Void();

        //Lorsque l'on veut faire tourner d'un certain angle le gouvernail à gauche
        if (angleATourner > 0f)
        {
            float distance = TournerGaucheGouvernail();
            
            if (distance == 0)
                angleATourner = 0;
            else
                angleATourner -= distance;

            if (angleATourner < 0)
                angleATourner = 0;
        }

        //Lorsque l'on veut faire tourner d'un certain angle le gouvernail à droite
        if (angleATourner < 0f)
        {
            float distance = TournerDroiteGouvernail();

            if (distance == 0)
                angleATourner = 0;
            else
                angleATourner += TournerDroiteGouvernail();

            if (angleATourner > 0)
                angleATourner = 0;
        }
    }

    /// <summary>
    /// Fait tourner le gouvernail à gauche d'un cran
    /// </summary>
    /// <returns>La distance parcouru par le gouvernail durant le deltaTime</returns>
    public float TournerGaucheGouvernail()
    {
        if (Orientation_Gouvernail.z < 30f)
        {
            float distanceParcourue = Vitesse_Rotation_Gouvernail * Time.deltaTime;
            Orientation_Gouvernail.z += distanceParcourue;
            return Mathf.Abs(distanceParcourue);
        }
        return 0f;
    }

    /// <summary>
    /// Fait tourner le gouvernail d'autant de l'angle précisé vers la gauche
    /// </summary>
    /// <param name="angle">Angle de rotation à faire tourner le gouvernail relativement à son actuel angle</param>
    public void TournerGaucheGouvernail(float angle)
    {
        angleATourner += Mathf.Abs(angle);
    }

    /// <summary>
    /// Fait tourner le gouvernail à droite d'un cran
    /// </summary>
    /// <returns>La distance parcouru par le gouvernail durant le deltaTime</returns>
    public float TournerDroiteGouvernail()
    {
        if(Orientation_Gouvernail.z > -30f)
        {
            float distanceParcourue = Vitesse_Rotation_Gouvernail * Time.deltaTime;
            Orientation_Gouvernail.z -= distanceParcourue;
            return Mathf.Abs(distanceParcourue);
        }
        return 0f;
    }

    /// <summary>
    /// Fait tourner le gouvernail d'autant de l'angle précisé vers la droite
    /// </summary>
    /// <param name="angle">Angle de rotation à faire tourner le gouvernail relativement à son actuel angle</param>
    public void TournerDroiteGouvernail(float angle)
    {
        angleATourner += -Mathf.Abs(angle);
    }

    /// <summary>
    /// Tourne le gouvernail en direction du centre, position "neutre"
    /// </summary>
    public void Orientation_Gouvernail_Void()
    {
        if (Orientation_Gouvernail.z > 0f)
            Orientation_Gouvernail.z -= Vitesse_Rotation_Gouvernail * Time.deltaTime * 2;
        else 
            Orientation_Gouvernail.z += Vitesse_Rotation_Gouvernail * Time.deltaTime * 2;
    }

    public float RotationActuelleGouvernail()
    {
        return Orientation_Gouvernail.z;
    }
}
