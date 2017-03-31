using UnityEngine;
using System.Collections;
using System.IO;

public class Generator_Harta : MonoBehaviour {


	Transform obiect;
	
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
	


	IEnumerator OnConnectedToServer()
	{
		yield return new WaitForSeconds(1);
		CitireMatrice();
		GenerareCuburi();
		GenerareRestul();
		GenerareTrigger();

	}


	IEnumerator OnPlayerConnected()
	{
		yield return new WaitForSeconds(1);
		CitireMatrice();
		GenerareCuburi();
		GenerareRestul();
		GenerareTrigger();
		
	}
	
	

	


	[RPC]
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

	[RPC]
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
	

	
	


	
	[RPC]
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


	[RPC]
	void CreareCub(int x, int y, int tip)
	{
		if(MatRestul[x,y] != 'z')
			MatLibere[x,y] = 1;
		else
			MatLibere[x,y] = 0;
		
		
		for(int i=0; i<tip; i++)
		{
			if(Network.isClient)
				obiect = Network.Instantiate(Cub, new Vector3(x*2, i, y*2), Quaternion.Euler(270,0,0), 0) as Transform as Transform;
			else
				obiect = Network.Instantiate(Cub, new Vector3(x*2 + 2000, i, y*2), Quaternion.Euler(270,0,0), 0) as Transform as Transform;

			obiect.GetComponent<NetworkView>().RPC("Texturare", RPCMode.OthersBuffered, MatTexturi[x,y]);
		}
		

		if(tip == 0)
		{
			if(Network.isClient)
				obiect = Network.Instantiate(Plan, new Vector3(x*2, 0, y*2), Quaternion.Euler(270,0,0), 0) as Transform as Transform;
			else
				obiect = Network.Instantiate(Plan, new Vector3(x*2 + 2000, 0, y*2), Quaternion.Euler(270,0,0), 0) as Transform as Transform;

			obiect.GetComponent<NetworkView>().RPC("Texturare", RPCMode.OthersBuffered, MatTexturi[x,y]);
			obiect.gameObject.SetActive(false);
		}
		
	}


	
	

