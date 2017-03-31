using UnityEngine;
using System.Collections;

public class GenerareScris : MonoBehaviour {

	public GameObject cam, principal, PrefScris, pivotPrincipal;
	Text script;

	void Start()
	{
		script = cam.GetComponent<Text>();
	}

	void OnMouseDown()
	{
		GameObject scris;
		TextMesh t;

		scris = Instantiate(PrefScris, pivotPrincipal.transform.position + new Vector3(0, 0, -1), Quaternion.identity) as GameObject;
		scris.transform.parent = principal.transform;

		t = scris.GetComponent<TextMesh>();

		t.text = script.TextText;
		scris.AddComponent<BoxCollider2D>();

	}



}
