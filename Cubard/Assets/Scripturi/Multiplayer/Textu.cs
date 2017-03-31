using UnityEngine;
using System.Collections;

public class Textu : MonoBehaviour {

	public Material MPamant, MIarba, MDrum1, MDrum2, MNisip, MPavele;

	[RPC]
	public void Texturare(int m)
	{
		if(m == 1) GetComponent<Renderer>().material = MPamant;
		else if(m == 2) GetComponent<Renderer>().material = MIarba;
		else if(m == 3) GetComponent<Renderer>().material = MDrum1;
		else if(m == 4) GetComponent<Renderer>().material = MDrum2;
		else if(m == 5) GetComponent<Renderer>().material = MNisip;
		else if(m == 6) GetComponent<Renderer>().material = MPavele;
	}

}
