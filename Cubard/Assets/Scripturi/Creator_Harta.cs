using UnityEngine;
using System.Collections;
using System.IO;

public class Creator_Harta : MonoBehaviour {

	
	public int[,] MatNivele = new int[101,101];
	public int[,] MatCopyNivele = new int[101,101];
	public int[,] MatFixe = new int[101,101];
	public int[,] MatRampe = new int[101,101];
	public int[,] MatTexturi = new int[101,101];
	public int[,] MatLibere = new int[101,101];
	public int[,] MatRotatii = new int[101,101];
	public int[,] MatApa = new int[101,101];
	public int[,] MatDimensiuni = new int[101,3];
    int n, Mod, Item, Rot, f, x1, y1, minApa = 100, cx, cy, ax, ay, Star, StartPoint, EndPoint;
	float t;

	public char Item2;
	public char[,] MatRestul = new char[101,101];
	Transform[,] MatRestul2 = new Transform[101,101];

	Transform[] Clone = new Transform[10001];
	int cln;

	public Transform[] Restul = new Transform[20];
	public Transform[] Copaci = new Transform[8];
	public Transform[] Roci = new Transform[3];
	public Transform[,] MatPlanuri = new Transform[101,101];
	public Transform[,] MatPlanuri2 = new Transform[101,101];
	public Transform[,] MatPlanuri3 = new Transform[101,101];
	public Transform Plan;
	public Transform PlanSus;
	public Transform Cub;
	public Transform Cub2;
	public Transform Rampa;
	public Transform Rampa2;

	public Transform Select;
	
	
	public SpriteRenderer ObiectPrincipal;
	
	
	
	
	
	public Material[] MNumere = new Material[10];
	public Material MStartPoint, MStar, MConstructie, MCiocan, MAxe, MSecera;

	public Material MPamant;
	public Material MIarba;
	public Material MDrum1;
	public Material MDrum2;
	public Material MNisip;
	public Material MPavele;

	public SpriteRenderer SMeniu1;
	public SpriteRenderer SMeniu2;
	public SpriteRenderer SNivele2;
	public SpriteRenderer STexturi;
	public SpriteRenderer SZoom;
	public SpriteRenderer SVegetatie;
	public SpriteRenderer SKey;

	public GameObject WStele;
	
	public Collider CMeniu1_Key;
	public Collider CMeniu1_Vegetatie;
	public Collider CMeniu1_Paint;
	public Collider CMeniu1_Nivele;


	public Collider CMeniu2_Move;
	public Collider CMeniu2_Zoom;
	public Collider CMeniu2_Delete;
	public Collider CMeniu2_Next;
	public Collider CMeniu2_Exit;
	
	public Collider CCopac;
	public Collider CTufis;
	public Collider CApa;
	public Collider CRoca;
	public Collider CFoc;
	public Collider CButuruga;

	public Collider[] CNumere = new Collider[10];
	public Collider CTexturi_Pamant;
	public Collider CTexturi_Iarba;
	public Collider CTexturi_Drum1;
	public Collider CTexturi_Drum2;
	public Collider CTexturi_Pavele;
	public Collider CTexturi_Nisip;

	public Collider CKey_Star, CKey_Start, CKey_Constructie, CKey_Ciocan, CKey_Axe, CKey_Secera;

	public Collider CPlus, CMinus;
	public Collider CNefixe, CFixe;


	Vector3 pozClick, pozCamera;

	
	void Start()
	{
		Initial();
		Refresh();
		Reset();
	}



