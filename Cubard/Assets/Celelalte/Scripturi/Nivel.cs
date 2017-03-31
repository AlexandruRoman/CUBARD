using UnityEngine;
using System.Collections;

public class Nivel : MonoBehaviour {


	IEnumerator OnMouseDown()
	{
		int n;

		int.TryParse(gameObject.name, out n);

		PlayerPrefs.SetInt("MAX", 16);
		PlayerPrefs.SetInt("NIVELASTA", n);

		yield return new WaitForSeconds(2);

		Application.LoadLevel(gameObject.name);
	}


}
