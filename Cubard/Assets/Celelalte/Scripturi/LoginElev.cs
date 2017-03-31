using UnityEngine;
using System.Collections;

public class LoginElev : MonoBehaviour {
	

	public GUIStyle stil;
	public Camera cam;
	string TextNume = "";

	public GameObject planBlack;
	public Material negru;
	
	Vector3 P;
	

	
	void Update () 
	{
		P = cam.WorldToScreenPoint(transform.position);

		
		
	}

	IEnumerator FadeOut()
	{
		planBlack.SetActive(true);
		for(float f = 0; f<=1; f+=0.02f)
		{
			Color c = negru.color;
			c.a = f;
			negru.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		
		Color d = negru.color;
		d.a = 1;
		negru.color = d;

		yield return new WaitForSeconds(2f);

		Application.LoadLevel("Meniu");
	}

	void OnGUI()
	{
		TextNume = GUI.TextField(new Rect(P.x - 250,Screen.height - P.y - 60, 500, 100), TextNume, 40, stil);
	}


	IEnumerator OnMouseDown()
	{
		WWWForm form = new WWWForm();
		form.AddField("cont", TextNume);
		PlayerPrefs.SetString("CONT", TextNume);
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/LOGINElev.php", form);
		
		yield return w;

		if(w.text != "0")
		{
			string[] ob = w.text.Split("/"[0]);
			int x;

			int.TryParse(ob[0], out x);

			PlayerPrefs.SetInt("SCOR", x);

			int.TryParse(ob[1], out x);

			PlayerPrefs.SetInt("BANI", x);

			int.TryParse(ob[2], out x);
			
			PlayerPrefs.SetInt("NIVEL", x);

			PlayerPrefs.SetString("COD", ob[3]);

			print(PlayerPrefs.GetString("COD"));


			StartCoroutine(FadeOut());

		}


	}
	
	
}
