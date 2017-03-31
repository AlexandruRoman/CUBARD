using UnityEngine;
using System.Collections;

public class SpatiuPunctat : MonoBehaviour {

	public string x;
	public bool ok, okFinal;

	void Start()
	{
		ok = false;
		okFinal = false;
		if(transform.parent.gameObject.name == "Suport_Liber")
			okFinal = true;
	}

	void Update()
	{
		if(transform.parent.gameObject.name == "Suport_Liber")
			ok = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		ok = true;

		if(col.name == x)
			okFinal = true;

		if(transform.parent.gameObject.name == "Suport_Liber")
			okFinal = false;
	}

	void OnTriggerExit2D()
	{
		ok = false;
		okFinal = false;
		if(transform.parent.gameObject.name == "Suport_Liber")
			okFinal = true;
	}

}
