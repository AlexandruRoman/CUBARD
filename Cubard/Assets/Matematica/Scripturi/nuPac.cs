using UnityEngine;
using System.Collections;

public class nuPac : MonoBehaviour {

	SpriteRenderer black;
	GameObject cam;

	float x;
	
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(1f);

		cam = GameObject.Find("Main Camera");

		Camera c = cam.GetComponent<Camera>();

		x = c.ScreenToWorldPoint(new Vector3(0,0,0)).x;

		print (x);

		GameObject b = GameObject.Find("nEGRU");

		black = b.GetComponent<SpriteRenderer>();
		
	}
	
	void Update()
	{
		if(Time.time > 1.5f)
		{
			if(transform.parent.position.x - 0.5f < x && transform.parent.position.x + 0.5f > x)
			{
				GetComponent<Collider2D>().enabled = true;
			}
			
			else
			{
				GetComponent<Collider2D>().enabled = false;
			}
		}
		
		
	}


	IEnumerator Fade()
	{
		for(float f = 0.6f; f>= 0; f-= 0.04f)
		{
			Color c = Color.white;
			c.a = f;
			black.color = c;
			
			yield return new WaitForSeconds(0.001f);
		}
		
	}
	
	IEnumerator Slide()
	{
		Transform t = transform.parent.transform;
		float i;
		i = t.position.x;
		for(float f = i; f>= i - 4.365f; f-= 0.3f)
		{
			t.position = new Vector3(f, t.position.y, t.position.z);
			yield return new WaitForSeconds(0.001f);
		}
		
	}

	void OnMouseDown()
	{
		StartCoroutine(Fade ());
		StartCoroutine(Slide ());
		
		
	}

}
