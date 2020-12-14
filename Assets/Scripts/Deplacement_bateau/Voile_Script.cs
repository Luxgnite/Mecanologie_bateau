using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voile_Script : MonoBehaviour
{

    GameObject Vent;
    GameObject Bateau_Empty;


    private Vector3 Orientation_Voile;
    public Vector3 Orientation_Bateau_Empty;


    public float Vitesse_Rotation_Voile = 5;
    public float Difference_Orientation_Voile;
    public float Force_Voile;

    // Start is called before the first frame update
    void Start()
    {
        Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
        Bateau_Empty = GameObject.Find("Bateau_Empty");
        Orientation_Voile = transform.localEulerAngles;
        Orientation_Bateau_Empty = Bateau_Empty.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Orientation_Bateau_Empty = Bateau_Empty.transform.eulerAngles;
        /*if (Mathf.Abs(Orientation_Voile.z) < Mathf.Abs(Vent.GetComponent<Vent_Script>().Orientation_Vent.z))

        {
            Difference_Orientation_Voile = Mathf.Abs(Orientation_Voile.z / Vent.GetComponent<Vent_Script>().Orientation_Vent.z);
        }
        else Difference_Orientation_Voile = Mathf.Abs(Vent.GetComponent<Vent_Script>().Orientation_Vent.z / Orientation_Voile.z);
        */




        /*if (Input.GetKey(KeyCode.Keypad9) && Orientation_Voile.z < 90f)
        {
            Orientation_Voile.z += Vitesse_Rotation_Voile * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Keypad6) && Orientation_Voile.z > -90f)
        {
            Orientation_Voile.z -= Vitesse_Rotation_Voile * Time.deltaTime;
        }*/

        transform.localEulerAngles = Orientation_Voile;

        Force_Voile_Void();
    }

    public void Force_Voile_Void()
    {


        Force_Voile = 1;
            //Force_Voile = Vent.GetComponent<Vent_Script>().Force_Vent * Difference_Orientation_Voile;
    }
}
