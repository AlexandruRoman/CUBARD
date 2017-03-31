using UnityEngine;
using System.Collections;

public class Navigare : MonoBehaviour {

	public GameObject Urmatorul;
	public GameObject[] Restul;
	public Material negru;
	public GameObject planBlack;



	IEnumerator FadeOut()
	{
		planBlack.SetActive(true);
		for(float f = 0; f<=1; f+=0.05f)
		{
			Color c = negru.color;
			c.a = f;
			negru.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		
		Color d = negru.color;
		d.a = 1;
		negru.color = d;
	}

	IEnumerator FadeIn()
	{
		for(float f = 0; f<=1; f+=0.05f)
		{
			Color c = negru.color;
			c.a = 1-f;
			negru.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		
		Color d = negru.color;
		d.a = 0;
		negru.color = d;

		planBlack.SetActive(false);
	}

	void Hide()
	{
		for(int i=0; i < Restul.Length; i++)
		{
			Restul[i].transform.position = new Vector3(100, 0, -100);
		}

		Urmatorul.transform.position = Vector3.zero;
	}

	IEnumerator OnMouseDown()
	{
		StartCoroutine("FadeOut");
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("FadeIn");
		Hide();

	}


}
