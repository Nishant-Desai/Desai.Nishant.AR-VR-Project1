using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge_lightFlip : MonoBehaviour
{
    float xVal;
    float yVal;
    float zVal;
    bool flipped;
    bool reset;
    int mode;
    public GameObject MergeCube;
    public Light OrangeLight;
    public Light RedLight;
    int upsideDown;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Update", 0f, 10f);
        zVal = 0f;
        mode = 1;
        RedLight.enabled = false;
        if (Vector3.Dot(MergeCube.transform.up, Vector3.down) > 0)
        {
            upsideDown = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {

        zVal = MergeCube.transform.localEulerAngles.z;
        //Debug.Log("X: "+ClassCube.transform.localEulerAngles.x+"Y: "+ClassCube.transform.localEulerAngles.y+"Z: "+ClassCube.transform.localEulerAngles.z);
        //Debug.Log("X: "+ClassCube.transform.localEulerAngles.x);
        if (Vector3.Dot(MergeCube.transform.up, Vector3.down) > 0)
        {
            //updateText();
            upsideDown = 1;
        }

        if ((Vector3.Dot(MergeCube.transform.up, Vector3.down) < 0) & upsideDown == 1)
        {
            //updateText();
            upsideDown = 0;
            Debug.Log("Flipped");
            mode = mode * -1;
        }
        if (mode == 1)
        {
            OrangeLight.enabled = true;
            RedLight.enabled = false;
        }
        else if (mode == -1)
        {
            OrangeLight.enabled = false;
            RedLight.enabled = true;
        }

    }
}
