using UnityEngine;
using System.Collections;

public class Tranzitie : MonoBehaviour {

	public SpriteRenderer sp1, sp2;

	public Sprite[] img;
	GameObject cam;

	int t;

	IEnumerator Start()
	{
		cam = GameObject.Find("Main Camera");

		Camera c = cam.GetComponent<Camera>();


		sp1.transform.position = new Vector3(c.aspect * 5 + 0.05f, -5, 0);
		sp2.transform.position = new Vector3(c.aspect * 5 + 0.05f, -5, 0);

		t = 20;

		int n = Random.Range(0, img.Length - 1);
		
		sp1.sprite = img[n];

		yield return new WaitForSeconds(t);

		StartCoroutine(pac1 ());
	}


	IEnumerator pac1()
	{
		int n = Random.Range(0, img.Length - 1);

		sp2.sprite = img[n];

		for(float f = 0; f<=1; f+= 0.02f)
		{
			Color c = Color.white;
			c.a = 1-f;
			sp1.color = c;
			c.a = f;
			sp2.color = c;

			yield return new WaitForSeconds(0.01f);
		}

		yield return new WaitForSeconds(t);


		StartCoroutine(pac2());


	}


	IEnumerator pac2()
	{
		int n = Random.Range(0, img.Length - 1);
		
		sp1.sprite = img[n];
		
		for(float f = 0; f<=1; f+= 0.02f)
		{
			Color c = Color.white;
			c.a = 1-f;
			sp2.color = c;
			c.a = f;
			sp1.color = c;
			
			yield return new WaitForSeconds(0.01f);
		}
		
		yield return new WaitForSeconds(t);
		
		
		StartCoroutine(pac1());
		
		
	}

}
