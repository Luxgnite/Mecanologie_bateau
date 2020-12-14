using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GouvernailViewer : MonoBehaviour
{
    public SpriteRenderer barre;
    public SpriteRenderer background;

    public float decouplageAffichageBarre = 3f;
    public float decouplageAffichageBG = 0.5f;
    public float latenceBG = 1f;
    public float detectionThreshold = 3f;


    private float previousZ;
    private GouvernailManager gouvernail;

    private void Start()
    {
        gouvernail = GameManager._instance.GouvernailManager;
    }

    // Update is called once per frame
    void Update()
    {
        barre.transform.localEulerAngles = new Vector3 (
            barre.transform.localEulerAngles.x,
            barre.transform.localEulerAngles.y,
            gouvernail.RotationActuelleGouvernail() * decouplageAffichageBarre);

        if(Mathf.Abs(gouvernail.RotationActuelleGouvernail()) >= detectionThreshold)
        {
            background.transform.localEulerAngles = new Vector3(
                background.transform.localEulerAngles.x,
                background.transform.localEulerAngles.y,
                gouvernail.RotationActuelleGouvernail() * decouplageAffichageBG);
        }
        else if(Mathf.Abs(background.transform.localEulerAngles.z) < 1f)
        {
            background.transform.localEulerAngles = new Vector3(
                background.transform.localEulerAngles.x,
                background.transform.localEulerAngles.y,
                0);

        }

        previousZ = gouvernail.RotationActuelleGouvernail();
    }
}
