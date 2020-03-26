using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    public OSC osc;

    private Rigidbody rb;

    bool blue;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        blue = true;
    }

	void FixedUpdate ()
	    {
	        float moveHorizontal = Input.GetAxis("Horizontal");
	        float moveVertical = Input.GetAxis ("Vertical");
	   
	        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
	   
	        GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime*2);
	 
	        if (Input.GetButton ("Jump")) 
	        {
          		Vector3 jump = new Vector3 (0.0f, 50.0f, 0.0f);
          		GetComponent<Rigidbody>().AddForce (jump);
			}
			if (Input.GetButton("Fire2")){
			    if (blue)
			        {
			            GetComponent<Renderer>().material.color = new Color(0,0,0);
			            blue = false;
			        }
			    else
			        {
			            GetComponent<Renderer>().material.color = new Color(255,0,0);
			            blue = true;
			        }}
  }
  }

