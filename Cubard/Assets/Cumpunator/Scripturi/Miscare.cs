using UnityEngine;
using System.Collections;

public class Miscare : MonoBehaviour {


	GameObject principal;
	Manipulare script;
	GameObject cam;
	Camera c;

	Vector3 mouse1, mouse2;
	float t, z;

	void Start () 
	{

		cam = GameObject.Find("Main Camera");
		principal = GameObject.Find("Principal");

		script = principal.GetComponent<Manipulare>();

		c = cam.GetComponent<Camera>();
		z = transform.position.z;
	}

	void OnMouseDown()
	{
		script.obiect = gameObject;
		mouse1 = mouse2 = Input.mousePosition;
		transform.position = new Vector3(transform.position.x,transform.position.y,100 + z);
		t = Time.time;
	}

	void OnMouseDrag()
	{
		if(Time.time - t < 0.05f)
		{
			mouse1 = mouse2 = Input.mousePosition;
		}

		else
		{
		mouse1 = Input.mousePosition;

		transform.position += c.ScreenToWorldPoint(mouse1) - c.ScreenToWorldPoint(mouse2);

		mouse2 = Input.mousePosition;
		}
	}
}
