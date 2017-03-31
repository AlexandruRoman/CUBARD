using UnityEngine;
using System.Collections;

public class CulegeInformatii : MonoBehaviour {

	public GameObject cam;
	Text script;

	void Start()
	{
		script = cam.GetComponent<Text>();
	}

	void OnMouseDown()
	{
		script.info += gameObject.name + " ";

	}
}
