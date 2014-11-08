using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			GameObject spawn = GameObject.FindGameObjectWithTag("InitSpawn");
			other.gameObject.transform.position = spawn.transform.position;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
