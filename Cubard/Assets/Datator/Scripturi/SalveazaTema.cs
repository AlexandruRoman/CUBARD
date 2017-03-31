using UnityEngine;
using System.Collections;

public class SalveazaTema : MonoBehaviour {

	public GameObject cam;
	Tema script;


	void Start()
	{
		script = cam.GetComponent<Tema>();
	}

	void OnMouseDown()
	{
		script.tema += gameObject.name;
	}

}
