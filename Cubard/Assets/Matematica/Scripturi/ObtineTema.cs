using UnityEngine;
using System.Collections;

public class ObtineTema : MonoBehaviour {
	
	
	
	void Start()
	{
		WWWForm form = new WWWForm();
		form.AddField("cont", "barbalunga67");
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/CITIRETema.php", form);
		
		StartCoroutine(check(w));
	}
	
	IEnumerator check(WWW w)
	{
		yield return w;
		
		print (w.text);
		
		
	}
	
	
	
	
	
	
	
	
	
	
}
