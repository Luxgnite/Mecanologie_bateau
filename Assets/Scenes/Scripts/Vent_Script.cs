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
    private float Nouvel_Angle;

    public bool Changement;
    public bool Coroutine_00_Active = false;

    public bool Coroutine_01_Active = false;
    public bool Coroutine_02_Active = false;





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

    public void Orientation_Variation_Vent(float Orientation, float Variation, float compteur, float forceVent)
    {
        Changement = true; // Permet de stoper les Coroutines 01 et 02
        Force_Vent = forceVent;
        Nouvel_Angle = Orientation;
        Vitesse_Variation = compteur;
        Angle_Variation = Variation;
        StartCoroutine(Variation_00(Nouvel_Angle));
    }

    IEnumerator Variation_00(float Orientation) // premiere Coroutine qui s'exécute, permet de changer l'orientation globale du vent
    {
        Coroutine_00_Active = true;
        Changement = false;

        if (Orientation_Vent.z > Orientation)
        {
            while (Orientation_Vent.z > Orientation)
            {
                Orientation_Vent.z -= Vitesse_Rotation_Vent;
                Debug.Log("Variation_00");
                yield return new WaitForSeconds(0.01f);
            }
        }
        if (Orientation_Vent.z < Orientation)
        {
            while (Orientation_Vent.z < Orientation)
            {
                Debug.Log("Variation_00 bis");
                Orientation_Vent.z += Vitesse_Rotation_Vent;
                yield return new WaitForSeconds(0.01f);
            }
        }
        Coroutine_00_Active = false;
        StartCoroutine(Variation_01(Vitesse_Variation));
    }

    IEnumerator Variation_01(float compteur) // deuxième coroutine, change l'orientation du vent en fonction de l'amplitude donner et lance la troisième coroutine
    {
        if (!Coroutine_02_Active && !Changement && !Coroutine_00_Active)
        {
            Coroutine_01_Active = true;
            temps = compteur;
            while (temps > 0)
            {

                temps--;
                yield return new WaitForSeconds(0.01f);
                Debug.Log("Variation_01");
                Orientation_Vent.z += Vitesse_Rotation_Vent;
            }
            Coroutine_01_Active = false;
            if (temps == 0)
            {
                if (!Changement)
                {
                    StartCoroutine(Variation_02(Angle_Variation));
                }
                else StartCoroutine(Variation_00(Nouvel_Angle));
            }
        }
    }
    IEnumerator Variation_02(float compteur)// troisième coroutine, change l'orientation du vent à l'inverse de la deuxième et la relance
    {
        if (!Coroutine_01_Active && !Changement && !Coroutine_00_Active)
        {
            Coroutine_02_Active = true;
            temps = compteur;
            while (temps > 0)
            {
                Debug.Log("Variation_02");
                temps--;
                yield return new WaitForSeconds(0.01f);

                Orientation_Vent.z -= Vitesse_Rotation_Vent;
            }
            Coroutine_02_Active = false;
            if (temps == 0)
            {
                if (!Changement)
                {
                    StartCoroutine(Variation_01(Angle_Variation));
                }
                else StartCoroutine(Variation_00(Nouvel_Angle));
            }
        }
    }
}
