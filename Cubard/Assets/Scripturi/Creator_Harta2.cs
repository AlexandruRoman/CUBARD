using UnityEngine;
using System.Collections;
using System.IO;

public class Creator_Harta2 : MonoBehaviour {
	
	
	public int[,] MatNivele = new int[101,101];
	public int[,] MatCopyNivele = new int[101,101];
	public int[,] MatFixe = new int[101,101];
	public int[,] MatRampe = new int[101,101];
	public int[,] MatTexturi = new int[101,101];
	public int[,] MatLibere = new int[101,101];
	public int[,] MatRotatii = new int[101,101];
	public int[,] MatDimensiuni = new int[101,3];
	int n, Mod, Item, Rot, f;
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
	public Transform Plan;
	public Transform PlanSus;
	public Transform Cub;
	public Transform Cub2;
	public Transform Rampa;
	public Transform Rampa2;
	public Transform Nimic;
	
	
	public SpriteRenderer ObiectPrincipal;
	
	
	
	
	
	public Material[] MNumere = new Material[10];
	public Material MStop;
	
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
	
	public Collider CMeniu1_Move;
	public Collider CMeniu1_Zoom;
	public Collider CMeniu1_Paint;
	public Collider CMeniu1_Nivele;
	
	public Collider CMeniu2_Move;
	public Collider CMeniu2_Zoom;
	public Collider CMeniu2_Delete;
	public Collider CMeniu2_Key;
	public Collider CMeniu2_Vegetatie;

	public Collider CCopac;
	public Collider CTufis;
	public Collider CApa;
	public Collider CRoca;
	
	public Collider[] CNumere = new Collider[10];
	public Collider CTexturi_Pamant;
	public Collider CTexturi_Iarba;
	public Collider CTexturi_Drum1;
	public Collider CTexturi_Drum2;
	public Collider CTexturi_Pavele;
	public Collider CTexturi_Nisip;
	
	public Collider CPlus, CMinus;
	
	
	Vector3 pozClick, pozCamera;
	
	
	void Start()
	{
		Initial();
		Refresh();
		Reset();
	}
	
	
	
