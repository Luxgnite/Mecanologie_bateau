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

    private void Start()
    {
         Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
         Bateau_Empty = GameObject.Find("Bateau_Empty");   
    }
    private void Update()
    {
        Distance_Bateau = Vector3.Distance(Bateau_Empty.transform.position, transform.position);
        if (Distance_Bateau <= 50f && !Bateau_Dans_Zone_01)
        {
            Climat_Puissance_01();
            Bateau_Dans_Zone_01 = true;
            Bateau_Dans_Zone_02 = false;
            Bateau_Dans_Zone_03 = false;
            Bateau_Dans_Zone_04 = false;
        }

        if (Distance_Bateau <= 30f && !Bateau_Dans_Zone_02)
        {
            Climat_Puissance_02();
            Bateau_Dans_Zone_01 = false;
            Bateau_Dans_Zone_02 = true;
            Bateau_Dans_Zone_03 = false;
            Bateau_Dans_Zone_04 = false;
        }

    }
    public void Climat_Puissance_01()
    {
        Vent.GetComponent<Vent_Script>().Orientation_Variation_Vent(90f, 15f, 20, 1); // en Premier l'orientation globale du vent, en deuxième l'amplitude, en troisième la vitesse de l'amplitude, en quatrième la force du vent
    }
    public void Climat_Puissance_02()
    {
        Vent.GetComponent<Vent_Script>().Orientation_Variation_Vent(110f, 30f, 20, 2); 
    }

}
