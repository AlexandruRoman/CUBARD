using UnityEngine;
using System.Collections;

public class AranjareObiecte : MonoBehaviour {

	public Transform Pivot;
	public SpriteRenderer SpatiuRotate, SpatiuScale, SpatiuFinish, SpatiuGunoi;




	void Update()
	{

		Vector3 vSpatiuRotate = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0, GetComponent<Camera>().nearClipPlane+3));
		Vector3 vSpatiuScale = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth, 0, GetComponent<Camera>().nearClipPlane+3));
		Vector3 vSpatiuFinish = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(GetComponent<Camera>().pixelWidth, 0, GetComponent<Camera>().nearClipPlane+3));
		Vector3 vSpatiuGunoi = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0, GetComponent<Camera>().nearClipPlane+3));


		SpatiuRotate.transform.position = new Vector3(vSpatiuRotate.x, Pivot.position.y, Pivot.position.z);
		SpatiuScale.transform.position = new Vector3(vSpatiuScale.x, Pivot.position.y, Pivot.position.z);
		SpatiuFinish.transform.position = new Vector3(vSpatiuFinish.x, vSpatiuFinish.y, Pivot.position.z);
		SpatiuGunoi.transform.position = new Vector3(vSpatiuGunoi.x, vSpatiuGunoi.y, Pivot.position.z);



	}

}
