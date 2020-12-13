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

        if (Input.GetKey(KeyCode.Z))
            TournerGaucheGouvernail();
        if (Input.GetKey(KeyCode.S))
            TournerDroiteGouvernail();
        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.S) && Orientation_Gouvernail.z != 0f)
            Orientation_Gouvernail_Void();
    }

    /// <summary>
    /// Fait tourner le gouvernail à gauche d'un cran
    /// </summary>
    public void TournerGaucheGouvernail()
    {
        if (Orientation_Gouvernail.z < 30f)
            Orientation_Gouvernail.z += Vitesse_Rotation_Gouvernail * Time.deltaTime;
    }

    /// <summary>
    /// Fait tourner le gouvernail à droite d'un cran
    /// </summary>
    public void TournerDroiteGouvernail()
    {
        if(Orientation_Gouvernail.z > -30f)
            Orientation_Gouvernail.z -= Vitesse_Rotation_Gouvernail * Time.deltaTime;
    }

    public void Orientation_Gouvernail_Void()
    {
        if (Orientation_Gouvernail.z > 0f)
            Orientation_Gouvernail.z -= Vitesse_Rotation_Gouvernail * Time.deltaTime * 2;
        else 
            Orientation_Gouvernail.z += Vitesse_Rotation_Gouvernail * Time.deltaTime * 2;
    }
}
