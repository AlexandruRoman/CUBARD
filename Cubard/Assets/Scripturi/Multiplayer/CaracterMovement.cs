using UnityEngine;
using System.Collections;

public class CaracterMovement : MonoBehaviour {

	

	float px, py, t, viteza, ax, ay;
	Transform position1;
	Vector2 mouse;

	public GameObject caracter;
	public Transform Fata;
	public Transform Spate;
	GameObject PivotCamera;

	public bool ok, okAnim;

	Animator anim;

	void Start()
	{
		anim = caracter.GetComponent<Animator>();
		px = transform.position.x;
		py = transform.position.z;
		ok = true;
		okAnim = false;
		ax = ay = 0;

		PivotCamera = GameObject.Find("PivotCamera");
	}


	void FixedUpdate()
	{
		if(GetComponent<NetworkView>().isMine)

		{

			Ray raza = Camera.main.ScreenPointToRay(Input.mousePosition);

			int layerMask = 1<< 8;

			PivotCamera.transform.position = new Vector3(transform.position.x, PivotCamera.transform.position.y, transform.position.z);



			if(Input.GetMouseButtonDown(1))
			{
				mouse.x = Input.mousePosition.x;
			}

			if(Input.GetMouseButton(1))
			{
				PivotCamera.transform.eulerAngles += new Vector3(0, (Input.mousePosition.x - mouse.x)/100, 0);
			}





			RaycastHit[] hit1;
			hit1 = Physics.RaycastAll(raza,100,layerMask);

			if(Input.GetMouseButtonDown(0) && hit1.Length > 0)
			{
				bool ok3 = false;
				float Min = 10000;

				RaycastHit hit = new RaycastHit();


				foreach(RaycastHit hits in hit1)
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


		}





	}


	IEnumerator OnTriggerEnter(Collider other) 
	{
		GetComponent<Collider>().enabled = false;

		if(other.name != "Trig(Clone)" && other.name != "Trig_Jos(Clone)" && other.name != "Trig_Sus(Clone)")
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

		else if(other.name == "Trig_Jos(Clone)")
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

	



	}




}
