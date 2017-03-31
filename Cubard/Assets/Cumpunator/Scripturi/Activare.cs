using UnityEngine;
using System.Collections;

public class Activare : MonoBehaviour {

	public GameObject activ;

	void OnMouseDown()
	{
		activ.SetActive(true);
	}
}
