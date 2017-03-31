using UnityEngine;
using System.Collections;

public class Imagine : MonoBehaviour {


	public GameObject browser;
	Browser script;


	void Start()
	{
		script = browser.GetComponent<Browser>();
	}

	IEnumerator OnMouseDown()
	{
		yield return new WaitForSeconds(0.5f);
		script.fileBrowser = true;
		script.location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
	}
}
