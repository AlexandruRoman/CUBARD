using UnityEngine;
using System.Collections;

public class Manipulare : MonoBehaviour {

	public GameObject obiect;
	public Transform[] P;
	public Transform mic;
	public Camera cam;

	void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


		if(Input.GetMouseButtonDown(0))
		{
			if(hit.collider.name == "Delete")
			{
				obiect.transform.position = new Vector3(0,0,-100);
			}

			if(hit.collider.name == "Plus")
			{
				obiect.transform.localScale *= 1.1f;
			}

			if(hit.collider.name == "Minus")
			{
				obiect.transform.localScale /= 1.1f;
			}



			if(hit.collider.name == "PMare0")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,0);
				mic.transform.position = P[0].transform.position;
			}

			if(hit.collider.name == "PMare1")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,45);
				mic.transform.position = P[1].transform.position;
			}

			if(hit.collider.name == "PMare2")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,90);
				mic.transform.position = P[2].transform.position;
			}

			if(hit.collider.name == "PMare3")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,135);
				mic.transform.position = P[3].transform.position;
			}

			if(hit.collider.name == "PMare4")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,180);
				mic.transform.position = P[4].transform.position;
			}

			if(hit.collider.name == "PMare5")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,225);
				mic.transform.position = P[5].transform.position;
			}

			if(hit.collider.name == "PMare6")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,270);
				mic.transform.position = P[6].transform.position;
			}

			if(hit.collider.name == "PMare7")
			{
				obiect.transform.eulerAngles = new Vector3(0,0,315);
				mic.transform.position = P[7].transform.position;
			}




		}


	}


}
