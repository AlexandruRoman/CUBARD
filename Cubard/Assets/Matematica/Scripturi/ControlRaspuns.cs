using UnityEngine;
using System.Collections;

public class ControlRaspuns : MonoBehaviour {

	public bool ok = true;
	public GameObject cam;
	Camera c;

	void Start()
	{
		cam = GameObject.Find("Main Camera");

		c = cam.GetComponent<Camera>();
	}




	void OnMouseDown()
	{
		ok = true;
	}
	

	void Update()
	{
		if(Input.GetMouseButtonUp(0))
			ok = false;

		if(ok)
			transform.position = c.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,1);
	}

}

