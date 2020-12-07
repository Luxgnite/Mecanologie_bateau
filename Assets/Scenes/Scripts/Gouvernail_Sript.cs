using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gouvernail_Sript : MonoBehaviour
{

    GameObject Bateau;


    public Vector3 Orientation_Gouvernail;


    public float Vitesse_Rotation_Gouvernail = 5;
    // Start is called before the first frame update
    void Start()
    {
        Bateau = GameObject.Find("Bateau");
        Orientation_Gouvernail = transform.rotation.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {        
        transform.eulerAngles = Orientation_Gouvernail;
        if (Input.GetKey(KeyCode.Z))
        {
            Orientation_Gouvernail.z += Vitesse_Rotation_Gouvernail * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Orientation_Gouvernail.z -= Vitesse_Rotation_Gouvernail * Time.deltaTime;
        }

        if (Orientation_Gouvernail.z != Bateau.GetComponent<Deplacement_bateau_script>().Orientation_Bateau.z)
        {
            Orientation_Gouvernail_Void();
        }

    }

    public void Orientation_Gouvernail_Void()
    {
        if (Orientation_Gouvernail.z > Bateau.GetComponent<Deplacement_bateau_script>().Orientation_Bateau.z)
        {
            Orientation_Gouvernail.z -= Vitesse_Rotation_Gouvernail * Time.deltaTime;
        } else Orientation_Gouvernail.z += Vitesse_Rotation_Gouvernail * Time.deltaTime;


    }
}
