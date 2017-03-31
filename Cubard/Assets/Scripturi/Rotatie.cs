using UnityEngine;
using System.Collections;

public class Rotatie : MonoBehaviour {
	


	void Update ()
	{
		transform.Rotate(new Vector3(0,0,1), 30 * Time.deltaTime);
	}
}
