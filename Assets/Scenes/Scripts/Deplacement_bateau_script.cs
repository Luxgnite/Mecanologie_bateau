using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deplacement_bateau_script : MonoBehaviour
/*  script qui doit gérer toute les forces qui s'exercent sur le bateau
 *  pour l'instant il doit être capable de réceptionner la force du vent
 *  ainsi que sa direction mais il doit aussi être capable potentiellement
 *  de prendre en compte la force et la direction des vagues et peut-être
 *  des courants marins*/
 // en lien avec la voile et le gouvernail
                                                        // mode d'emploi:
                                                        // il faut attacher ce script au GameObject Bateau 
{
    //public float Direction_Du_Bateau;
    public float Vitesse_Du_Bateau;
    private float Force_Vent;
    private float Direction_Vent;
    private float Difference_Orientation_Bateau_Gouvernail;
    public float Vitesse_De_Rotation_Bateau = 10;        // permet de modifier la manoeuvrabilité du bateau
    




    public Vector3 Orientation_Bateau;
    private Vector3 Deplacement_Bateau;
    private Vector3 Orientation_Bateau_Empty;
    private Vector3 Deplacement_Bateau_Empty;




    GameObject Vent;
    GameObject Bateau_Empty;
    GameObject Gouvernail;
    GameObject Voile;



    void Start()
    {
        Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
        Bateau_Empty = GameObject.Find("Bateau_Empty");
        Gouvernail = GameObject.Find("Gouvernail");
        Voile = GameObject.Find("Voile");



        Orientation_Bateau = transform.localEulerAngles; // permet de donner à Orientiatio_Bateau les valeurs de rotation du bateau
        Deplacement_Bateau = transform.position;
        Force_Vent = Vent.GetComponent<Vent_Script>().Force_Vent;
        Orientation_Bateau_Empty = Bateau_Empty.transform.localEulerAngles;
        

    }

    void Update()
    {
        Force_Vent = Vent.GetComponent<Vent_Script>().Force_Vent;             //Récupère la force du Vent
        Direction_Vent = Vent.GetComponent<Vent_Script>().Orientation_Vent.z;     // récupère l'orientation en z du Vent
        Deplacement_Bateau_Void();
        
        Difference_Orientation_Bateau_Gouvernail = Orientation_Bateau.z - Gouvernail.GetComponent<Gouvernail_Sript>().Orientation_Gouvernail.z;
        if (Difference_Orientation_Bateau_Gouvernail != 0)
        {
            Orientation_Bateau_Void();
        }
        transform.localEulerAngles = Orientation_Bateau;                                 // permet de modifier l'axe z du Bateau en fonction de l'orientation du vent
        Bateau_Empty.transform.localEulerAngles = Orientation_Bateau_Empty;


        if(Bateau_Empty.transform.localEulerAngles.z > 360f)
        {
            Orientation_Bateau_Empty.z = 0f;
        }
        if (Bateau_Empty.transform.localEulerAngles.z < 0f)
        {
            Orientation_Bateau_Empty.z = 360f;
        }



        if (Vitesse_Du_Bateau > 0)
        {
            Bateau_Empty.transform.position += transform.TransformDirection(Vector2.right) * Time.deltaTime * Vitesse_Du_Bateau;
        }


    }

    private void Deplacement_Bateau_Void()
    {
        Vitesse_Du_Bateau = Voile.GetComponent<Voile_Script>().Force_Voile;
    }
    private void Orientation_Bateau_Void()
    {
        if (Difference_Orientation_Bateau_Gouvernail > 0)
        {
            Orientation_Bateau_Empty.z += Vitesse_De_Rotation_Bateau * Time.deltaTime * Vitesse_Du_Bateau;
        }
        else
        {
            Orientation_Bateau_Empty.z -= Vitesse_De_Rotation_Bateau * Time.deltaTime * Vitesse_Du_Bateau;
            
        }

    }
}
