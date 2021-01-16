using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Climatique_Script : MonoBehaviour
{
    GameObject Vent;
    GameObject Bateau_Empty;

    private bool Bateau_Dans_Zone_01 = false;
    private bool Bateau_Dans_Zone_02 = false;
    private bool Bateau_Dans_Zone_03 = false;
    private bool Bateau_Dans_Zone_04 = false;

    public float Distance_Bateau;
    public float Orientation_Globale;
    public float Amplitude;
    public float Vitesse_Variation;
    public float Force_Vent;

    private void Start()
    {
         Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
         Bateau_Empty = GameObject.Find("Bateau_Empty");   
    }
    private void Update()
    {
        Distance_Bateau = Vector3.Distance(Bateau_Empty.transform.position, transform.position);
        Change_Zone();

    }


    private void Change_Zone()
    {
        if (Distance_Bateau <= 50f && Distance_Bateau > 30f && !Bateau_Dans_Zone_01)
        {

            Orientation_Globale = 90f;
            Amplitude = 15f;
            Vitesse_Variation = 20f;
            Force_Vent = 1;
            Climat_Puissance_01();
            Bateau_Dans_Zone_01 = true;
            Bateau_Dans_Zone_02 = false;
            Bateau_Dans_Zone_03 = false;
            Bateau_Dans_Zone_04 = false;

        }

        if (Distance_Bateau <= 30f  && !Bateau_Dans_Zone_02)
        {

            Orientation_Globale = -90f;
            Amplitude = 30f;
            Vitesse_Variation = 1f;
            Force_Vent = 2;


            Climat_Puissance_02();
            Bateau_Dans_Zone_01 = false;
            Bateau_Dans_Zone_02 = true;
            Bateau_Dans_Zone_03 = false;
            Bateau_Dans_Zone_04 = false;

        }
    }


    public void Climat_Puissance_01()
    {
        Vent.GetComponent<Vent_Script>().Orientation_Variation_Vent(Orientation_Globale, Amplitude, Vitesse_Variation, Force_Vent); // en premier l'orientation globale du vent, en deuxième l'amplitude, en troisième la vitesse de l'amplitude, en quatrième la force du vent
    }
    public void Climat_Puissance_02()
    {
        Vent.GetComponent<Vent_Script>().Orientation_Variation_Vent(Orientation_Globale, Amplitude, Vitesse_Variation, Force_Vent); 
    }

}
