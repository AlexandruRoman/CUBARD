using UnityEngine;
using System.Collections;

public class IncarcaNivel : MonoBehaviour {


	public string nivel;

	IEnumerator OnMouseDown()
	{
		yield return new WaitForSeconds(1.5f);

		Application.LoadLevel(nivel);
	}

		
}
