using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlip : MonoBehaviour
{
    float xVal;
    float yVal;
    float zVal;
    bool flipped;
    bool reset;
    int mode;
    public GameObject ClassCube;
    public Light YellowLight;
    public Light BlueLight;
    int upsideDown;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Update",0f,10f);
        zVal = 0f;
        mode = 1;
        BlueLight.enabled = false;
        if (Vector3.Dot(ClassCube.transform.up, Vector3.down) > 0) {
            upsideDown = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        zVal = ClassCube.transform.localEulerAngles.z;
        //Debug.Log("X: "+ClassCube.transform.localEulerAngles.x+"Y: "+ClassCube.transform.localEulerAngles.y+"Z: "+ClassCube.transform.localEulerAngles.z);
        //Debug.Log("X: "+ClassCube.transform.localEulerAngles.x);
        if (Vector3.Dot(ClassCube.transform.up, Vector3.down) > 0) {
            //updateText();
            upsideDown = 1;
        }
        
        if ((Vector3.Dot(ClassCube.transform.up, Vector3.down) < 0) & upsideDown == 1){
            //updateText();
            upsideDown = 0;
            Debug.Log("Flipped");
            mode = mode*-1;
        }
        if (mode == 1)
        {
            YellowLight.enabled = true;
            BlueLight.enabled = false;
        }
        else if (mode == -1)
        {
            YellowLight.enabled = false;
            BlueLight.enabled = true;
        }

    }
}
