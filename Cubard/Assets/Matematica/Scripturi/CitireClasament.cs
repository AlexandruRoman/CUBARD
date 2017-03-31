using UnityEngine;
using System.Collections;

public class CitireClasament : MonoBehaviour {

	void Start()
	{
		WWWForm form = new WWWForm();
		form.AddField("cod", "COD");
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/CITIREClasament.php", form);
		
		StartCoroutine(check(w));
	}
	
	IEnumerator check(WWW w)
	{
		yield return w;
		
		print (w.text);
		
		
	}
}
