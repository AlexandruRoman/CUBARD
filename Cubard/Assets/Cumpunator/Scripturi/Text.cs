using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	public Transform PivotNume, PivotCerinta, PivotText, PivotCantitate;
	public string TextNume, TextCerinta, TextText, TextCantitate;
	public Transform CasetaNume, CasetaCerinta, CasetaText, CasetaCantitate;
	public GUIStyle stil;
	public string info;

	Vector3 PNume, PCerinta, PText, PCantitate;

	void Start()
	{
		TextCantitate = "1";
	}

	void Update () 
	{
		PNume = GetComponent<Camera>().WorldToScreenPoint(PivotNume.position);
		PCerinta = GetComponent<Camera>().WorldToScreenPoint(PivotCerinta.position);
		PText = GetComponent<Camera>().WorldToScreenPoint(PivotText.position);
		PCantitate = GetComponent<Camera>().WorldToScreenPoint(PivotCantitate.position);


	}

	void OnGUI()
	{
		if(CasetaNume.position.x < 10)
			TextNume = GUI.TextField(new Rect(PNume.x - 250,Screen.height - PNume.y - 50, 500, 100), TextNume, 40, stil);

		if(CasetaCerinta.position.x < 10)
			TextCerinta = GUI.TextArea(new Rect(PCerinta.x - 350,Screen.height - PCerinta.y - 150, 700, 300), TextCerinta, 150, stil);

		if(CasetaCantitate.position.x < 10)
			TextCantitate = GUI.TextField(new Rect(PCantitate.x - 250,Screen.height - PCantitate.y - 50, 500, 100), TextCantitate, 3, stil);
		
		if(CasetaText.position.x < 10)
			TextText = GUI.TextArea(new Rect(PText.x - 350,Screen.height - PText.y - 200, 700, 400), TextText, 600, stil);
	}


}
