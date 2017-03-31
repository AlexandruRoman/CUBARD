using UnityEngine;
using System.Collections;

public class Disparitie : MonoBehaviour {
	
	GameObject plan;
	public Material black;

	void Start()
	{
		plan = GameObject.Find("Plane");
	}

	
	IEnumerator OnMouseDown()
	{

		plan.SetActive(true);

		Color cd = Color.black;
		cd.a = 0;
		black.color = cd;
		
		yield return new WaitForSeconds(0.3f);
		
		for(float f = 0; f<=1; f+= 0.02f)
		{
			Color c = Color.black;
			c.a = f;
			black.color = c;
			
			yield return new WaitForSeconds(0.01f);
		}

	}
}
