using UnityEngine;
using System.Collections;

public class CameraSus : MonoBehaviour {

	Vector3 pozClick, pozCamera;
	public SpriteRenderer Back;

	void Start () 
	{
		pozCamera = GetComponent<Camera>().transform.position;
	}
	




	void Update () 
	{
		Vector3 B = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/2, 0, GetComponent<Camera>().nearClipPlane+3));

		Vector3 S = new Vector3(GetComponent<Camera>().orthographicSize * 0.085f,GetComponent<Camera>().orthographicSize * 0.085f,GetComponent<Camera>().orthographicSize * 0.085f);

		Back.transform.position = B;
		Back.transform.localScale = S;


		if(Input.GetMouseButtonDown(0))
		{
			pozClick = Input.mousePosition;
			pozCamera = GetComponent<Camera>().transform.position;
		}

		if(Input.GetMouseButton(0))
			GetComponent<Camera>().transform.position = pozCamera + new Vector3((Input.mousePosition.y - pozClick.y)/10, 0, -(Input.mousePosition.x - pozClick.x)/10);
	}
}
