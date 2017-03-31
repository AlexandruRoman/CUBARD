using UnityEngine;
using System.Collections;

public class Nivele : MonoBehaviour {


	public GameObject nivel;
	public Sprite gri, galben;
	public Transform tata, p1, p2, p3;
	Vector3 sd, sj;
	int n;

	public SpriteRenderer sBack;

	void Start()
	{
		sd = p2.position - p1.position;
		sj = p3.position - p1.position;

		
		n = PlayerPrefs.GetInt("NIVEL");



		for(int i=0; i<n; i++)
		{
			GameObject g;

			if(i%7 < 4)
			{
				g = Instantiate(nivel, p1.position + (i%7)*sd + new Vector3(0, (i/7)*sj.y*2, 0), Quaternion.identity) as GameObject;
				foreach (Transform c in g.transform)
				{
					TextMesh tm;
					tm = c.gameObject.GetComponent<TextMesh>();
					tm.text = "" + (i+1);
				}
			}

			else
			{
				g = Instantiate(nivel, p1.position + (i%7 - 4)*sd + new Vector3(sj.x, (i/7)*sj.y*2 + sj.y, 0), Quaternion.identity) as GameObject;
				foreach (Transform c in g.transform)
				{
					TextMesh tm;
					tm = c.gameObject.GetComponent<TextMesh>();
					tm.text = "" + (i+1);
				}
			}

			if(i==n-1)
			{
				SpriteRenderer sp;
				sp = g.GetComponent<SpriteRenderer>();
				sp.sprite = gri;
			}

			g.name = "" + (i+1);
			g.transform.parent = tata;

		}

		sBack.transform.position = new Vector3(-GetComponent<Camera>().aspect * 5, 0, 0);

		tata.position = new Vector3(100, 0, 0);


	}




}
