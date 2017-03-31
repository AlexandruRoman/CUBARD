using UnityEngine;
using System.Collections;

public class GenerareObiecte : MonoBehaviour {

	public GameObject[] Toate;
	int n;
	public GameObject cam, parinte, pivotPrincipal, browser;
	Text script;
	Browser script2;
	int nr = 0;

	public int o;

	void Start () 
	{
		script = cam.GetComponent<Text>();
		script2 = browser.GetComponent<Browser>();
	}



	void OnMouseDown()
	{
		if(o < 30)
		{
			if(int.TryParse(script.TextCantitate, out n) && n < 101)
			{
				for(int i=1; i<=n%10; i++)
				{
					nr++;
					(Instantiate(Toate[o], pivotPrincipal.transform.position + new Vector3(0, 0, -nr/1000f), Quaternion.identity) as GameObject).transform.parent = parinte.transform;
				}

				for(int i=1; i<=n/10; i++)
				{
					nr++;
					(Instantiate(Toate[o + 60], pivotPrincipal.transform.position + new Vector3(0, 0, -nr/1000f), Quaternion.identity) as GameObject).transform.parent = parinte.transform;
				}
			}
		}

		else if(o==100)
		{
			if(int.TryParse(script.TextCantitate, out n) && n < 11)
			{
				script2.Pac(n);
			}
		}

		else
		{
			if(int.TryParse(script.TextCantitate, out n) && n < 11)
			{
				for(int i=1; i<=n; i++)
				{
					nr++;
					(Instantiate(Toate[o], pivotPrincipal.transform.position + new Vector3(0, 0, -nr/1000f), Quaternion.identity) as GameObject).transform.parent = parinte.transform;
				}
			}
		}

		script.TextCantitate = "1";

	}



}
