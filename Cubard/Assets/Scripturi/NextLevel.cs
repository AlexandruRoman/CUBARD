using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string level;
	public float n;
	public Camera cam;

	void Update()
	{
		Ray raza = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(raza, out hit, 10) && Input.GetMouseButtonDown(0) && hit.collider == GetComponent<Collider>())
		{
			Application.LoadLevel(level);
			print (level);
		}

		transform.localScale = new Vector3(cam.orthographicSize * 0.085f,cam.orthographicSize * 0.085f,cam.orthographicSize * 0.085f);

		transform.position = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth - cam.pixelWidth/12, cam.pixelHeight/n, cam.nearClipPlane+3));

	}


}
