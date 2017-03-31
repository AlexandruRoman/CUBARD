using UnityEngine;
using System.Collections;
using System.IO;
public class Browser : MonoBehaviour {

	
	public string location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
	Vector2 fileScroll, directoryScroll;

	public bool fileBrowser = false;

	public GameObject principal, pivot, cantitate;
	GenerareObiecte script;

	public GameObject Urmatorul;
	public GameObject Restul;
	public Material negru;
	public GameObject planBlack;

	public string[] imagini;

	public int nr = 0;
	
	public static object SelectList( ICollection list, object selected)
	{			
		foreach( object item in list )
		{
			string[] iteme = item.ToString().Split('\\');

			if(item.ToString().Contains("."))
			{

			string[] end = iteme[iteme.Length-1].ToString().Split('.');

				if(end[end.Length-1].ToString() == "png" || end[end.Length-1].ToString() == "jpg" || end[end.Length-1].ToString() == "jpeg")
				{
					if( GUILayout.Button(iteme[iteme.Length-1].ToString(), GUIStyle.none))
					{
						if( selected == item )
							// Clicked an already selected item. Deselect.
						{
							selected = null;
						}
						else
						{
							selected = item;
						}
					}

				}
			}

		else
			if( GUILayout.Button(iteme[iteme.Length-1].ToString(), GUIStyle.none))
			{
				if( selected == item )
					// Clicked an already selected item. Deselect.
				{
					selected = null;
				}
				else
				{
					selected = item;
				}
			}
		}
		
		return selected;
	}
	
	
	
	public delegate bool OnListItemGUI( object item, bool selected, ICollection list );
	
	
	
	public static object SelectList( ICollection list, object selected, OnListItemGUI itemHandler )
	{
		ArrayList itemList;
		
		itemList = new ArrayList( list );
		
		foreach( object item in itemList )
		{
			if( itemHandler( item, item == selected, list ) )
			{
				selected = item;
			}
			else if( selected == item )
				// If we *were* selected, but aren't any more then deselect
			{
				selected = null;
			}
		}
		
		return selected;
	}

	public static bool FileBrowser( ref string location, ref Vector2 directoryScroll, ref Vector2 fileScroll )
	{
		bool complete;
		DirectoryInfo directoryInfo;
		DirectoryInfo directorySelection;
		FileInfo fileSelection;
		int contentWidth;
		
		
		// Our return state - altered by the "Select" button
		complete = false;
		
		// Get the directory info of the current location
		fileSelection = new FileInfo( location );
		if( (fileSelection.Attributes & FileAttributes.Directory) == FileAttributes.Directory )
		{
			directoryInfo = new DirectoryInfo( location );
		}
		else
		{
			directoryInfo = fileSelection.Directory;
		}
		
		
		if( location != "/" && GUI.Button( new Rect( 10, 20, 410, 20 ), "Inapoi cu un nivel" ) )
		{
			directoryInfo = directoryInfo.Parent;
			location = directoryInfo.FullName;
		}
		
		
		// Handle the directories list
		GUILayout.BeginArea( new Rect( 10, 40, 200, 300 ) );
		GUILayout.Label( "Fisiere:" );
		directoryScroll = GUILayout.BeginScrollView( directoryScroll );
		directorySelection = SelectList( directoryInfo.GetDirectories(), null ) as DirectoryInfo;
		GUILayout.EndScrollView();
		GUILayout.EndArea();
		
		if( directorySelection != null )
			// If a directory was selected, jump there
		{
			location = directorySelection.FullName;
		}
		
		
		// Handle the files list
		GUILayout.BeginArea( new Rect( 220, 40, 200, 300 ) );
		GUILayout.Label( "Imagini:" );
		fileScroll = GUILayout.BeginScrollView( fileScroll );
		fileSelection = SelectList( directoryInfo.GetFiles(), null ) as FileInfo;
		GUILayout.EndScrollView();
		GUILayout.EndArea();
		
		if( fileSelection != null )
			// If a file was selected, update our location to it
		{
			location = fileSelection.FullName;
		}
		
		
		// The manual location box and the select button
		GUILayout.BeginArea( new Rect( 10, 350, 410, 20 ) );
		GUILayout.BeginHorizontal();		
		location = GUILayout.TextArea( location );
		
		contentWidth = ( int )GUI.skin.GetStyle( "Button" ).CalcSize( new GUIContent( "Ok" ) ).x;
		if( GUILayout.Button( "Ok", GUILayout.Width( contentWidth ) ) )
		{
			complete = true;
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		
		
		return complete;
	}

	void Start()
	{
		script = cantitate.GetComponent<GenerareObiecte>();
	}

	IEnumerator Imagine(int n)
	{

		WWW www = new WWW("file://" + location);
		yield return www; 
		Sprite sprite = new Sprite();
		sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height),new Vector2(0, 0),100.0f);


		for(int i = 1; i<=n; i++)
		{

			GameObject img = new GameObject("Imagine");

			img.AddComponent<SpriteRenderer>();

			SpriteRenderer renderer = img.GetComponent<SpriteRenderer>();

			BoxCollider2D box = img.AddComponent<BoxCollider2D>() as BoxCollider2D;

			box.size = new Vector2(sprite.bounds.size.x,sprite.bounds.size.y);
			box.offset = sprite.bounds.center;

			img.AddComponent<Miscare>();
			
			renderer.sprite = sprite;
			renderer.sortingOrder = 0;

			img.transform.position = new Vector3(pivot.transform.position.x, pivot.transform.position.y,pivot.transform.position.z -i/1000f);
			img.transform.parent = principal.transform;

		}
	}

	public void Pac(int n)
	{
		StartCoroutine("Imagine", n);
	}
	
	
	
	IEnumerator FadeOut()
	{
		planBlack.SetActive(true);
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
		
		planBlack.SetActive(false);
	}
	
	void Hide()
	{

		Restul.transform.position = new Vector3(100, 0, -100);
		
		Urmatorul.transform.position = Vector3.zero;
	}
	
	IEnumerator afara()
	{
		StartCoroutine("FadeOut");
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("FadeIn");
		Hide();
		
	}

	public void FileBrowserWindow( int idx )
	{
		if( FileBrowser( ref location, ref directoryScroll, ref fileScroll ) )
		{
			fileBrowser = false;
			imagini[nr] = location;
			script.o = 100;
			StartCoroutine("afara");
			nr++;
		}
	}






	public void OnGUI()
	{

		if( fileBrowser )
		{
			GUI.Window( 0, new Rect( ( Screen.width - 430 ) / 2, ( Screen.height - 380 ) / 2, 430, 380 ), FileBrowserWindow, "Selectati imaginea" );
			return;
		}
	}


	void Update()
	{

	}
















}
