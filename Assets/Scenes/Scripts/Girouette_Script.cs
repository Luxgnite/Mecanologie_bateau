using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girouette_Script : MonoBehaviour
{

    GameObject Bateau_Empty;
    GameObject Vent;

    private Vector3 Position_Girouette;

    // Start is called before the first frame update
    void Start()
    {
        Bateau_Empty = GameObject.Find("Bateau_Empty");
        Vent = GameObject.Find("Vent");
        Position_Girouette = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Position_Girouette.x = Bateau_Empty.transform.position.x;
        Position_Girouette.y = Bateau_Empty.transform.position.y + 2;
        Position_Girouette.z = Bateau_Empty.transform.position.z;

        transform.position = Position_Girouette;
        transform.rotation = Vent.transform.rotation;
    }
}
