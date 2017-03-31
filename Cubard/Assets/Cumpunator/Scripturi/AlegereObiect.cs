using UnityEngine;
using System.Collections;

public class AlegereObiect : MonoBehaviour {


	public GameObject cantitate;
	public int n;
	GenerareObiecte script;


	void Start () 
	{
		script = cantitate.GetComponent<GenerareObiecte>();
	}

	void OnMouseDown()
	{
		script.o = n;
	}
}
