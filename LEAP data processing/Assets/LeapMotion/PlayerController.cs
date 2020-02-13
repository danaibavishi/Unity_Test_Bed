using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    public OSC osc;
    bool blue;
    private Rigidbody rb;

    void Start ()
    {
        blue = true;
        rb = GetComponent<Rigidbody>();
        osc.SetAddressHandler("/Cleaning_wave", Jump);
        osc.SetAddressHandler("/Finger_point", Change_color);
    }

	void FixedUpdate ()
	    {
	        float moveHorizontal = Input.GetAxis("Horizontal");
	        float moveVertical = Input.GetAxis ("Vertical");
	   
	        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
	   
	        GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	 
	    }
   	void Jump (OscMessage message)
   		{
   		    Vector3 jump = new Vector3 (0.0f, 200.0f, 0.0f);
	        GetComponent<Rigidbody>().AddForce (jump);
   		    }
    void Change_color(OscMessage message)
    {
        if (blue)
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            blue = false;
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            blue = true;
        }
    }
}
    

