using UnityEngine;
using System.Collections;

public class Clasament : MonoBehaviour {

		
	string sir;
	string[] jucatori, nume, j;
	int[] scor;
	int n = 0;

	public SpriteRenderer sBack, sSus, sJos;

	public GameObject linie;
	public Transform tata;


	IEnumerator Start()
	{
		WWWForm form = new WWWForm();
		string cod = PlayerPrefs.GetString("COD");
		form.AddField("cod", "" + cod);
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/CITIREClasament.php", form);

		yield return w;

		sir = w.text;



		for(int i=0; i<sir.Length; i++)
			if(sir[i] == ':')
				n++;


		jucatori = new string[n];
		nume = new string[n];
		scor = new int[n];
		j = new string[2];


		jucatori = sir.Split(":"[0]);

		for(int i=0; i<n; i++)
		{
			j = jucatori[i].Split("/"[0]);
			nume[i] = j[0];
			int.TryParse(j[1], out scor[i]);
		}


		int aux;
		string a;

		for(int i=0;i<n-1;i++)
		{
			for(int u=i+1; u<n; u++)
			{
				if(scor[i]<scor[u])
				{
					aux = scor[i];
					scor[i] = scor[u];
					scor[u] = aux;

					a = nume[i];
					nume[i] = nume[u];
					nume[u] = a;
				}
			}
		}





		GameObject t;
		TextMesh tm;

		for(int i=0; i<n; i++)
		{

			t = Instantiate(linie, new Vector3(0, 4.5f - i * 0.7f, 0), Quaternion.identity) as GameObject;

			foreach (Transform c in t.transform)
			{
				if(c.name == "Id")
				{
					tm = c.gameObject.GetComponent<TextMesh>();
					tm.text = "" + (i+1);
				}

				if(c.name == "Nume")
				{
					tm = c.gameObject.GetComponent<TextMesh>();
					tm.text = "" + nume[i];
				}

				if(c.name == "Scor")
				{
					tm = c.gameObject.GetComponent<TextMesh>();
					tm.text = "" + scor[i];
				}
			}

			t.transform.parent = tata;


		}

		sBack.transform.position = new Vector3(-GetComponent<Camera>().aspect * 5, 0, 0);
		sJos.transform.position = new Vector3(GetComponent<Camera>().aspect * 5, 0, 0);
		sSus.transform.position = new Vector3(GetComponent<Camera>().aspect * 5, 0, 0);

		tata.position = new Vector3(100,0,0);


	}
}
