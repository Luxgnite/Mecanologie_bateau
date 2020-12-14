using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GouvernailViewer : MonoBehaviour
{
    public SpriteRenderer barre;
    public SpriteRenderer background;

    // Update is called once per frame
    void Update()
    {
        barre.transform.localEulerAngles = new Vector3 (
            barre.transform.localEulerAngles.x,
            barre.transform.localEulerAngles.y,
            GameManager._instance.GouvernailManager.RotationActuelleGouvernail());
    }
}
