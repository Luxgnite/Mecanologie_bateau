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
    public float Difference_Vent_Bateau_Empty;
    public float Force_Voile;

    private float x;

    // Start is called before the first frame update
    void Start()
    {
        //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
        Vent = GameObject.Find("Vent");              
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

        if (Mathf.Abs(Orientation_Voile.z - Difference_Vent_Bateau_Empty) > 180)
        {
            Difference_Orientation_Voile = Mathf.Abs(Orientation_Voile.z - Difference_Vent_Bateau_Empty) - 360;
        }
        else Difference_Orientation_Voile = Mathf.Abs(Orientation_Voile.z - Difference_Vent_Bateau_Empty);




        //Difference_Vent_Bateau_Empty = Orientation_Vent.z - Orientation_Bateau_+Empty.z;

        if (Orientation_Vent.z - Orientation_Bateau_Empty.z > 360)
        {
            Difference_Vent_Bateau_Empty = Orientation_Vent.z - Orientation_Bateau_Empty.z - 360;
        }
        if (Orientation_Vent.z - Orientation_Bateau_Empty.z < 0)
        {
            Difference_Vent_Bateau_Empty = Orientation_Vent.z - Orientation_Bateau_Empty.z + 360;
        }
        if (Orientation_Vent.z - Orientation_Bateau_Empty.z < 360 && Orientation_Vent.z - Orientation_Bateau_Empty.z > 0)
        {
            Difference_Vent_Bateau_Empty = Orientation_Vent.z - Orientation_Bateau_Empty.z;
        }



        if (Mathf.Abs(Difference_Orientation_Voile) < 90f)
        {
            Force_Voile = Mathf.Abs(Difference_Orientation_Voile) / 90 * Vent.GetComponent<Vent_Script>().Force_Vent;
        }
        if (Mathf.Abs(Difference_Orientation_Voile) > 90f)
        {
            Force_Voile = Mathf.Abs(Mathf.Abs(Difference_Orientation_Voile) - 180) / 90 * Vent.GetComponent<Vent_Script>().Force_Vent;
        }


        //Difference_Orientation_Voile =  Mathf.Abs(Orientation_Voile.z) - Orientation_Vent.z;
        //Force_Voile = Mathf.Abs(Difference_Orientation_Voile / 90);
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

    /// <summary>
    /// Permet de changer l'orientation de la voile par rapport au bateau
    /// </summary>
    public void Orientation_Voile_Void() 

    {
        /*if (Input.GetKey(KeyCode.Keypad9) && Orientation_Voile.z < 90f)
        {
            Orientation_Voile.z += Vitesse_Rotation_Voile * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Keypad6) && Orientation_Voile.z > -90f)
        {
            Orientation_Voile.z -= Vitesse_Rotation_Voile * Time.deltaTime;
        }*/
    }
}
