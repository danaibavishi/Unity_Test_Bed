using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Control : MonoBehaviour
{

    public OSC osc;
    bool blue;
    // Start is called before the first frame update
    void Start()
    {
        blue = true;
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetButton("Fire1"))
      if (blue)
        {
            GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            blue = false;
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            blue = true;
        }  
    }
}

