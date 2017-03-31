using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {
	

	
	void Start()
	{
		WWWForm form = new WWWForm();
		form.AddField("cont", "barbalunga67");

		WWW w = new WWW("http://proiectlica.atwebpages.com/LOGINElev.php", form);
		
		StartCoroutine(check(w));
	}
	
	IEnumerator check(WWW w)
	{
		yield return w;

		print (w.text);

		
	}
	
	
	
	
	
	
	
	
	
	
}
