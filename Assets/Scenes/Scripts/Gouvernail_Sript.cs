using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gouvernail_Sript : MonoBehaviour
{

    GameObject Bateau;
    GameObject Bateau_Empty;


    public Vector3 Orientation_Gouvernail;
    private Vector3 Orientation_Bateau_Empty;


    public float Vitesse_Rotation_Gouvernail = 10;
    // Start is called before the first frame update
    void Start()
    {
        Bateau = GameObject.Find("Bateau");
        Bateau_Empty = GameObject.Find("Bateau_Empty");
        Orientation_Bateau_Empty = Bateau_Empty.transform.eulerAngles;
        Orientation_Gouvernail = transform.rotation.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {        
        transform.eulerAngles = Orientation_Gouvernail;
        if (Input.GetKey(KeyCode.Z) && Orientation_Gouvernail.z < 60f)
        {
            Orientation_Gouvernail.z += Vitesse_Rotation_Gouvernail * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Orientation_Gouvernail.z > -60f)
        {
            Orientation_Gouvernail.z -= Vitesse_Rotation_Gouvernail * Time.deltaTime;
        }

        if (Orientation_Gouvernail.z != Bateau_Empty.transform.rotation.z)
        {
            //Orientation_Gouvernail_Void();
        }

    }

    public void Orientation_Gouvernail_Void()
    {
        if (Bateau_Empty.transform.rotation.z - Orientation_Gouvernail.z < 90f)
        {
            Orientation_Gouvernail.z -= Vitesse_Rotation_Gouvernail * Time.deltaTime / 2;
        } else Orientation_Gouvernail.z += Vitesse_Rotation_Gouvernail * Time.deltaTime / 2;


    }
}
