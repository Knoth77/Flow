using UnityEngine;
using System.Collections;

public class BottomCollide : MonoBehaviour {

	

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Iceball") 
		{
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == "Player") 
		{
			GameObject spawn = GameObject.FindGameObjectWithTag("IceSpawn");
			other.gameObject.transform.position = spawn.transform.position;
		}
	}
}
