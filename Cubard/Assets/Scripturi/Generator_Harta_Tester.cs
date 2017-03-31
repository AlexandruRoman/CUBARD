using UnityEngine;
using System.Collections;
using System.IO;

public class Generator_Harta_Tester : MonoBehaviour {
	
	
	Transform obiect;
	Textu text;
	
	public int[,] MatNivele = new int[101,101];
	public int[,] MatCopyNivele = new int[101,101];
	public int[,] MatFixe = new int[101,101];
	public int[,] MatRampe = new int[101,101];
	public int[,] MatTexturi = new int[101,101];
	public int[,] MatLibere = new int[101,101];
	public int[,] MatRotatii = new int[101,101];
	public int[,] MatDimensiuni = new int[101,3];
	int n;
	
	public char Item2;
	public char[,] MatRestul = new char[101,101];
	
	
	
	public Transform[] Restul = new Transform[20];
	public Transform[] Copaci = new Transform[8];
	public Transform[] Roci = new Transform[3];
	
	public Transform Plan;
	public Transform Cub;
	public Transform TrigJos;
	public Transform TrigSus;
	public Transform TrigSus2;
	public Transform Trig;

	public Material MPamant;
	public Material MIarba;
	public Material MDrum1;
	public Material MDrum2;
	public Material MPavele;
	public Material MNisip;

	public GameObject Caracter;
	GameObject StartPoint;


	public GameObject tata;

	
	void Start()
	{
		CitireMatrice();
		GenerareCuburi();
		GenerareRestul();
		GenerareTrigger();

		StartPoint = GameObject.Find("StartPoint(Clone)");
		Caracter.transform.position = StartPoint.transform.position + new Vector3(0, 0.8f, 0);
		Caracter.SetActive(true);
		
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
					MatNivele[i,j] = int.Parse("" + txt[2*j]);
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
		{
			obiect = Instantiate(Cub, new Vector3(x*2, i, y*2), Quaternion.Euler(270,0,0)) as Transform;
			obiect.parent = tata.transform;
			text = obiect.GetComponent<Textu>();
			text.Texturare(MatTexturi[x,y]);
		}
		
		
		if(tip == 0)
		{

			obiect = Instantiate(Plan, new Vector3(x*2, 0, y*2), Quaternion.Euler(270,0,0)) as Transform;
			obiect.parent = tata.transform;
			text = obiect.GetComponent<Textu>();
			text.Texturare(MatTexturi[x,y]);
		}
		
	}

	
	

	void GenerareRestul()
	{
		int i,j;
		
		for(i=0; i<n; i++)
		{
			for(j=0; j<n; j++)
			{
				if(MatRestul[i,j] != 'z' && MatRestul[i,j] != 'y' && MatRestul[i,j] != 'x' && MatRestul[i,j] != 'b' && MatRestul[i,j] != 'd' && MatRestul[i,j] != 'k')
				{

					(Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, 0)) as Transform).parent = tata.transform;

				}
				
				if(MatRestul[i,j] == 'y')
				{
					(Instantiate(Copaci[Random.Range(0,8)], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, MatRotatii[i,j]*90)) as Transform).parent = tata.transform;

				}
				
				
				if(MatRestul[i,j] == 'x')
				{
					(Instantiate(Roci[Random.Range(0,2)], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90)) as Transform).parent = tata.transform;

				}
				
				if(MatRestul[i,j] == 'b')
				{
					(Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, 0)) as Transform).parent = tata.transform;
					
				}
				
				if(MatRestul[i,j] == 'd')
				{
					(Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, 0)) as Transform).parent = tata.transform;
					
				}

				if(MatRestul[i,j] == 'k')
				{
					(Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(90, 0, Random.Range(0,3) * 90)) as Transform).parent = tata.transform;
					
				}
				
				
			}
		}
	}
	
	
	
	void GenerareTrigger()
	{
		int i,j;
		
		for(i=0;i<n;i++)
		{
			for(j=0;j<n;j++)
			{
				if(MatLibere[i,j] == 0)
				{
					//TrigSus
					if(j-1 >= 0)
						if(MatNivele[i,j-1] == MatNivele[i,j] - 1 && MatLibere[i,j-1] == 0)
					{
						(Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0)) as Transform).parent = tata.transform;
					}
					
					
					if(i-1 >= 0)
						if(MatNivele[i-1,j] == MatNivele[i,j] - 1 && MatLibere[i-1,j] == 0)
					{
						(Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0)) as Transform).parent = tata.transform;
					}
					
					if(j+1 <= n)
						if(MatNivele[i,j+1] == MatNivele[i,j] - 1 && MatLibere[i,j+1] == 0)
					{
						(Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0)) as Transform).parent = tata.transform;
					}
					
					if(i+1 <= n)
						if(MatNivele[i+1,j] == MatNivele[i,j] - 1 && MatLibere[i+1,j] == 0)
					{
						(Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0)) as Transform).parent = tata.transform;
					}
					
					
					
					
					//TrigJos
					if(j-1 >= 0)
						if(MatNivele[i,j-1] == MatNivele[i,j] - 1 && MatLibere[i,j-1] == 0)
					{
						(Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0)) as Transform).parent = tata.transform;
					}
					
					if(i-1 >= 0)
						if(MatNivele[i-1,j] == MatNivele[i,j] - 1 && MatLibere[i-1,j] == 0)
					{
						(Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0)) as Transform).parent = tata.transform;
					}
					
					if(j+1 <= n)
						if(MatNivele[i,j+1] == MatNivele[i,j] - 1 && MatLibere[i,j+1] == 0)
					{
						(Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0)) as Transform).parent = tata.transform;
					}
					
					if(i+1 <= n)
						if(MatNivele[i+1,j] == MatNivele[i,j] - 1 && MatLibere[i+1,j] == 0)
					{
						(Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0)) as Transform).parent = tata.transform;
					}
					
					
					//Trig
					
					
					
					//TrigSus2
					if(j-1 >= 0)
						if(MatNivele[i,j-1] < MatNivele[i,j] - 1 && MatRestul[i,j-1] != 'b')
					{
						(Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0)) as Transform).parent = tata.transform;
					}
					
					if(i-1 >= 0)
						if(MatNivele[i-1,j] < MatNivele[i,j] - 1 && MatRestul[i-1,j] != 'b')
					{
						(Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0)) as Transform).parent = tata.transform;
					}
					
					if(j+1 <= n)
						if(MatNivele[i,j+1] < MatNivele[i,j] - 1 && MatRestul[i,j+1] != 'b')
					{
						(Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0)) as Transform).parent = tata.transform;
					}
					
					if(i+1 <= n)
						if(MatNivele[i+1,j] < MatNivele[i,j] - 1 && MatRestul[i+1,j] != 'b')
					{
						(Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0)) as Transform).parent = tata.transform;
					}
					
					
				}
			}
		}
		
		
		
		
	}
	
	
}
