using UnityEngine;
using System.Collections;

public class CameraBack : MonoBehaviour {

	public GameObject tester;
	public GameObject pivot;
	Tatat script;

	public GameObject Negru;
	public Material negru;
	public Camera CamSus;




	IEnumerator FadeOut()
	{
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
	}


	void Start()
	{
		script = tester.GetComponent<Tatat>();
	}

	void Update()
	{
		Vector3 N = CamSus.ScreenToWorldPoint(new Vector3(CamSus.pixelWidth/2, CamSus.pixelWidth/2, CamSus.nearClipPlane+3));

		Negru.transform.position = N;



	}

	IEnumerator OnMouseDown()
	{
		StartCoroutine("FadeOut");
		yield return new WaitForSeconds(1);
		StartCoroutine("FadeIn");

		pivot.SetActive(true);
		script.ok = true;


	}
}
