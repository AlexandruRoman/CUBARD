using UnityEngine;
using System.Collections;

public class SalvareScor : MonoBehaviour {


	IEnumerator Start()
	{
		WWWForm form = new WWWForm();
		form.AddField("cont", "barbalunga67");
		form.AddField("scor", "566");
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/SALVAREScor.php", form);
		
		yield return w;
	}


}
