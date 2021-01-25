using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCarte : MonoBehaviour
{
    [Header("Échelle de conversion Carte affichée / Unity")]
    public float scale = 1f;

    private Transform bateauPosition;

    private bool isSynchronized;
    public bool IsSynchronize
    {
        get
        {
            return isSynchronized;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetObjectToSynchronize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSynchronized)
            GetObjectToSynchronize();
        //Changement de la position en fonction de l'échelle
        this.transform.position = new Vector3(bateauPosition.position.x / scale, bateauPosition.position.y / scale, this.transform.position.z);
        //Changement de la rotation
        Quaternion currentRotation = new Quaternion();
        currentRotation.eulerAngles = bateauPosition.rotation.eulerAngles;
        this.transform.rotation = currentRotation;
    }

    bool GetObjectToSynchronize()
    {
        try
        {
            bateauPosition = GameObject.Find("Bateau_Empty").transform;
        }
        catch (UnityException e)
        {
            Debug.Log("'Bateau_Empty' n'a pas été trouvé. Utilisation de la position de l'objet comme Transform...");
            bateauPosition = this.transform;
            return isSynchronized = false;
        }

        return isSynchronized = true;
    }
}