	[RPC]
	void GenerareRestul()
	{
		int i,j;
		
		for(i=0; i<n; i++)
		{
			for(j=0; j<n; j++)
			{
				if(MatRestul[i,j] != 'z' && MatRestul[i,j] != 'y' && MatRestul[i,j] != 'x' && MatRestul[i,j] != 'b' && MatRestul[i,j] != 'd')
				{
					if(Network.isClient)
						(Network.Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90), 0) as GameObject).SetActive(false);
					else
						(Network.Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2 + 2000, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90), 0) as GameObject).SetActive(false);
				}
				
				if(MatRestul[i,j] == 'y')
				{
					if(Network.isClient)
						(Network.Instantiate(Copaci[Random.Range(0,8)], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, MatRotatii[i,j]*90), 0) as GameObject).SetActive(false);
					else
						(Network.Instantiate(Copaci[Random.Range(0,8)], new Vector3(i*2 + 2000, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, MatRotatii[i,j]*90), 0) as GameObject).SetActive(false);
				}
				
				
				if(MatRestul[i,j] == 'x')
				{
					if(Network.isClient)
						Network.Instantiate(Roci[Random.Range(0,2)], new Vector3(i*2, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90), 0);
					else
						Network.Instantiate(Roci[Random.Range(0,2)], new Vector3(i*2 + 2000, MatNivele[i,j], j*2), Quaternion.Euler(270, 0, Random.Range(0,3) * 90), 0);
					
				}
				
				if(MatRestul[i,j] == 'b')
				{
					if(Network.isClient)
						Network.Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, 0), 0);
					else
						Network.Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2 + 2000, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, 0), 0);
					
				}

				if(MatRestul[i,j] == 'd')
				{
					if(Network.isClient)
						Network.Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, 0), 0);
					else
						Network.Instantiate(Restul[MatRestul[i,j] - 'a'], new Vector3(i*2 + 2000, MatFixe[i,j], j*2), Quaternion.Euler(270, 0, 0), 0);
					
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
						if(Network.isClient)
							Network.Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0), 0);
						else
							Network.Instantiate(TrigSus, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0), 0);
					}


					if(i-1 >= 0)
						if(MatNivele[i-1,j] == MatNivele[i,j] - 1 && MatLibere[i-1,j] == 0)
					{
						if(Network.isClient)
							Network.Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0), 0);
						else
							Network.Instantiate(TrigSus, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0), 0);
					}

					if(j+1 <= n)
						if(MatNivele[i,j+1] == MatNivele[i,j] - 1 && MatLibere[i,j+1] == 0)
					{
						if(Network.isClient)
							Network.Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0), 0);
						else
							Network.Instantiate(TrigSus, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0), 0);
					}

					if(i+1 <= n)
						if(MatNivele[i+1,j] == MatNivele[i,j] - 1 && MatLibere[i+1,j] == 0)
					{
						if(Network.isClient)
							Network.Instantiate(TrigSus, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0), 0);
						else
							Network.Instantiate(TrigSus, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0), 0);
					}




					//TrigJos
					if(j-1 >= 0)
						if(MatNivele[i,j-1] == MatNivele[i,j] - 1 && MatLibere[i,j-1] == 0)
					{
						if(Network.isClient)
							Network.Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0), 0);
						else
							Network.Instantiate(TrigJos, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0), 0);
					}
					
					if(i-1 >= 0)
						if(MatNivele[i-1,j] == MatNivele[i,j] - 1 && MatLibere[i-1,j] == 0)
					{
						if(Network.isClient)
							Network.Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0), 0);
						else
							Network.Instantiate(TrigJos, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0), 0);
					}
					
					if(j+1 <= n)
						if(MatNivele[i,j+1] == MatNivele[i,j] - 1 && MatLibere[i,j+1] == 0)
					{
						if(Network.isClient)
							Network.Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0), 0);
						else
							Network.Instantiate(TrigJos, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0), 0);
					}
					
					if(i+1 <= n)
						if(MatNivele[i+1,j] == MatNivele[i,j] - 1 && MatLibere[i+1,j] == 0)
					{
						if(Network.isClient)
							Network.Instantiate(TrigJos, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0), 0);
						else
							Network.Instantiate(TrigJos, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0), 0);
					}


					//Trig



					//TrigSus2
					if(j-1 >= 0)
						if(MatNivele[i,j-1] < MatNivele[i,j] - 1 || MatLibere[i,j-1] == 1)
					{
						if(Network.isClient)
							Network.Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0), 0);
						else
							Network.Instantiate(TrigSus2, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,-90,0), 0);
					}
					
					if(i-1 >= 0)
						if(MatNivele[i-1,j] < MatNivele[i,j] - 1 || MatLibere[i-1,j] == 1)
					{
						if(Network.isClient)
							Network.Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0), 0);
						else
							Network.Instantiate(TrigSus2, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,0,0), 0);
					}
					
					if(j+1 <= n)
						if(MatNivele[i,j+1] < MatNivele[i,j] - 1 || MatLibere[i,j+1] == 1)
					{
						if(Network.isClient)
							Network.Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0), 0);
						else
							Network.Instantiate(TrigSus2, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,90,0), 0);
					}
					
					if(i+1 <= n)
						if(MatNivele[i+1,j] < MatNivele[i,j] - 1 || MatLibere[i+1,j] == 1)
					{
						if(Network.isClient)
							Network.Instantiate(TrigSus2, new Vector3(i*2, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0), 0);
						else
							Network.Instantiate(TrigSus2, new Vector3(i*2 + 2000, MatNivele[i,j] - 1, j*2), Quaternion.Euler(270,180,0), 0);
					}


				}
			}
		}




	}
	
	
}
