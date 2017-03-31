using UnityEngine;
using System.Collections;

public class AproapeToataTreaba : MonoBehaviour {


	public Collider2D[] NUMERE;
	public GameObject[] GOnumere;
	public GameObject[] Fundaluri;
	public SpriteRenderer black;
	public GameObject CameraCealalta;
	public GameObject tata;
	Camera c;


	public GameObject[] S1_C1;
	public GameObject[] S1_C2;
	public GameObject[] S1_C3_a;
	public GameObject[] S1_C3_b;
	public GameObject[] S1_C4;
	public GameObject[] S1_C5;
	public GameObject[] S1_C6;
	public GameObject[] S1_C7;

	public GameObject[] S2_C1;
	public GameObject[] S2_C2;
	public GameObject[] S2_C3;
	public GameObject[] S2_C4;
	public GameObject[] S2_C5;
	public GameObject[] S2_C6;
	public GameObject[] S2_C7;
	public GameObject[] S2_C8;
	public GameObject[] S2_C9;



	GameObject[] prob, final;


	
	public Transform cotitura;

	GameObject actual;
	bool okcol, okTranzitie;
	string t;

	public int scor;

	IEnumerator Start()
	{

		scor = 0;
		okTranzitie = true;
		c = CameraCealalta.GetComponent<Camera>();


		WWWForm form = new WWWForm();
		form.AddField("cont", PlayerPrefs.GetString("CONT"));
		
		WWW w = new WWW("http://proiectlica.atwebpages.com/CITIRETema.php", form);

		yield return w;

		t = w.text;

		Aranjare();

		Vector3 F = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth, 0, GetComponent<Camera>().nearClipPlane+3));
		Vector3 Plus = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0 , GetComponent<Camera>().pixelHeight, 0));
		Vector3 Adaos = new Vector3(0, Plus.y, 0) * 4;
		
		for(int i = 0; i<25; i++)
		{
			Fundaluri[i].transform.position = F - Adaos * i;
		}

	}




	void Aranjare()
	{
		Vector3 C = GetComponent<Camera>().ScreenToWorldPoint(new Vector3((GetComponent<Camera>().pixelWidth)/2, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3)) + new Vector3(cotitura.localPosition.x, 0, 0)/4;
		Vector3 Plus = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0 , GetComponent<Camera>().pixelHeight, 0));
		Vector3 Adaos = new Vector3(0, Plus.y, 0) * 4;



		if(t[0] == '1')
		{

			if(t[1] == '1')
			{
				prob = new GameObject[S1_C1.Length];

				for(int i=0; i < S1_C1.Length; i++)
				{
					prob[i] = S1_C1[i];
				}
			}

			if(t[1] == '2')
			{
				prob = new GameObject[S1_C2.Length];
				
				for(int i=0; i < S1_C2.Length; i++)
				{
					prob[i] = S1_C2[i];
				}
			}

			if(t[1] == '3')
			{
				if(t[2] == '1')
				{
					prob = new GameObject[S1_C3_a.Length];
					
					for(int i=0; i < S1_C3_a.Length; i++)
					{
						prob[i] = S1_C3_a[i];
					}
				}

				if(t[2] == '2')
				{
					prob = new GameObject[S1_C3_b.Length];
					
					for(int i=0; i < S1_C3_b.Length; i++)
					{
						prob[i] = S1_C3_b[i];
					}
				}

			}

			if(t[1] == '4')
			{
				prob = new GameObject[S1_C4.Length];
				
				for(int i=0; i < S1_C4.Length; i++)
				{
					prob[i] = S1_C4[i];
				}
			}

			if(t[1] == '5')
			{
				prob = new GameObject[S1_C5.Length];
				
				for(int i=0; i < S1_C5.Length; i++)
				{
					prob[i] = S1_C5[i];
				}
			}

			if(t[1] == '6')
			{
				prob = new GameObject[S1_C6.Length];
				
				for(int i=0; i < S1_C6.Length; i++)
				{
					prob[i] = S1_C6[i];
				}
			}

			if(t[1] == '7')
			{
				prob = new GameObject[S1_C7.Length];
				
				for(int i=0; i < S1_C7.Length; i++)
				{
					prob[i] = S1_C7[i];
				}
			}

		}


		else
		{
			if(t[1] == '1')
			{
				prob = new GameObject[S2_C1.Length];
				
				for(int i=0; i < S2_C1.Length; i++)
				{
					prob[i] = S2_C1[i];
				}
			}

			if(t[1] == '2')
			{
				prob = new GameObject[S2_C2.Length];
				
				for(int i=0; i < S2_C2.Length; i++)
				{
					prob[i] = S2_C2[i];
				}
			}

			if(t[1] == '3')
			{
				prob = new GameObject[S2_C3.Length];
				
				for(int i=0; i < S2_C3.Length; i++)
				{
					prob[i] = S2_C3[i];
				}
			}

			if(t[1] == '4')
			{
				prob = new GameObject[S2_C4.Length];
				
				for(int i=0; i < S2_C4.Length; i++)
				{
					prob[i] = S2_C4[i];
				}
			}

			if(t[1] == '5')
			{
				prob = new GameObject[S2_C5.Length];
				
				for(int i=0; i < S2_C5.Length; i++)
				{
					prob[i] = S2_C5[i];
				}
			}

			if(t[1] == '6')
			{
				prob = new GameObject[S2_C6.Length];
				
				for(int i=0; i < S2_C6.Length; i++)
				{
					prob[i] = S2_C6[i];
				}
			}

			if(t[1] == '7')
			{
				prob = new GameObject[S2_C7.Length];
				
				for(int i=0; i < S2_C7.Length; i++)
				{
					prob[i] = S2_C7[i];
				}
			}

			if(t[1] == '8')
			{
				prob = new GameObject[S2_C8.Length];
				
				for(int i=0; i < S2_C8.Length; i++)
				{
					prob[i] = S2_C8[i];
				}
			}

			if(t[1] == '9')
			{
				prob = new GameObject[S2_C9.Length];
				
				for(int i=0; i < S2_C9.Length; i++)
				{
					prob[i] = S2_C9[i];
				}
			}

		}



		final = new GameObject[25];

		for(int i = 0; i < 25; i++)
		{
			final[i] = prob[Random.Range(0, prob.Length - 1)];
			Instantiate(final[i], C - Adaos * i, Quaternion.identity);
		}






	}


	IEnumerator FadeOut()
	{

		yield return new WaitForSeconds(0.5f);
		black.sortingOrder = 100;

		for(float f = 0; f<= 1f; f+= 0.04f)
		{
			Color t = Color.white;
			t.a = f;
			black.color = t;
			
			yield return new WaitForSeconds(0.01f);
		}

		Color b = Color.white;
		b.a = 1;
		black.color = b;

		yield return new WaitForSeconds(2);

		GetComponent<Camera>().enabled = false;
		c.enabled = true;
		tata.SetActive(true);

		Color z = Color.white;
		z.a = 0;
		black.color = z;

		black.sortingOrder = 2;

		okTranzitie = true;
	}




	void Update()
	{



		RaycastHit2D hit = Physics2D.Raycast(GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if(Input.GetMouseButtonDown(0))
		{
			if(hit.collider != null)
			{


				if(hit.collider.name.Contains("Collider"))
				{
					okcol = true;
					for(int i=0; i<10; i++)
					{
						if(hit.collider.name.Contains("" + i))
						{
							actual = Instantiate(GOnumere[i], GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,1), Quaternion.identity) as GameObject;
							actual.name += "pico";
							actual.tag = "pico";
						}

					}
				}

				if(hit.collider.name.Contains("Pref"))
				{
					okcol = true;
					actual = hit.collider.gameObject;
				}

			}

		}

		if(Input.GetMouseButton(0) && okcol == true)
		{
			actual.transform.position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,1); 
		}

		if(Input.GetMouseButtonUp(0))
		{
			okcol = false;
		}


		if(transform.position.y % 100 == -90 && okTranzitie && transform.position.y < -1)
		{
			okTranzitie = false;
			StartCoroutine(FadeOut());

			GameObject[] pico =  GameObject.FindGameObjectsWithTag("pico") as GameObject[];
			for(int i = 0; i<pico.Length; i++)
			{
				pico[i].SetActive(false);
			}
		}


	}


}
