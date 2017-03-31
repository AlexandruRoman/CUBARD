using UnityEngine;
using System.Collections;

public class VERIFICARE : MonoBehaviour {

	public GameObject[] spatii;
	public SpatiuPunctat[] script;
	public GameObject Meniu;
	GameObject cam;
	GameObject Corect, Gresit;
	AproapeToataTreaba script2;

	Vector3 Adaos;

	bool ok1, okStop, okFinal, okUltim;
	int nr = 0;

	void Start()
	{
		cam = GameObject.Find("Main Camera");
		Corect = GameObject.Find("Corect");
		Gresit = GameObject.Find("Gresit");
		Camera c = cam.GetComponent<Camera>();

		script2 = cam.GetComponent<AproapeToataTreaba>();


		for(int i = 0; i<spatii.Length; i++)
		{
			script[i] = spatii[i].GetComponent<SpatiuPunctat>();
		}

		okStop = true;
		GameObject t = Instantiate(Meniu, c.ScreenToWorldPoint( Vector3.zero), Quaternion.identity) as GameObject;
		t.transform.position -= new Vector3(4.365f, -transform.position.y, -1);

		Vector3 Plus = c.ScreenToWorldPoint(new Vector3(0 , c.pixelHeight, 0));
		Adaos = new Vector3(0, Plus.y, 0) * 2;
	}
	

	IEnumerator SlideSus()
	{
		float y = cam.transform.position.y;
		print(Adaos.y);
		for(float f = y; f<= y + 10; f+= 0.3f)
		{
			cam.transform.position = new Vector3(cam.transform.position.x, f, cam.transform.position.z);
			yield return new WaitForSeconds(0.005f);
		}
		cam.transform.position = new Vector3(cam.transform.position.x, y + 10, cam.transform.position.z);

		okStop = true;
	}

	IEnumerator SlideJos()
	{
		float y = cam.transform.position.y;
		for(float f = y; f>= y -10; f-= 0.3f)
		{
			cam.transform.position = new Vector3(cam.transform.position.x, f, cam.transform.position.z);
			yield return new WaitForSeconds(0.005f);
		}
		cam.transform.position = new Vector3(cam.transform.position.x, y-10, cam.transform.position.z);
		
		okStop = true;
	}

	IEnumerator Urmatoarea()
	{
		yield return new WaitForSeconds(1);

		GameObject[] pico =  GameObject.FindGameObjectsWithTag("pico") as GameObject[];
		for(int i = 0; i<pico.Length; i++)
		{
			pico[i].transform.position = new Vector3(1000,1000,1000);
			yield return new WaitForSeconds(0.03f);
			pico[i].SetActive(false);

		}

		nr++;

		if(okUltim)
		{
			Corect.transform.position = cam.transform.position + new Vector3(0, -10,10 -nr/100f);
			script2.scor += 2;
		}

		else
		{
			Gresit.transform.position = cam.transform.position + new Vector3(0, -10,10  -nr/100f);
			script2.scor -= 1;
		}


		for(int i = 0; i<pico.Length; i++)
		{
			pico[i].transform.position = new Vector3(1000,1000,1000);
			yield return new WaitForSeconds(0.03f);
			pico[i].SetActive(false);
			
		}

		StartCoroutine(SlideJos());

		yield return new WaitForSeconds(2);

		for(int i = 0; i<pico.Length; i++)
		{
			pico[i].transform.position = new Vector3(1000,1000,1000);
			yield return new WaitForSeconds(0.03f);
			pico[i].SetActive(false);
			
		}

		if(okUltim)
			StartCoroutine(SlideJos());

		else
			StartCoroutine(SlideSus());
	}

	void Update()
	{
		ok1 = true;
		okFinal = true;

		for(int i = 0; i<spatii.Length; i++)
		{
			if(script[i].ok == false)
				ok1 = false;

			if(script[i].okFinal == false)
				okFinal = false;
		}

		if(ok1 && okStop)
		{
			okStop = false;
			okUltim = okFinal;
			print (okUltim);
			StartCoroutine("Urmatoarea");
		}


	}




}
