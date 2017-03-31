using UnityEngine;
using System.Collections;

public class Tatat : MonoBehaviour {
	
	
	
	float px, py, t, viteza, ax, ay;
	Transform position1;
	Vector2 mouse;
	
	public GameObject caracter;
	public Transform Fata;
	public Transform Spate;
	GameObject PivotCamera, CameraSus, SteaRosie;
	
	public bool ok, okAnim, okW;
	bool axe, constructor, ciocan, okStele;
	
	public Camera MainCamera, CamMate;
	public Material negru;
	public GameObject GNegru, Tata, Cealalta, lumina;
	AproapeToataTreaba script;
	Generator_Harta_Tester gh;
	
	public SpriteRenderer WCiocan, WAxe, WConstructor, WMateriale, WPod;
	public SpriteRenderer GCiocan, GAxe, GConstructor, Ghiozdan;
	public SpriteRenderer BGhiozdan, BExit;
	public Transform Pod;
	
	public GameObject Text_Lemn, Text_Piatra, Text_Scor;
	TextMesh Tlemn, Tpiatra, TScor;
	
	Vector3 pozApa;
	GameObject Apa;
	
	float timp;
	
	int lemn, piatra, nrStele = 0;
	
	Animator anim;
	
	
	AudioSource run;
	public GameObject ALemn, APiatra, APod, AHarta, AWarning;
	
	GameObject StartPoint;
	
	
	
	void Awake()
	{
		anim = caracter.GetComponent<Animator>();

		
		px = transform.position.x;
		py = transform.position.z;
		ok = true;
		okW = true;
		okAnim = false;
		okStele = true;
		ax = ay = 0;
		
		script = Cealalta.GetComponent<AproapeToataTreaba>();
		gh = lumina.GetComponent<Generator_Harta_Tester>();
		
		PivotCamera = GameObject.Find("PivotCamera");
		CameraSus = GameObject.Find("CameraSus");
		
		
		Tlemn = Text_Lemn.GetComponent<TextMesh>();
		Tpiatra = Text_Piatra.GetComponent<TextMesh>();
		TScor = Text_Scor.GetComponent<TextMesh>();
		
		run = MainCamera.GetComponent<AudioSource>();
	}
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(0.1f);

		px = transform.position.x;
		py = transform.position.z;
		
