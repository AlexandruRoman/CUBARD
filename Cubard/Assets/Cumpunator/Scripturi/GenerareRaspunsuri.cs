using UnityEngine;
using System.Collections;

public class GenerareRaspunsuri : MonoBehaviour {
	
	public GameObject[] Toate;
	public GameObject parinte, pivotPrincipal;

	public int o;

	
	
	
	void OnMouseDown()
	{
		(Instantiate(Toate[o], pivotPrincipal.transform.position + new Vector3(0, 0, -1/1000f), Quaternion.identity) as GameObject).transform.parent = parinte.transform;
		
	}
	
	
	
}
