using UnityEngine;
using System.Collections;

public class Aparitie2 : MonoBehaviour {
	
	public GameObject plan;
	public Material black;
	
	
	IEnumerator Start()
	{
		plan.SetActive(true);
		
		Color cd = Color.black;
		cd.a = 1;
		black.color = cd;
		
		yield return new WaitForSeconds(2);
		
		for(float f = 0; f<=1; f+= 0.02f)
		{
			Color c = Color.black;
			c.a = 1-f;
			black.color = c;
			
			yield return new WaitForSeconds(0.01f);
		}

	}
}