	void Update()
	{
		
		Vector3 M = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/12, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 V = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/3.75f, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 N2 = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/3.5f, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 T = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/3.6f, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		Vector3 Z = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth/4.5f, GetComponent<Camera>().pixelHeight/2, GetComponent<Camera>().nearClipPlane+3));
		
		
		Vector3 S;
		S = new Vector3(GetComponent<Camera>().orthographicSize * 0.085f,GetComponent<Camera>().orthographicSize * 0.085f,GetComponent<Camera>().orthographicSize * 0.085f);
		
		SMeniu1.transform.localScale = S;
		SMeniu2.transform.localScale = S;
		SNivele2.transform.localScale = S;
		STexturi.transform.localScale = S;
		SZoom.transform.localScale = S;
		SVegetatie.transform.localScale = S;
		
		
		SMeniu1.transform.position = M;
		SMeniu2.transform.position = M;
		SNivele2.transform.position = N2;
		STexturi.transform.position = T;
		SZoom.transform.position = Z;
		SVegetatie.transform.position = V;
		
		
		
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
				
				if(hits[i].collider == CPlus)
				{
					GetComponent<Camera>().orthographicSize--;
				}
				
				if(hits[i].collider == CMinus)
				{
					GetComponent<Camera>().orthographicSize++;
				}

				
				if(hits[i].collider == CMeniu1_Paint)
				{
					Reset();
					Mod = 2;
					Item = 1;
					STexturi.gameObject.SetActive(true);
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

				if(hits[i].collider == CMeniu2_Delete)
				{
					Reset();
					Mod = 3;
					Item2 = 'z';
				}

				if(hits[i].collider == CMeniu2_Vegetatie)
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

				if(hits[i].collider == CApa)
				{
					SVegetatie.gameObject.SetActive(false);
					Item2 = 'b';
				}
				
				if(hits[i].collider == CRoca)
				{
					SVegetatie.gameObject.SetActive(false);
					Item2 = 'x';
				}
				
				
				
			}
		}
		
		int a,b;
		
		if(Input.GetMouseButtonDown(0))
		{
			pozClick = Input.mousePosition;
			pozCamera = GetComponent<Camera>().transform.position;
		}
		
		
		if(ok == false && hits.Length == 1 && Input.GetMouseButton(0) && Time.time - t > 0.3f)
		{
			a = (int)hits[0].transform.position.x/2;
			b = (int)hits[0].transform.position.z/2;
			
			
			
			if(Mod == 1)
			{
				MatFixe[a,b] = f;
				MatCopyNivele[a,b] = Item;
				Refresh();
			}
			
			else if(Mod == 2)
			{
				MatTexturi[a,b] = Item;
			}
			
			else if(Mod == 3)
			{

				if(Item2 == 'z' && MatRestul2[a,b] != null)
				{


					Destroy(MatRestul2[a,b].GetComponent<Renderer>());
					MatRestul[a,b] = Item2;
					MatLibere[a,b] = 0;
					ScriereMatrice();
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
					
					ScriereMatrice();
					
				} 
			}
			
			else if(Mod == 4)
			{
				GetComponent<Camera>().transform.position = pozCamera + new Vector3((Input.mousePosition.y - pozClick.y)/10, 0, -(Input.mousePosition.x - pozClick.x)/10);
			}
			
		}
		
	}
	
	void Reset()
	{
		Mod = 10;
		SVegetatie.gameObject.SetActive(false);
		SNivele2.gameObject.SetActive(false);
		STexturi.gameObject.SetActive(false);
		SZoom.gameObject.SetActive(false);
	}
	
	void Initial()
	{
		int i,j;
		
		n=40;
		Item = 5;
		Mod = 1;
		Rot = 2;
		Item2 = 'y';
		cln = 0;
		f = 1;
		
		pozCamera = GetComponent<Camera>().transform.position;
		
		CitireMatrice();
		
		for(i=0;i<n;i++)
		{
			for(j=0;j<n;j++)
			{
				MatDimensiuni[i,0] = 1;
				MatDimensiuni[i,1] = 1;
				MatRampe[i,j] = 0;
				
				
				
			}
		}
		
		
		MatDimensiuni[0,0] = 1;
		MatDimensiuni[0,1] = 1;
		
		
		
		
		
		
		
		
		GenerarePlanuri();
		
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
		
		Nivelare();
		
		GenerareCuburi();
		GenerareRestul();
		
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
	
	
	void Nivelare()
	{
		int i,j,k;
		
		for(k=1;k<=10;k++)
			
			for(i=1; i<n-1; i++)
		{
			
			for(j=1; j<n-1; j++)
			{
				if(MatFixe[i,j] == 0)
				{
					if(MatNivele[i-1, j-1] < MatNivele[i, j] && MatFixe[i-1, j-1] == 0) MatNivele[i-1, j-1] = MatNivele[i, j]-1;
					if(MatNivele[i-1, j] < MatNivele[i, j] && MatFixe[i-1, j] == 0)   MatNivele[i-1, j] =   MatNivele[i, j]-1;
					if(MatNivele[i-1, j+1] < MatNivele[i, j] && MatFixe[i-1, j+1] == 0) MatNivele[i-1, j+1] = MatNivele[i, j]-1;
					if(MatNivele[i, j-1] < MatNivele[i, j] && MatFixe[i, j-1] == 0)   MatNivele[i, j-1] =   MatNivele[i, j]-1;
					if(MatNivele[i, j+1] < MatNivele[i, j] && MatFixe[i, j+1] == 0)   MatNivele[i, j+1] =   MatNivele[i, j]-1;
					if(MatNivele[i+1, j-1] < MatNivele[i, j] && MatFixe[i+1, j-1] == 0) MatNivele[i+1, j-1] = MatNivele[i, j]-1;
					if(MatNivele[i+1, j] < MatNivele[i, j] && MatFixe[i+1, j] == 0)   MatNivele[i+1, j] =   MatNivele[i, j]-1;
					if(MatNivele[i+1, j+1] < MatNivele[i, j] && MatFixe[i+1, j+1] == 0) MatNivele[i+1, j+1] = MatNivele[i, j]-1;
				}
			}
		}
	}
	
	void GenerareRampe_1()
	{
		int i,j;
		
		for(i=0; i<n; i++)
		{
			
			for(j=0; j<n; j++)
			{
				if(MatFixe[i,j] == 0)
				{
					if(j-2>=0)
						if( (MatFixe[i, j-1] == 0) && (MatNivele[i, j-1] == MatNivele[i,j] - 1) && (MatNivele[i, j-2] < MatNivele[i,j]) && (MatRampe[i,j-1] == 0) )
					{
						MatLibere[i,j-1] = 1;
						Texturare(Clone[++cln] = Instantiate(Rampa, new Vector3(i*2, MatNivele[i,j] - 1, j*2 - 2), Quaternion.Euler(270,0,-90)) as Transform , i, j-1);
						MatRampe[i,j-1] = 1;
						MatPlanuri[i, j-1].GetComponent<Renderer>().material = MStop;
					}
					
					if(j+2<n)
						if( (MatFixe[i, j+1] == 0) && (MatNivele[i, j+1] == MatNivele[i,j] - 1) && (MatNivele[i, j+2] < MatNivele[i,j]) && (MatRampe[i,j+1] == 0) )
					{
						MatLibere[i,j+1] = 1;
						Texturare(Clone[++cln] = Instantiate(Rampa, new Vector3(i*2, MatNivele[i,j] - 1, j*2 + 2), Quaternion.Euler(270,0,90)) as Transform, i, j+1);
						MatRampe[i,j+1] = 3;
						MatPlanuri[i, j+1].GetComponent<Renderer>().material = MStop;
					}
					
					if(i-2>=0)
						if( (MatFixe[i-1, j] == 0) && (MatNivele[i-1, j] == MatNivele[i,j] - 1) && (MatNivele[i-2, j] < MatNivele[i,j]) && (MatRampe[i-1,j] == 0) )
					{
						MatLibere[i-1,j] = 1;
						Texturare(Clone[++cln] = Instantiate(Rampa, new Vector3(i*2 - 2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0)) as Transform, i-1, j);
						MatRampe[i-1,j] = 2;
						MatPlanuri[i-1, j].GetComponent<Renderer>().material = MStop;
					}
					
					if(i+2<n)
						if( (MatFixe[i+1, j] == 0) && (MatNivele[i+1, j] == MatNivele[i,j] - 1) && (MatNivele[i+2, j] < MatNivele[i,j]) && (MatRampe[i+1,j] == 0) )
					{
						MatLibere[i+1,j] = 1;
						Texturare(Clone[++cln] = Instantiate(Rampa, new Vector3(i*2 + 2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,180)) as Transform, i+1, j);
						MatRampe[i+1,j] = 4;
						MatPlanuri[i+1, j].GetComponent<Renderer>().material = MStop;
					}
					
				}
			}
		}
	}
	
	void GenerareRampe_2()
	{		
		int i,j;
		
		for(i=1; i<n-1; i++)
		{
			
			for(j=1; j<n-1; j++)
			{
				if(MatRampe[i+1,j] == 1 && MatRampe[i,j+1] == 2)
				{
					MatLibere[i,j] = 1;
					Texturare(Clone[++cln] = Instantiate(Rampa2, new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270,0,-90)) as Transform, i, j);
					MatPlanuri[i, j].GetComponent<Renderer>().material = MStop;
				}
				
				if(MatRampe[i+1,j] == 3 && MatRampe[i,j-1] == 2)
				{	
					MatLibere[i,j] = 1;
					Texturare(Clone[++cln] = Instantiate(Rampa2, new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270,0,0)) as Transform, i, j);
					MatPlanuri[i, j].GetComponent<Renderer>().material = MStop;
				}
				
				if(MatRampe[i-1,j] == 3 && MatRampe[i,j-1] == 4)
				{
					MatLibere[i,j] = 1;
					Texturare(Clone[++cln] = Instantiate(Rampa2, new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270,0,90)) as Transform, i, j);
					MatPlanuri[i, j].GetComponent<Renderer>().material = MStop;
				}
				
				if(MatRampe[i-1,j] == 1 && MatRampe[i,j+1] == 4)
				{
					MatLibere[i,j] = 1;
					Texturare(Clone[++cln] = Instantiate(Rampa2, new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270,0,180)) as Transform, i, j);
					MatPlanuri[i, j].GetComponent<Renderer>().material = MStop;
				}
			}
		}
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
	

	
	void TexturarePlanuri()
	{
		int i,j;
		
		for(i=0; i<n; i++)
		{
			for(j=0; j<n; j++)
			{
				if(MatLibere[i,j] == 0 || MatRestul[i,j] != 'z')
					MatPlanuri[i,j].GetComponent<Renderer>().material = MNumere[ MatNivele[i,j] ];
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
				if(MatRestul[i,j] != 'z' && MatRestul[i,j] != 'y' && MatRestul[i,j] != 'x')
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
				
				
				
				
				
				
			}
		}
		
	}
	
	
	
}
