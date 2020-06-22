using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class Change_Ground_Color : MonoBehaviour
{
//Setup parameters to connect to Arduino
  public static SerialPort sp = new SerialPort("/dev/cu.usbmodem14101");
	public int message2;
	public int det_thres;
	private float updatePeriod = 0.0f;
 	

    // Use this for initialization
    void Start (){
    	OpenConnection();
      GetComponent<Renderer>().material.color = new Color(0, 0, 255);
    }
 
    void Update()
    {
		updatePeriod+=Time.deltaTime;
		if(updatePeriod>0.2f){
			//StartCoroutine(ReadInfo);
			message2 = int.Parse(sp.ReadLine());
			print (message2);
			if(message2>10 && message2<det_thres){
				GetComponent<Renderer>().material.color = new Color(0, 255, 0);
			}
			else{
				GetComponent<Renderer>().material.color = new Color(0, 0, 255);
			}
		updatePeriod = 0.0f;	
		}
		
    }

	
	
    //Function connecting to Arduino
    public void OpenConnection() 
    {
       if (sp != null) 
       {
         if (sp.IsOpen) 
         {
          sp.Close();
          print("Closing port, because it was already open!");
				//message = "Closing port, because it was already open!";
         }
         else 
         {
          sp.Open();  // opens the connection
          sp.ReadTimeout = 1000;  // sets the timeout value before reporting error
          print("Port Opened!");
		//		message = "Port Opened!";
         }
       }
       else 
       {
         if (sp.IsOpen)
         {
          print("Port is already open");
         }
         else 
         {
          print("Port == null");
         }
       }
    }
 
    void OnApplicationQuit() 
    {
       sp.Close();
    }
}