	void Update()
	{

		Vector3 M = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/10, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 M2 = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth*9/10, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 V = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/2, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));;
		Vector3 N2 = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/2, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 T = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/2, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 Z = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/2, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 K = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/2, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));

		Vector3 S;
		S = new Vector3(GetComponent<Camera>().orthographicSize * 0.085f,GetComponent<Camera>().orthographicSize * 0.085f,GetComponent<Camera>().orthographicSize * 0.085f);

		SMeniu1.transform.localScale = S;
		SMeniu2.transform.localScale = S;
		SNivele2.transform.localScale = S;
		STexturi.transform.localScale = S;
		SZoom.transform.localScale = S;
		SVegetatie.transform.localScale = S;
		SKey.transform.localScale = S;

		SMeniu1.transform.position = M;
		SMeniu2.transform.position = M2;
		SNivele2.transform.position = N2;
		STexturi.transform.position = T;
		SZoom.transform.position = Z;
		SVegetatie.transform.position = V;
		SKey.transform.position = K;


		Ray raza = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		RaycastHit[] hits;
		bool ok = false;

		hits = Physics.RaycastAll(raza, 70);



		if(Input.GetMouseButtonDown(0))
		{

			int i;

			if(hits.Length == 2)
				t = Time.time;


			for(i=0; i<hits.Length; i++)
			{


				if(hits[i].distance < 5)
					ok = true;
			
				if(hits[i].collider == CMeniu2_Next)
				{
					//if(Star == 5 && StartPoint == 1)

					//else
						//WStele.SetActive(true);
				}

				if(hits[i].collider == CMeniu2_Exit)
				{

				}
				
				
				if(hits[i].collider == CMeniu2_Move)
				{
					Reset();
					Mod = 4;
				}

				if(hits[i].collider == CMeniu2_Zoom)
				{
					Reset();
					SZoom.gameObject.SetActive(true);
				}

				if(hits[i].collider == CMeniu2_Delete)
				{
					Reset();
					Mod = 3;
					Item2 = 'z';
				}

				if(hits[i].collider == CPlus)
				{
					GetComponent<Camera>().orthographicSize-= 3;
				}

				if(hits[i].collider == CMinus)
				{
					GetComponent<Camera>().orthographicSize+= 3;
				}

				if(hits[i].collider == CMeniu1_Key)
				{
					Reset();
					SKey.gameObject.SetActive(true);
				}

				if(hits[i].collider == CKey_Star)
				{
					Reset();
					Mod = 3;
					Item2 = 's';
				}

				if(hits[i].collider == CKey_Start)
				{
					Reset();
					Mod = 3;
					Item2 = 't';
				}

				if(hits[i].collider == CKey_Constructie)
				{
					Reset();
					Mod = 3;
					Item2 = 'k';
				}

				if(hits[i].collider == CKey_Ciocan)
				{
					Reset();
					Mod = 3;
					Item2 = 'l';
				}

				if(hits[i].collider == CKey_Axe)
				{
					Reset();
					Mod = 3;
					Item2 = 'm';
				}

				if(hits[i].collider == CKey_Secera)
				{
					Reset();
					Mod = 3;
					Item2 = 'n';
				}
				
				
				
				if(hits[i].collider == CMeniu1_Paint)
				{
					Reset();
					Mod = 2;
					Item = 1;
					STexturi.gameObject.SetActive(true);
				}

				if(hits[i].collider == CMeniu1_Vegetatie)
				{
					Reset();
					SVegetatie.gameObject.SetActive(true);
					Mod = 3;
					Item2 = 'z';
				}

				if(hits[i].collider == CCopac)
				{
					SVegetatie.gameObject.SetActive(false);
					Item2 = 'y';
				}
				
				if(hits[i].collider == CTufis)
				{
					SVegetatie.gameObject.SetActive(false);
					Item2 = 'a';
				}

				if(hits[i].collider == CFoc)
				{
					SVegetatie.gameObject.SetActive(false);
					Item2 = 'c';
				}

				if(hits[i].collider == CButuruga)
				{
					SVegetatie.gameObject.SetActive(false);
					Mod = 5;
					Item = 2;
				}
				
				if(hits[i].collider == CApa)
				{
					SVegetatie.gameObject.SetActive(false);
					Mod = 5;
					Item = 1;
				}
				
				if(hits[i].collider == CRoca)
				{
					SVegetatie.gameObject.SetActive(false);
					Item2 = 'x';
				}

				if(hits[i].collider == CTexturi_Pamant)
				{
					Item = 1;
					STexturi.gameObject.SetActive(false);
				}

				if(hits[i].collider == CTexturi_Iarba)
				{
					Item = 2;
					STexturi.gameObject.SetActive(false);
				}

				if(hits[i].collider == CTexturi_Drum1)
				{
					Item = 3;
					STexturi.gameObject.SetActive(false);
				}

				if(hits[i].collider == CTexturi_Drum2)
				{
					Item = 4;
					STexturi.gameObject.SetActive(false);
				}

				if(hits[i].collider == CTexturi_Nisip)
				{
					Item = 5;
					STexturi.gameObject.SetActive(false);
				}

				if(hits[i].collider == CTexturi_Pavele)
				{
					Item = 6;
					STexturi.gameObject.SetActive(false);
				}

				if(hits[i].collider == CMeniu1_Nivele)
				{
					Reset();
					SNivele2.gameObject.SetActive(true);
					Mod = 1;
					Item = 0;
				}



				for(int j=0;j<10;j++)
					if(hits[i].collider == CNumere[j])
					{
						SNivele2.gameObject.SetActive(false);
						Item = j;
					}



			}
		}

		int a,b,x3,y3,i3,j3;


		if(Input.GetMouseButtonDown(0))
		{
			pozClick = Input.mousePosition;
			pozCamera = GetComponent<Camera>().transform.position;
			x1 = (int)hits[0].transform.position.x/2;
			y1 = (int)hits[0].transform.position.z/2;
			ax = x1;
			ay = y1;

			if(Mod == 5 && Time.time - t > 1)
			{
				a = (int)hits[0].transform.position.x/2;
				b = (int)hits[0].transform.position.z/2;

				for(int i = 0;i<n;i++)
					for(int j = 0;j<n;j++)
						MatApa[i,j] = 0;

				minApa = 10;
				Apa(a, b, MatNivele[a,b]);

				for(int i = 0;i<n;i++)
					for(int j = 0;j<n;j++)
						MatApa[i,j] = 0;

				print (minApa);

				if(minApa > MatNivele[a,b])
					Apa2(a, b, minApa - 1);

				ScriereMatrice();

			}


		}

		if(hits.Length > 0)
		{
			cx = (int)hits[0].transform.position.x/2;
			cy = (int)hits[0].transform.position.z/2;
		}


		if(Input.GetMouseButton(0) && (cx != ax || cy != ay) && Time.time - t > 1 && Mod != 4)
		{
			for(i3 = 0; i3<n; i3++)
				for(j3 = 0; j3<n; j3++)
					MatPlanuri3[i3,j3].gameObject.SetActive(false);
			
			ax = cx;
			ay = cy;
			
			for(i3 = Mathf.Min(x1,cx); i3 <= Mathf.Max(x1,cx); i3++)
			{
				
				for(j3 = Mathf.Min(y1,cy); j3 <= Mathf.Max(y1,cy); j3++)
				{
					MatPlanuri3[i3,j3].gameObject.SetActive(true);
				}
			}
			
			
			
		}



		if(ok == false && hits.Length == 1 && Input.GetMouseButtonUp(0) && Time.time - t > 0.7f)
		{
			x3 = (int)hits[0].transform.position.x/2;
			y3 = (int)hits[0].transform.position.z/2;

			for(i3 = 0; i3<n; i3++)
				for(j3 = 0; j3<n; j3++)
					MatPlanuri3[i3,j3].gameObject.SetActive(false);


			if(Mod == 1)
			{
				for(i3 = Mathf.Min(x1,x3); i3 <= Mathf.Max(x1,x3); i3++)
				{
					
					for(j3 = Mathf.Min(y1,y3); j3 <= Mathf.Max(y1,y3); j3++)
					{
						a = i3;
						b = j3;
						MatFixe[a,b] = f;
						MatCopyNivele[a,b] = Item;

					}
				}

				Refresh();
			}
					
			else if(Mod == 2)
			{
				for(i3 = Mathf.Min(x1,x3); i3 <= Mathf.Max(x1,x3); i3++)
				{
					
					for(j3 = Mathf.Min(y1,y3); j3 <= Mathf.Max(y1,y3); j3++)
					{
						a = i3;
						b = j3;
						MatTexturi[a,b] = Item;
					}
				}
				TexturarePlanuri2();
				ScriereMatrice();
			}
					
			else if(Mod == 3)
			{
				for(i3 = Mathf.Min(x1,x3); i3 <= Mathf.Max(x1,x3); i3++)
				{
					
					for(j3 = Mathf.Min(y1,y3); j3 <= Mathf.Max(y1,y3); j3++)
					{
						a = i3;
						b = j3;
						if(Item2 == 'z')
						{
							
							if(MatRestul2[a,b] != null)
								MatRestul2[a,b].transform.position = new Vector3(1000, 1000, 1000);

							if(MatRestul[a,b] == 's')
								Star--;
							if(MatRestul[a,b] == 't')
								StartPoint = 0;
							if(MatRestul[a,b] == 'n')
								EndPoint = 0;
							MatRestul[a,b] = Item2;
							MatLibere[a,b] = 0;
						}
						
						else if(VerificarePozitionareObiect(a,b, MatDimensiuni[Item2 - 'a',0], MatDimensiuni[Item2 - 'a',1], Rot) == 1)
						{
							MatRestul[a,b] = Item2;
							MatRotatii[a,b] = Rot;
							MatLibere[a,b] = 1;
							if(MatRestul[a,b] != 'z' && MatRestul[a,b] != 'y' && MatRestul[a,b] != 'x')
							{
								MatRestul2[a,b] = Instantiate(Restul[MatRestul[a,b] - 'a'], new Vector3(a*2, MatNivele[a,b], b*2), Quaternion.Euler(270, 0, MatRotatii[a,b]*90)) as Transform;
							}
							
							if(MatRestul[a,b] == 'y')
							{
								MatRestul2[a,b] = Instantiate(Copaci[Random.Range(0,7)], new Vector3(a*2, MatNivele[a,b], b*2), Quaternion.Euler(270, 0, MatRotatii[a,b]*90)) as Transform;
							}
							
							if(MatRestul[a,b] == 'x')
							{
								MatRestul2[a,b] = Instantiate(Roci[Random.Range(0,2)], new Vector3(a*2, MatNivele[a,b], b*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90)) as Transform;
							}

							if(MatRestul[a,b] == 's' && Star == 5)
							{
								MatRestul[a,b] = 'z';
								MatLibere[a,b] = 0;
							}
							
							if(MatRestul[a,b] == 's' && Star < 5)
							{
								Star++;
								MatPlanuri[a,b].GetComponent<Renderer>().material = MStar;
							}


							if(MatRestul[a,b] == 't' && StartPoint == 1)
							{
								MatRestul[a,b] = 'z';
								MatLibere[a,b] = 0;
							}
							
							if(MatRestul[a,b] == 't' && StartPoint == 0)
							{
								StartPoint = 1;
								MatPlanuri[a,b].GetComponent<Renderer>().material = MStartPoint;
							}

							
							if(MatRestul[a,b] == 'k')
							{
								MatPlanuri[a,b].GetComponent<Renderer>().material = MConstructie;

							}

							if(MatRestul[a,b] == 'l')
							{
								MatPlanuri[a,b].GetComponent<Renderer>().material = MCiocan;
							}

							if(MatRestul[a,b] == 'm')
							{
								MatPlanuri[a,b].GetComponent<Renderer>().material = MAxe;
							}

							if(MatRestul[a,b] == 'n' && EndPoint == 1)
							{
								MatRestul[a,b] = 'z';
								MatLibere[a,b] = 0;
							}

							if(MatRestul[a,b] == 'n' && EndPoint == 0)
							{
								MatPlanuri[a,b].GetComponent<Renderer>().material = MSecera;
								EndPoint = 1;
							}
						} 
					}
				}

					


				TexturarePlanuri();
				ScriereMatrice();
			}



		}

		if(Input.GetMouseButton(0))
		{
			if(Mod == 4)
			{
				GetComponent<Camera>().transform.position = pozCamera + new Vector3((Input.mousePosition.y - pozClick.y)/10, 0, -(Input.mousePosition.x - pozClick.x)/10);
			}
		}


	}




	void Reset()
	{
		Mod = 10;
		SNivele2.gameObject.SetActive(false);
		STexturi.gameObject.SetActive(false);
		SZoom.gameObject.SetActive(false);
		SVegetatie.gameObject.SetActive(false);
		SKey.gameObject.SetActive(false);
	}

	void Initial()
	{
		int i,j;

		n=50;
		Item = 5;
		Mod = 1;
		Rot = 2;
		Item2 = 'y';
		cln = 0;
		f = 1;
		Star = StartPoint = EndPoint = 0;

		x1 = y1 = 0;
		cx = cy = 0;
		ax = ay = 0;

		pozCamera = GetComponent<Camera>().transform.position;

		CitireMatrice();

		for(i=0;i<=n;i++)
		{
			for(j=0;j<=n;j++)
			{
				MatDimensiuni[i,0] = 1;
				MatDimensiuni[i,1] = 1;
				MatRampe[i,j] = 0;
				MatNivele[i,j] = 1;
		

			}
		}

		for(i=0;i<n;i++)
		{
			for(j=0;j<n;j++)
			{
				if(MatRestul[i,j] == 's')
					Star++;
				if(MatRestul[i,j] == 't')
					StartPoint = 1;
				if(MatRestul[i,j] == 'n')
					EndPoint = 1;
			}
		}
		
		





		GenerarePlanuri();
		GenerarePlanuri2();
		GenerarePlanuri3();
		TexturarePlanuri2();
		GenerareRestul();

	}

	public void Refresh()
	{
		int i,j;
		Distruge ();
		cln = 0;



		for(i=0;i<n;i++)
		{
			for(j=0;j<n;j++)
			{
				if(MatRestul[i,j] != 'z')
					MatLibere[i,j] = 1;

				else
					MatLibere[i,j] = 0;

				MatRampe[i,j] = 0;
				MatNivele[i,j] = MatCopyNivele[i,j];
			}
		}

		
		//GenerareCuburi();
		//GenerareRestul();

		TexturarePlanuri();

		ScriereMatrice();
	}

	void Distruge()
	{ 
		int i;
		for(i = 1; i<=cln; i++)
			Destroy(Clone[i].gameObject);
	}

	void InitializareMatrice()
	{
		int i,j;

		for(i=0;i<n;i++)
		{
			for(j=0;j<n;j++)
			{
				MatCopyNivele[i,j] = 0;
				MatRestul[i,j] = 'z';
				MatTexturi[i,j] = 1;
				MatFixe[i,j] = 0;
				MatRotatii[i,j] = 0;
				MatLibere[i,j] = 0;
			}
		}

	}

	void CitireMatrice()
	{
		FileInfo theSourceFile = null;
		StreamReader reader = null;
		
		theSourceFile = new FileInfo (Application.persistentDataPath + "/Harta.txt");

		if ( theSourceFile != null && theSourceFile.Exists )
			reader = theSourceFile.OpenText();
		
		if(reader == null)
		{
			InitializareMatrice();
			ScriereMatrice();
		}

		else
		{
		
			string txt = reader.ReadLine();
			n = int.Parse(txt);
			
			
			for(int i=0; i<n; i++)
			{
				txt = reader.ReadLine();
				
				for(int j=0; j<n; j++)
				{
					MatCopyNivele[i,j] = int.Parse("" + txt[2*j]);
				}
			}

			txt = reader.ReadLine();

			for(int i=0; i<n; i++)
			{
				txt = reader.ReadLine();
				
				for(int j=0; j<n; j++)
				{
					MatFixe[i,j] = int.Parse("" + txt[2*j]);
				}
			}

			txt = reader.ReadLine();

			for(int i=0; i<n; i++)
			{
				txt = reader.ReadLine();
				
				for(int j=0; j<n; j++)
				{
					MatTexturi[i,j] = int.Parse("" + txt[2*j]);
				}
			}

			txt = reader.ReadLine();
			
			for(int i=0; i<n; i++)
			{
				txt = reader.ReadLine();
				
				for(int j=0; j<n; j++)
				{
					MatRestul[i,j] = txt[2*j];
				}
			}

			txt = reader.ReadLine();
			
			for(int i=0; i<n; i++)
			{
				txt = reader.ReadLine();
				
				for(int j=0; j<n; j++)
				{
					MatRotatii[i,j] = int.Parse("" + txt[2*j]);
				}
			}

			txt = reader.ReadLine();
			
			for(int i=0; i<n; i++)
			{
				txt = reader.ReadLine();
				
				for(int j=0; j<n; j++)
				{
					MatLibere[i,j] = int.Parse("" + txt[2*j]);
				}
			}

			reader.Close();

		}
	}


	void ScriereMatrice()
	{
		FileInfo theSourceFile = null;
		StreamWriter writer = null;
		
		theSourceFile = new FileInfo (Application.persistentDataPath + "/Harta.txt");
		writer = theSourceFile.CreateText();
		
		
		
		
		
		writer.WriteLine(n);
		
		for(int i=0; i<n; i++)
		{
			for(int j=0; j<n; j++)
			{
				writer.Write(MatCopyNivele[i,j] + " ");
			}
			
			writer.WriteLine();
		}
		
		writer.WriteLine();
		
		for(int i=0; i<n; i++)
		{
			for(int j=0; j<n; j++)
			{
				writer.Write(MatFixe[i,j] + " ");
			}
			
			writer.WriteLine();
		}
		
		writer.WriteLine();
		
		for(int i=0; i<n; i++)
		{
			for(int j=0; j<n; j++)
			{
				writer.Write(MatTexturi[i,j] + " ");
			}
			
			writer.WriteLine();
		}
		
		writer.WriteLine();
		
		for(int i=0; i<n; i++)
		{
			for(int j=0; j<n; j++)
			{
				writer.Write(MatRestul[i,j] + " ");
			}
			
			writer.WriteLine();
		}

		writer.WriteLine();
		
		for(int i=0; i<n; i++)
		{
			for(int j=0; j<n; j++)
			{
				writer.Write(MatRotatii[i,j] + " ");
			}
			
			writer.WriteLine();
		}

		writer.WriteLine();
		
		for(int i=0; i<n; i++)
		{
			for(int j=0; j<n; j++)
			{
				writer.Write(MatLibere[i,j] + " ");
			}
			
			writer.WriteLine();
		}

		
		
		writer.Flush();
		writer.Close();
	}





	void GenerareCuburi()
	{
		int i,j;
		
		for(i=0; i<n; i++)
		{
			
			for(j=0; j<n; j++)
			{
				CreareCub(i,j,MatNivele[i,j]);
			}
		}
	}

	void CreareCub(int x, int y, int tip)
	{
		if(MatRestul[x,y] != 'z')
			MatLibere[x,y] = 1;
		else
			MatLibere[x,y] = 0;


		for(int i=0; i<tip; i++)
			Texturare(Clone[++cln] = Instantiate(Cub, new Vector3(x*2, i, y*2), Quaternion.Euler(270,0,0)) as Transform, x, y);
		

		if(tip == 0)
			Texturare(Clone[++cln] = Instantiate(Plan, new Vector3(x*2, 0, y*2), Quaternion.Euler(270,0,0)) as Transform, x, y);
		
	}

	void Texturare(Transform obiect, int x, int y)
	{
		if(MatTexturi[x,y] == 1) obiect.GetComponent<Renderer>().material = MPamant;
		else if(MatTexturi[x,y] == 2) obiect.GetComponent<Renderer>().material = MIarba;
		else if(MatTexturi[x,y] == 3) obiect.GetComponent<Renderer>().material = MDrum1;
		else if(MatTexturi[x,y] == 4) obiect.GetComponent<Renderer>().material = MDrum2;
		else if(MatTexturi[x,y] == 5) obiect.GetComponent<Renderer>().material = MNisip;
		else if(MatTexturi[x,y] == 6) obiect.GetComponent<Renderer>().material = MPavele;
	}
	

	

	void GenerarePlanuri()
	{
		int i,j;

		for(i=0; i<n; i++)
			for(j=0; j<n; j++)
				MatPlanuri[i,j] = Instantiate(PlanSus, new Vector3(i*2, 30, j*2), Quaternion.Euler(270, 90, 0)) as Transform;
	}

	void GenerarePlanuri2()
	{
		int i,j;
		
		for(i=0; i<n; i++)
			for(j=0; j<n; j++)
				MatPlanuri2[i,j] = Instantiate(PlanSus, new Vector3(i*2, 0, j*2), Quaternion.Euler(270, 90, 0)) as Transform;
	}

	void GenerarePlanuri3()
	{
		int i,j;
		
		for(i=0; i<n; i++)
			for(j=0; j<n; j++)
				MatPlanuri3[i,j] = Instantiate(Select, new Vector3(i*2, 40, j*2), Quaternion.Euler(270, 90, 0)) as Transform;
	}

	void TexturarePlanuri()
	{
		int i,j;

		for(i=0; i<n; i++)
		{
			for(j=0; j<n; j++)
			{
				MatPlanuri[i,j].GetComponent<Renderer>().material = MNumere[ MatNivele[i,j] ];

				if(MatRestul[i,j] == 's')
					MatPlanuri[i,j].GetComponent<Renderer>().material = MStar;

				if(MatRestul[i,j] == 't')
					MatPlanuri[i,j].GetComponent<Renderer>().material = MStartPoint;

				if(MatRestul[i,j] == 'k')
					MatPlanuri[i,j].GetComponent<Renderer>().material = MConstructie;

				if(MatRestul[i,j] == 'l')
					MatPlanuri[i,j].GetComponent<Renderer>().material = MCiocan;

				if(MatRestul[i,j] == 'm')
					MatPlanuri[i,j].GetComponent<Renderer>().material = MAxe;

				if(MatRestul[i,j] == 'n')
					MatPlanuri[i,j].GetComponent<Renderer>().material = MSecera;

			}
		}
				
	}

	void TexturarePlanuri2()
	{
		int i,j;
		
		for(i=0; i<n; i++)
		{
			for(j=0; j<n; j++)
			{
				Texturare(MatPlanuri2[i,j], i, j);
			}
		}
		
	}



	public int VerificarePozitionareObiect(int x, int y, int a, int b, int r)
	{
		int i,j;
		if(r == 3)
			for(i=x; i<x+b; i++)
				for(j=y-a+1; j<=y; j++)
					if(MatLibere[i,j] == 1)
						return 0;


		if(r == 2)
			for(i=x; i<x+a; i++)
				for(j=y; j<y+b; j++)
					if(MatLibere[i,j] == 1)
						return 0;

		if(r == 1)
			for(i=x-b+1; i<=x; i++)
				for(j=y; j<y+a; j++)
					if(MatLibere[i,j] == 1)
						return 0;
		
		
		if(r == 4)
			for(i=x-a+1; i<=x; i++)
				for(j=y-b+1; j<=y; j++)
					if(MatLibere[i,j] == 1)
						return 0;



		if(r == 3)
			for(i=x; i<x+b; i++)
				for(j=y-a+1; j<=y; j++)
					MatLibere[i,j] = 1;

		
		
		if(r == 2)
			for(i=x; i<x+a; i++)
				for(j=y; j<y+b; j++)
					MatLibere[i,j] = 1;
			
		
		if(r == 1)
			for(i=x-b+1; i<=x; i++)
				for(j=y; j<y+a; j++)
					MatLibere[i,j] = 1;
		
		
		if(r == 4)
			for(i=x-a+1; i<=x; i++)
				for(j=y-b+1; j<=y; j++)
					MatLibere[i,j] = 1;


		return 1;
	}

	void RotireObiect()
	{
		Rot++;
		Rot = Rot % 4 + 1;

		ObiectPrincipal.transform.Rotate(0,0,90);
	}

	void GenerareRestul()
	{
		int i,j;
		
		for(i=0; i<n; i++)
		{
			for(j=0; j<n; j++)
			{
				if(MatRestul[i,j] != 'z' && MatRestul[i,j] != 'y' && MatRestul[i,j] != 'x' && MatRestul[i,j] != 'b' && MatRestul[i,j] != 'd')
				{
					MatRestul2[i,j] = Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, MatRotatii[i,j]*90)) as Transform;
				}
				
				if(MatRestul[i,j] == 'y')
				{
					MatRestul2[i,j] = Instantiate(Copaci[Random.Range(0,8)], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, MatRotatii[i,j]*90)) as Transform;
				}
				
				
				if(MatRestul[i,j] == 'x')
				{
					MatRestul2[i,j] = Instantiate(Roci[Random.Range(0,2)], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90)) as Transform;
					
				}
				
				if(MatRestul[i,j] == 'b')
				{
					MatRestul2[i,j] = Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90)) as Transform;
					
				}

				if(MatRestul[i,j] == 'd')
				{
					MatRestul2[i,j] = Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90)) as Transform;
					
				}
				
				
				
			}
		}
		
	}


	void Apa(int i, int j, int niv)
	{
		if(MatNivele[i,j] != niv)
		{
			if(MatNivele[i,j] < minApa)
				minApa = MatNivele[i,j];
		}

		else if( i < n-1 && i > 0 && j < n-1 && j > 0)
		{
			MatApa[i,j] = 1;


			if(MatApa[i-1,j] == 0) Apa(i-1, j, niv);


			if(MatApa[i,j-1] == 0) Apa(i, j-1, niv);
			if(MatApa[i,j+1] == 0) Apa(i, j+1, niv);


			if(MatApa[i+1,j] == 0) Apa(i+1, j, niv);

		}
	}


	void Apa2(int i, int j, int niv)
	{
		MatApa[i,j] = 1;
		
		if(MatNivele[i,j] == MatNivele[x1,y1])
		{
			if(MatRestul2[i,j] != null)
				MatRestul2[i,j].transform.position = new Vector3(1000, 1000, 1000);
			if(Item == 1)
			{
				MatRestul2[i,j] = Instantiate(Restul[1], new Vector3(i*2, niv, j*2), Quaternion.Euler(270, 0, MatRotatii[i,j]*90)) as Transform;
				MatRestul[i,j] = 'b';
			}
			if(Item == 2)
			{
				MatRestul2[i,j] = Instantiate(Restul[3], new Vector3(i*2, niv, j*2), Quaternion.Euler(270, 0, MatRotatii[i,j]*90)) as Transform;
				MatRestul[i,j] = 'd';
			}
			MatFixe[i,j] = niv;
			print (niv);

			if(i>0)
				if(MatApa[i-1,j] == 0)   Apa2(i-1, j, niv);

			if(j>0)
				if(MatApa[i,j-1] == 0) Apa2(i, j-1, niv);

			if(j<n-1)
				if(MatApa[i,j+1] == 0) Apa2(i, j+1, niv);

			if(i<n-1)
				if(MatApa[i+1,j] == 0)   Apa2(i+1, j, niv);

		}
	}


}
