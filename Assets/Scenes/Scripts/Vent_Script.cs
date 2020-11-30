using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vent_Script : MonoBehaviour /* Script qui gère la force et la direction du vent*/

                                         // mode d'emplois:
                                         // il faut attacher ce script à un GameObject "Vent" ce GameObject peu être un Empty et doit avoir le nom "Vent"
{
    public float Force_Du_Vent = 10f;
    public float Direction_Du_Vent;
    private Vector3 Orientation_Du_Vent;


    GameObject Bateau;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Bateau");
        Orientation_Du_Vent = transform.eulerAngles.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        Direction_Du_Vent = transform.rotation.eulerAngles.z;
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Orientation_Du_Vent.z += 5;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            Orientation_Du_Vent.z -= 5;
        }
        transform.eulerAngles = Orientation_Du_Vent;
    }
}
