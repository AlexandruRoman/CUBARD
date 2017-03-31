using UnityEngine;
using System.Collections;

public class DUEL : MonoBehaviour
{
	string registeredGameName = "Cubard_test";
	HostData[] hostData;

	public GameObject Om;

	private void Awake()
	{
		Network.minimumAllocatableViewIDs = 5000;
	}


	private void StartServer()
	{
		Network.InitializeServer(3, 25002, false);
		MasterServer.RegisterHost(registeredGameName, "Cubard_server");
	}

	void OnServerInitialized()
	{
		Debug.Log("S-a initializat");
		SpawnPlayer();
	}

	void OnMasterServerEvent(MasterServerEvent mse)
	{
		if(mse == MasterServerEvent.RegistrationSucceeded)
		{
			Debug.Log("Inregistrare cu succes");
		}
	}


	public IEnumerator RefreshHostList()
	{
		Debug.Log ("Refreshing...");
		MasterServer.RequestHostList(registeredGameName);

		yield return new WaitForSeconds(3);

		hostData = MasterServer.PollHostList();

		if(hostData == null || hostData.Length == 0)
			Debug.Log("Nu s-au gasit servere");


	}

	private void SpawnPlayer()
	{
		if(Network.isServer)
			Network.Instantiate(Om, Vector3.up * 0.8f, Quaternion.identity, 0);
		else
			Network.Instantiate(Om, Vector3.up * 0.8f + new Vector3(150, 0, 0) , Quaternion.identity, 0);
	}

	void OnConnectedToServer()
	{
		SpawnPlayer();
	}

	void OnDisconnectedFromServer(NetworkDisconnection info)
	{

	}

	void OnFailedToConnect(NetworkConnectionError error)
	{

	}

	void OnPlayerConnected(NetworkPlayer player)
	{

	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		
	}

	void OnFailedToConnectToMasterServer(NetworkConnectionError info)
	{

	}

	void OnNetworkInstantiate(NetworkMessageInfo info)
	{
	}

	void OnApplicationQuit()
	{
		if(Network.isServer)
		{
			Network.Disconnect(200);
			MasterServer.UnregisterHost();
		}

		if(Network.isClient)
		{
			Network.Disconnect(200);
		}
	}

	public void OnGUI()
	{

		if(!Network.isClient && !Network.isServer)
		{



			if(GUI.Button(new Rect(25, 25, 150, 30), "StartServer"))
			{
				StartServer();
			}
			
			
			if(GUI.Button(new Rect(25, 65, 150, 30), "Refresh"))
			{
				StartCoroutine("RefreshHostList");
			}
			
			if(hostData != null)
			{
				for(int i=0; i<hostData.Length; i++)
				{
					if(GUI.Button(new Rect(Screen.width/2, 65 + 30*i, 300, 30), hostData[i].gameName))
					{
						Network.Connect(hostData[i]);
					}
				}
				
			}


		}


	}

}
