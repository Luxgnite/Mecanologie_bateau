using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vent_Script : MonoBehaviour /* Script qui gère la force et la direction du vent*/

// mode d'emplois:
// il faut attacher ce script à un GameObject "Vent" ce GameObject peu être un Empty et doit avoir le nom "Vent"
{
    public float Force_Vent = 10f;
    public float Vitesse_Rotation_Vent = 40;
    public Vector3 Orientation_Vent;
    private float temps;
    private float Vitesse_Variation;
    private float Angle_Variation;

    private bool Changement;




    void Start()
    {
        Orientation_Vent = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {


        if (Orientation_Vent.z < -180)
        {
            Orientation_Vent.z = 180f;
        }
        if (Orientation_Vent.z > 180f)
        {
            Orientation_Vent.z = -180f;
        }
        if (Input.GetKey(KeyCode.KeypadPlus))

        {
            Orientation_Vent.z += Vitesse_Rotation_Vent * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.KeypadMinus))

        {
            Orientation_Vent.z -= Vitesse_Rotation_Vent * Time.deltaTime;
        }

        transform.localEulerAngles = Orientation_Vent;
    }

    public void Orientation_Variation_Vent(float Orientation, float Variation, float compteur)
    {
        Changement = true;

        StartCoroutine(Variation_00(Orientation));



        Vitesse_Variation = compteur;
        Angle_Variation = Variation;


    }

    IEnumerator Variation_00(float Orientation)
    {
        if (Orientation_Vent.z > Orientation)
        {
            while (Orientation_Vent.z > Orientation)
            {
                Orientation_Vent.z -= Vitesse_Rotation_Vent;
                yield return new WaitForSeconds(0.01f);
            }
        }
        if (Orientation_Vent.z < Orientation)
        {
            while (Orientation_Vent.z < Orientation)
            {
                Orientation_Vent.z += Vitesse_Rotation_Vent;
                yield return new WaitForSeconds(0.01f);
            }
        }
        StartCoroutine(Variation_01(Angle_Variation));
    }

    IEnumerator Variation_01(float compteur)
    {
        Changement = false;
        temps = compteur;
        while (temps > 0)
        {

            temps--;
            yield return new WaitForSeconds(0.05f);
            Orientation_Vent.z += Vitesse_Rotation_Vent;
        }
        if (temps == 0 && !Changement)
        {
            StartCoroutine(Variation_02(Angle_Variation));
        }
    }
    IEnumerator Variation_02(float compteur)
    {
        temps = compteur;
        while (temps > 0)
        {

            temps--;
            yield return new WaitForSeconds(0.05f);
            Orientation_Vent.z -= Vitesse_Rotation_Vent;
        }
        if (temps == 0 && !Changement)
        {
            StartCoroutine(Variation_01(Angle_Variation));
        }
    }
}
