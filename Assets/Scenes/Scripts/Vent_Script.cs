using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vent_Script : MonoBehaviour /* Script qui gère la force et la direction du vent*/

// mode d'emplois:
// il faut attacher ce script à un GameObject "Vent" ce GameObject peu être un Empty et doit avoir le nom "Vent"
{
    public float Force_Vent = 10f;
    //public float Direction_Vent;
    public float Vitesse_Rotation_Vent = 40;
    public Vector3 Orientation_Vent;


    GameObject Bateau;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Bateau");
        Orientation_Vent = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //Direction_Vent = transform.rotation.eulerAngles.z;

        if (Input.GetKey(KeyCode.KeypadPlus))

        {
            Orientation_Vent.z += Vitesse_Rotation_Vent *Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.KeypadMinus))

        {
            Orientation_Vent.z -= Vitesse_Rotation_Vent * Time.deltaTime;
        }



        if (Orientation_Vent.z < 0)
        {
            Orientation_Vent.z = 360f;
        }
        if (Orientation_Vent.z > 360f)
        {
            Orientation_Vent.z = 0f;
        }




        transform.localEulerAngles = Orientation_Vent;
    }
}