		yield return new WaitForSeconds(1);
		
		
		SteaRosie = GameObject.Find("SteaRosie");
		SteaRosie.SetActive(false);
		
	}
	
	void Update()
	{
		Vector3 W = MainCamera.ScreenToWorldPoint(new Vector3(MainCamera.pixelWidth/2, MainCamera.pixelHeight/2, MainCamera.nearClipPlane+3));
		Vector3 E = MainCamera.ScreenToWorldPoint(new Vector3(0, 0, MainCamera.nearClipPlane+3));
		Vector3 G = MainCamera.ScreenToWorldPoint(new Vector3(MainCamera.pixelWidth, 0, MainCamera.nearClipPlane+3));
		
		
		Vector3 S;
		S = new Vector3(MainCamera.orthographicSize * 0.085f,MainCamera.orthographicSize * 0.085f,MainCamera.orthographicSize * 0.085f);
		
		WCiocan.transform.localScale = S;
		WAxe.transform.localScale = S;
		WConstructor.transform.localScale = S;
		WMateriale.transform.localScale = S;
		WPod.transform.localScale = S;
		
		GAxe.transform.localScale = new Vector3(1,1,1);
		GConstructor.transform.localScale = new Vector3(1,1,1);
		GCiocan.transform.localScale = new Vector3(1,1,1);
		Ghiozdan.transform.localScale = S;
		
		BGhiozdan.transform.localScale = S/1.2f;
		BExit.transform.localScale = S/1.2f;
		
		
		WCiocan.transform.position = W;
		WAxe.transform.position = W;
		WConstructor.transform.position = W;
		WMateriale.transform.position = W;
		WPod.transform.position = W;
		
		GAxe.transform.position = W;
		GConstructor.transform.position = W;
		GCiocan.transform.position = W;
		Ghiozdan.transform.position = W;
		
		if(PivotCamera.activeSelf)
		{
			GNegru.transform.position = W;
		}
		
		BGhiozdan.transform.position = G;
		BExit.transform.position = E;
		
		if(WCiocan.gameObject.activeSelf == false && WAxe.gameObject.activeSelf == false && WConstructor.gameObject.activeSelf == false && WMateriale.gameObject.activeSelf == false && WPod.gameObject.activeSelf == false && Ghiozdan.gameObject.activeSelf == false)
			okW = true;
		
		if(nrStele == 5 && okStele)
		{
			okStele = false;
			SteaRosie.SetActive(true);
			
		}
		
		Tlemn.text = "" + lemn;
		Tpiatra.text = "" + piatra;
		
	}
	
	
	IEnumerator FadeOut()
	{
		for(float f = 0; f<=1; f+=0.05f)
		{
			Color c = negru.color;
			c.a = f;
			negru.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		
		Color d = negru.color;
		d.a = 1;
		negru.color = d;
	}
	
	IEnumerator FadeIn()
	{
		for(float f = 0; f<=1; f+=0.05f)
		{
			Color c = negru.color;
			c.a = 1-f;
			negru.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		
		Color d = negru.color;
		d.a = 0;
		negru.color = d;
	}
	
	IEnumerator FadeInPauza()
	{
		CameraSus.transform.position = new Vector3(transform.position.x, CameraSus.transform.position.y, transform.position.z);
		yield return new WaitForSeconds(1);
		
		px = transform.position.x;
		py = transform.position.z;
		PivotCamera.SetActive(false);
		ok = false;
		
		
		for(float f = 0; f<=1; f+=0.05f)
		{
			Color c = negru.color;
			c.a = 1-f;
			negru.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		
		Color d = negru.color;
		d.a = 0;
		negru.color = d;
	}
	
	IEnumerator Pauza()
	{
		ok = false;
		anim.SetFloat("Speed", 0);
		
		StartCoroutine("FadeOut");
		
		yield return new WaitForSeconds(0.1f);
		APod.GetComponent<AudioSource>().Play();
		
		yield return new WaitForSeconds(1);
		Instantiate(Pod, pozApa, Quaternion.Euler(-90,0,0));
		yield return new WaitForSeconds(2);
		
		StartCoroutine("FadeIn");
		
		px = transform.position.x;
		py = transform.position.z;
		ok = true;
	}
	
	IEnumerator Spatef()
	{
		ok = false;
		anim.SetFloat("Speed", 0);
		
		ax = Spate.position.x;
		ay = Spate.position.z;
		
		t = Time.time;
		okAnim = true;
		yield return new WaitForSeconds(0.5f);
		
		GetComponent<Collider>().enabled = true;
		px = transform.position.x;
		py = transform.position.z;
		
		okAnim = false;
		t = Time.time;
		ok = true;
	}
	
	
	void FixedUpdate()
	{
		if(PivotCamera.activeSelf)
		{
			
			Ray raza = MainCamera.ScreenPointToRay(Input.mousePosition);
			
			int layerMask = 1<< 8;
			int UI = 1<< 5;
			
			PivotCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 17, transform.position.z);
			
			
			
			if(Input.GetMouseButtonDown(1))
			{
				mouse.x = Input.mousePosition.x;
			}
			
			if(Input.GetMouseButton(1))
			{
				PivotCamera.transform.eulerAngles += new Vector3(0, (Input.mousePosition.x - mouse.x)/100, 0);
			}
			
			
			run.volume = anim.GetFloat("Speed");
			
			
			
			RaycastHit[] hit1;
			hit1 = Physics.RaycastAll(raza,35,layerMask);
			
			RaycastHit hitUI;
			
			
			if(Physics.Raycast(raza,out hitUI,100,UI) && Input.GetMouseButtonDown(0))
			{
				WPod.gameObject.SetActive(false);
				
				if(hitUI.collider.name == "Da")
				{
					StartCoroutine("Pauza");
					
					lemn--;
					piatra--;
				}
				
				else if(hitUI.collider.name == "Nu")
				{
					StartCoroutine("Spatef");
					Apa.GetComponent<Collider>().enabled = true;
				}
				
				else if(hitUI.collider.name == "BGhiozdan")
				{
					Ghiozdan.gameObject.SetActive(true);
					px = transform.position.x;
					py = transform.position.z;
					okW = false;
					timp = Time.time;
					AWarning.GetComponent<AudioSource>().Play();
				}
				
				else if(hitUI.collider.name == "Ghiozdan2")
				{
					StartCoroutine("FadeOut");
					
					AHarta.GetComponent<AudioSource>().Play();
					StartCoroutine("FadeInPauza");
					
					
					
					
				}
				
			}
			
			if(Input.GetMouseButtonDown(0) && hit1.Length > 0 && okW)
			{
				bool ok3 = false;
				float Min = 10000;

                RaycastHit hit = new RaycastHit();


                foreach (RaycastHit hits in hit1)
				{
					if(hits.collider.name == "Plan(Clone)" || hits.collider.name == "NewCube 1(Clone)")
					{
						if(Min > Vector3.Distance(hits.point, PivotCamera.transform.position))
						{
							Min = Vector3.Distance(hits.point, PivotCamera.transform.position);
							hit = hits;
							ok3 = true;
						}
						
					}
					
				}
				
				
				
				
				
				if(ok3)
				{		
					px = hit.collider.transform.position.x;
					py = hit.collider.transform.position.z;
					t = Time.time;
					
				}		
				
			}
			
			if(ok)
			{
				transform.LookAt(new Vector3(px, transform.position.y, py));
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(px, transform.position.y, py), Time.deltaTime * 4f);
				
				if(Time.time - t + 1.5f < 3)
					viteza = (Time.time - t + 1.5f)/3;
				
				if(transform.position == new Vector3(px, transform.position.y, py))
					viteza = 0;
				
				anim.SetFloat("Speed", viteza);
			}
			
			if(okAnim)
			{
				transform.LookAt(new Vector3(ax, transform.position.y, ay));
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(ax, transform.position.y, ay), Time.deltaTime * 4f);
				
				if(Time.time - t + 1.5f < 3)
					viteza = (Time.time - t + 1.5f)/3;
				
				if(transform.position == new Vector3(ax, transform.position.y, ay))
					viteza = 0;
				
				anim.SetFloat("Speed", viteza);
			}
			
			
			
			if(Input.GetMouseButtonDown(0) && Ghiozdan.gameObject.activeSelf == true && Time.time - timp > 0.1f)
			{
				Ghiozdan.gameObject.SetActive(false);
				px = transform.position.x;
				py = transform.position.z;
			}
			
		}
		
		
	}
	
	
	IEnumerator OnTriggerEnter(Collider other) 
	{
		GetComponent<Collider>().enabled = false;
		
		
		if(other.name == "Trig_Jos(Clone)")
		{
			//foreach(Collider col in colls)
			//{
			//	if(Vector3.Distance(col.transform.position, transform.position) < 30)
			//		col.enabled = false;
			//}
			
			
			ok = false;
			anim.SetFloat("Speed", 0);
			
			
			
			transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			
			
			
			
			
			
			ax = other.transform.position.x;
			ay = other.transform.position.z;
			t = Time.time;
			okAnim = true;
			yield return new WaitForSeconds(0.5f);
			
			
			
			//foreach(Collider col in colls)
			//{
			//	if(Vector3.Distance(col.transform.position, transform.position) < 45)
			//		col.enabled = true;
			//}
			
			GetComponent<Collider>().enabled = true;
			
			okAnim = false;
			t = Time.time;
			ok = true;
			
		}
		
		
		else if(other.name == "Trig_Sus(Clone)")
		{
			
			ok = false;
			anim.SetFloat("Speed", 0);
			
			
			
			
			transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
			
			
			
			
			if((int)other.transform.rotation.eulerAngles.y == 270)
			{
				ax = other.transform.position.x;
				ay = other.transform.position.z - 2;
			}
			
			else if((int)other.transform.rotation.eulerAngles.y == 0)
			{
				ax = other.transform.position.x - 2;
				ay = other.transform.position.z;
			}
			
			else if((int)other.transform.rotation.eulerAngles.y == 90)
			{
				ax = other.transform.position.x;
				ay = other.transform.position.z + 2;
			}
			
			else if((int)other.transform.rotation.eulerAngles.y == 180)
			{
				ax = other.transform.position.x + 2;
				ay = other.transform.position.z;
			}
			
			t = Time.time;
			okAnim = true;
			yield return new WaitForSeconds(0.5f);
			
			
			
			GetComponent<Collider>().enabled = true;
			
			okAnim = false;
			t = Time.time;
			ok = true;
			
		}
		
		
		
		else if(other.name == "Axe(Clone)")
		{
			axe = true;
			WAxe.gameObject.SetActive(true);
			okW = false;
			other.gameObject.SetActive(false);
			GAxe.gameObject.SetActive(true);
			
			AWarning.GetComponent<AudioSource>().Play();
		}
		
		else if(other.name == "Constructor(Clone)")
		{
			constructor = true;
			WConstructor.gameObject.SetActive(true);
			okW = false;
			other.gameObject.SetActive(false);
			GConstructor.gameObject.SetActive(true);
			
			AWarning.GetComponent<AudioSource>().Play();
		}
		
		else if(other.name == "Ciocan(Clone)")
		{
			ciocan = true;
			WCiocan.gameObject.SetActive(true);
			okW = false;
			other.gameObject.SetActive(false);
			GCiocan.gameObject.SetActive(true);
			
			AWarning.GetComponent<AudioSource>().Play();
		}
		
		else if((other.name == "Copac-1(Clone)" || other.name == "Copac-2(Clone)" || other.name == "Copac-3(Clone)" || other.name == "Copac-4(Clone)" || other.name == "Copac-5(Clone)" || other.name == "Copac-6(Clone)" || other.name == "Copac-7(Clone)" || other.name == "Copac-8(Clone)") && axe == true && other.transform.position.y - transform.position.y + 0.8f > -0.05f && other.transform.position.y - transform.position.y + 0.8f < 0.05f)
		{
			ok = false;
			anim.SetFloat("Speed", 0);
			
			StartCoroutine("FadeOut");
			
			yield return new WaitForSeconds(0.3f);
			ALemn.GetComponent<AudioSource>().Play();
			
			yield return new WaitForSeconds(1);
			other.transform.position = new Vector3(1000,1000,1000);
			yield return new WaitForSeconds(3.5f);
			
			StartCoroutine("FadeIn");
			
			px = transform.position.x;
			py = transform.position.z;
			ok = true;
			
			lemn++;
			
		}
		
		else if((other.name == "Roca1(Clone)" || other.name == "Roca2(Clone)" || other.name == "Roca3(Clone)" ) && ciocan == true && other.transform.position.y - transform.position.y + 0.8f > -0.05f && other.transform.position.y - transform.position.y + 0.8f < 0.05f)
		{
			ok = false;
			anim.SetFloat("Speed", 0);
			
			StartCoroutine("FadeOut");
			
			yield return new WaitForSeconds(0.3f);
			APiatra.GetComponent<AudioSource>().Play();
			
			yield return new WaitForSeconds(1);
			other.transform.position = new Vector3(1000,1000,1000);
			yield return new WaitForSeconds(2);
			
			StartCoroutine("FadeIn");
			
			px = transform.position.x;
			py = transform.position.z;
			ok = true;
			
			piatra++;
			
		}
		
		else if(other.name == "SteaGalbena" && other.transform.position.y - transform.position.y + 0.8f > -0.05f && other.transform.position.y - transform.position.y + 0.8f < 0.05f)
		{
			ok = false;
			anim.SetFloat("Speed", 0);
			
			StartCoroutine("FadeOut");
			
			yield return new WaitForSeconds(0.3f);
			//APiatra.audio.Play();
			
			yield return new WaitForSeconds(1);
			other.transform.position = new Vector3(1000,1000,1000);
			yield return new WaitForSeconds(2);
			
			CamMate.enabled = true;
			MainCamera.enabled = false;
			Tata.SetActive(false);
			
			StartCoroutine("FadeIn");
			
			px = transform.position.x;
			py = transform.position.z;
			ok = true;
			
			nrStele++;
			
			
		}
		
		else if(other.name == "SteaRosie" && other.transform.position.y - transform.position.y + 0.8f > -0.05f && other.transform.position.y - transform.position.y + 0.8f < 0.05f)
		{
			ok = false;
			anim.SetFloat("Speed", 0);
			
			StartCoroutine("FadeOut");
			
			yield return new WaitForSeconds(0.3f);
			//APiatra.audio.Play();
			
			yield return new WaitForSeconds(1);
			other.transform.position = new Vector3(1000,1000,1000);
			yield return new WaitForSeconds(2);
			
			TScor.text += " " + script.scor + " puncte.";
			Text_Scor.SetActive(true);
			
			
			px = transform.position.x;
			py = transform.position.z;
			ok = true;
			
			
			
		}
		
		else if((other.name == "Lava(Clone)" || other.name == "Apa(Clone)" ) && constructor == true)
		{
			
			pozApa = other.transform.position;
			okW = false;
			
			px = transform.position.x;
			py = transform.position.z;
			
			other.GetComponent<Collider>().enabled = false;
			Apa = other.gameObject;
			
			if(lemn > 0 && piatra > 0)
			{
				WPod.gameObject.SetActive(true);
				AWarning.GetComponent<AudioSource>().Play();
			}
			
			else
			{
				WMateriale.gameObject.SetActive(true);
				AWarning.GetComponent<AudioSource>().Play();
				other.GetComponent<Collider>().enabled = true;
				ok = false;
				anim.SetFloat("Speed", 0);
				
				ax = Spate.position.x;
				ay = Spate.position.z;
				
				t = Time.time;
				okAnim = true;
				yield return new WaitForSeconds(0.5f);
				
				GetComponent<Collider>().enabled = true;
				px = transform.position.x;
				py = transform.position.z;
				
				okAnim = false;
				t = Time.time;
				ok = true;
			}
			
			
		}
		
		
		else
		{
			ok = false;
			anim.SetFloat("Speed", 0);
			
			ax = Spate.position.x;
			ay = Spate.position.z;
			
			t = Time.time;
			okAnim = true;
			yield return new WaitForSeconds(0.5f);
			
			GetComponent<Collider>().enabled = true;
			px = transform.position.x;
			py = transform.position.z;
			
			okAnim = false;
			t = Time.time;
			ok = true;
			
		}
		
		GetComponent<Collider>().enabled = true;



	}
	
	void OnTriggerStay()
	{
		
	}
	
	
	
	
}
