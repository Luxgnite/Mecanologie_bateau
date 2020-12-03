using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deplacement_bateau_script : MonoBehaviour /* script qui doit gérer toute les forces qui s'exercent sur le bateau
                                                   pour l'instant il doit être capable de réceptionner la force du vent
                                                   ainsi que sa direction mais il doit aussi être capable potentiellement
                                                   de prendre en compte la force et la direction des vagues et peut-être
                                                   des courants marins*/

                                                    // mode d'emploi:
                                                    // il faut attacher ce script au GameObject Bateau 
{
    //public float Direction_Du_Bateau;
    public float Vitesse_Du_Bateau;
    private float Force_Du_Vent;
    private float Direction_Du_Vent;
    public float Vitesse_De_Rotation_Bateau = 10;        // permet de modifier la manoeuvrabilité du bateau


    private Vector3 Orientation_Bateau;
    private Vector3 Deplacement_Bateau;
    private Vector3 Orientation_Bateau_Empty;
    private Vector3 Deplacement_Bateau_Empty;




    GameObject Vent;
    GameObject Bateau_Empty; 
    // Start is called before the first frame update
    void Start()
    {
        Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
        Bateau_Empty = GameObject.Find("Bateau_Empty");
        Orientation_Bateau = transform.eulerAngles.normalized; // permet de donner à Orientiatio_Bateau les valeurs de rotation du bateau
        Deplacement_Bateau = transform.position;
        Force_Du_Vent = Vent.GetComponent<Vent_Script>().Force_Du_Vent;

    }

    // Update is called once per frame
    void Update()
    {
        Force_Du_Vent = Vent.GetComponent<Vent_Script>().Force_Du_Vent;             //Récupère la force du Vent
        Direction_Du_Vent = Vent.GetComponent<Vent_Script>().Direction_Du_Vent;     // récupère l'orientation en z du Vent
        Deplacement_Bateau_Void();



        if (Orientation_Bateau.z < 0)
        {
            if (Direction_Du_Vent - Orientation_Bateau.z > 0)
            {
                transform.eulerAngles = Orientation_Bateau;
                Orientation_Bateau.z += Vitesse_De_Rotation_Bateau * Time.deltaTime;

            }
            else
            {
                transform.eulerAngles = Orientation_Bateau;
                Orientation_Bateau.z -= Vitesse_De_Rotation_Bateau * Time.deltaTime;
            }
        }
        if (Direction_Du_Vent - Orientation_Bateau.z < 0)
        {
            transform.eulerAngles = Orientation_Bateau;
            Orientation_Bateau.z -= Vitesse_De_Rotation_Bateau * Time.deltaTime;

        }
        /*transform.eulerAngles = Orientation_Bateau;                                 // permet de modifier l'axe z du Bateau en fonction de l'orientation du vent
        Orientation_Bateau.z = Direction_Du_Vent;                                   // idem*/




        if (Vitesse_Du_Bateau > 0)
        {
            Bateau_Empty.transform.position += transform.TransformDirection(Vector2.right) * Time.deltaTime * Vitesse_Du_Bateau;
        }



        if (Input.GetKey(KeyCode.Z))
        {
            Bateau_Empty.transform.position += transform.TransformDirection(Vector2.right)* Time.deltaTime * Vitesse_Du_Bateau;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Bateau_Empty.transform.position += transform.TransformDirection(Vector2.left) * Time.deltaTime * Vitesse_Du_Bateau;
        }

    }

    private void Deplacement_Bateau_Void()
    {
        Vitesse_Du_Bateau = Force_Du_Vent;
    }
}
