using UnityEngine;
using System.Collections;

public class BoulderWallBreak : MonoBehaviour {

	//GameObject col;

	void OnCollisionEnter(Collision collision) 
	{
		//col = collision.gameObject;
		if (collision.gameObject.tag.Equals("Iceball")) {
			gameObject.SetActive(false);
			gameObject.collider.enabled = false;
				}
	}
}
