using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{



	Transform cam;	
	public Transform caracter;


	void Start()
	{
		
		cam = GameObject.Find ("CameraSpate").transform;


		
	}
	
	void FixedUpdate ()
	{
		
		transform.position = Vector3.Lerp(transform.position, cam.position, Time.deltaTime * 5);
		cam.LookAt(caracter.position);
		transform.forward = Vector3.Lerp(transform.forward, cam.forward, Time.deltaTime * 5);
		

		
	}
}
