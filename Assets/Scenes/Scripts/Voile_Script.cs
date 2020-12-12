using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voile_Script : MonoBehaviour
{

    GameObject Vent;
    GameObject Bateau_Empty;


    public Vector3 Orientation_Voile;
    public Vector3 Orientation_Bateau_Empty;
    private Vector3 Orientation_Vent;


    public float Vitesse_Rotation_Voile = 5;
    public float Difference_Orientation_Voile;
    public float Force_Voile;

    private float x;

    // Start is called before the first frame update
    void Start()
    {
        Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
        Bateau_Empty = GameObject.Find("Bateau_Empty");
        Orientation_Voile = transform.localEulerAngles;
        Orientation_Bateau_Empty = Bateau_Empty.transform.eulerAngles;
        Orientation_Vent = Vent.GetComponent<Vent_Script>().Orientation_Vent;
    }

    // Update is called once per frame
    void Update()
    {
        Orientation_Vent = Vent.GetComponent<Vent_Script>().Orientation_Vent;
        Orientation_Bateau_Empty = Bateau_Empty.transform.eulerAngles;
        transform.localEulerAngles = Orientation_Voile;





        //Debug.Log("La différence de degrés entre la voile et le vent est de : " + Difference_Orientation_Voile);



        Orientation_Voile_Void();
        Force_Voile_Void();

    }
    public void Force_Voile_Void()
    {
        Difference_Orientation_Voile =  Mathf.Abs(Orientation_Voile.z) - Orientation_Vent.z;
        Force_Voile = Mathf.Abs(Difference_Orientation_Voile / 90);
    }
    /*public void Force_Voile_Void()
    {
        if (Orientation_Vent.z != 0 && Orientation_Voile.z != 0)
        {
            if (Mathf.Abs(Orientation_Voile.z) < Mathf.Abs(Orientation_Vent.z))

            {
                Difference_Orientation_Voile = 1 / Mathf.Abs(Orientation_Voile.z / Orientation_Vent.z) / 100;
            }
            else Difference_Orientation_Voile = 1 / Mathf.Abs(Orientation_Vent.z / Orientation_Voile.z) / 100;

        }
        else Difference_Orientation_Voile = 0;

        Force_Voile = Vent.GetComponent<Vent_Script>().Force_Vent * Difference_Orientation_Voile;
    x = Orientation_Vent.z - Orientation_Voile.z;
    Debug.Log("La différence entre la voile et le vent est de :" + x);
    }*/



    public void Orientation_Voile_Void() // Permet de changer l'orientation de la voile par rapport au bateau

    {
        if (Input.GetKey(KeyCode.Keypad9) && Orientation_Voile.z < 90f)
        {
            Orientation_Voile.z += Vitesse_Rotation_Voile * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Keypad6) && Orientation_Voile.z > -90f)
        {
            Orientation_Voile.z -= Vitesse_Rotation_Voile * Time.deltaTime;
        }
    }

}
