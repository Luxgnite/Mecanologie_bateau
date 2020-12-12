using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Climatique_Script : MonoBehaviour
{
    GameObject Vent;
    GameObject Bateau_Empty;

    private bool Bateau_Dans_Zone_01 = false;

    public float Distance_Bateau;

    private void Start()
    {
         Vent = GameObject.Find("Vent");              //il faut dans la scène un GameObject "Vent" qui aura une direction et une force
         Bateau_Empty = GameObject.Find("Bateau_Empty");   
    }
    private void Update()
    {
        Distance_Bateau = Vector3.Distance(Bateau_Empty.transform.position, transform.position);
        if (Distance_Bateau <= 20f && !Bateau_Dans_Zone_01)
        {
            Climat_Puissance_01();
            Bateau_Dans_Zone_01 = true;
        }
    }
    public void Climat_Puissance_01()
    {
        Vent.GetComponent<Vent_Script>().Orientation_Variation_Vent(90f, 30f, 10);
    }
}
