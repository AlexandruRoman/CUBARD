using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour {

	public Material negru;
	public GameObject planBlack;
	public GameObject cam;
	Tema script;


	void Start()
	{
		script = cam.GetComponent<Tema>();
	}
	
	
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

		Application.LoadLevel("MeniuProf");
	}

	IEnumerator OnMouseDown()
	{

		StartCoroutine(FadeOut());
		yield return new WaitForSeconds(0.5f);

		WWWForm form = new WWWForm();
		form.AddField("cod", "COD");
		form.AddField("cap", script.tema);
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/SALVARETema.php", form);
		
		yield return w;

	}
}
