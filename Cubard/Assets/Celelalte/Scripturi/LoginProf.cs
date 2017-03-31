using UnityEngine;
using System.Collections;

public class LoginProf : MonoBehaviour {
	
	
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
	
	void OnGUI()
	{
		TextNume = GUI.TextField(new Rect(P.x - 250,Screen.height - P.y - 60, 500, 100), TextNume, 40, stil);
	}
	
	
	IEnumerator OnMouseDown()
	{
		WWWForm form = new WWWForm();
		form.AddField("cod", TextNume);
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/LOGINProfesor.php", form);
		
		yield return w;
		
		if(w.text != "0")
		{
			
			PlayerPrefs.SetString("COD", TextNume);
			
			
			StartCoroutine(FadeOut());
			
			Application.LoadLevel("MeniuProf");
		}
		
		
	}
	
	
}
