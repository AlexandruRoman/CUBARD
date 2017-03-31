using UnityEngine;
using System.Collections;

public class CreareRaspuns : MonoBehaviour {


	public GameObject x;

	void OnMouseDown()
	{
		GameObject clona;

		clona = Instantiate(x, transform.position, Quaternion.identity) as GameObject;

		clona.name += "pico";
		clona.tag = "pico";

		Rigidbody2D r;

		if(clona.name.Contains("Bifa") || clona.name.Contains("Adeva") || clona.name.Contains("Fals") || clona.name.Contains("Albastru") || clona.name.Contains("Galben") || clona.name.Contains("Rosu") || clona.name.Contains("Roz") || clona.name.Contains("Verde") || clona.name.Contains("Blue") || clona.name.Contains("Portocaliu"))
		{
			clona.AddComponent<CircleCollider2D>();
		}

		else
		{
			clona.AddComponent<BoxCollider2D>();
		}

		r = clona.AddComponent<Rigidbody2D>() as Rigidbody2D;

		r.fixedAngle = true;
	}




}
