using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deplacement_bateau_script : MonoBehaviour /* script qui doit gérer toute les forces qui s'exercent sur le bateau
                                                   pour l'instant il doit être capable de réceptionner la force du vent
                                                   ainsi que sa direction mais il doit aussi être capable potentiellement
                                                   de prendre en compte la force et la direction des vagues et peut-être
                                                   des courants marins*/

                                                    // mode d'emplois:
                                                    // il faut attacher ce script au GameObject Bateau 
{
    public float Direction_Du_Bateau;
    public float Vitesse_Du_Bateau;
    private float Force_Du_Vent;
    private float Direction_Du_Vent;
    private Vector3 Orientation_Bateau;
    private Vector3 Deplacement_Bateau;

    GameObject Vent;
    // Start is called before the first frame update
    void Start()
    {
       Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
        Orientation_Bateau = transform.eulerAngles.normalized; // permet de donner à Orientiatio_Bateau les valeurs de rotation du bateau
        Deplacement_Bateau = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Force_Du_Vent = Vent.GetComponent<Vent_Script>().Force_Du_Vent;             //Récupère la force du Vent
        Direction_Du_Vent = Vent.GetComponent<Vent_Script>().Direction_Du_Vent;     // récupère l'orientation en z du Vent
        transform.eulerAngles = Orientation_Bateau;                                 // permet de modifier l'axe z du Bateau en fonction de l'orientation du vent
        Orientation_Bateau.z = Direction_Du_Vent;                                   // idem


        transform.position = Deplacement_Bateau;




        if (Input.GetKeyDown(KeyCode.Z))
        {
            Deplacement_Bateau.y += Vitesse_Du_Bateau;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Deplacement_Bateau.y -= Vitesse_Du_Bateau;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Deplacement_Bateau.x -= Vitesse_Du_Bateau;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Deplacement_Bateau.x += Vitesse_Du_Bateau;
        }
    }
}
