using UnityEngine;
using System.Collections;

public class TriggerColor : MonoBehaviour {

	private bool sprayOn;
	//public GameObject spawn1;
	//public TriggerColor trig;
	//public Rigidbody iceball;

	// Use this for initialization
	void Start () {
		this.gameObject.renderer.material.color = Color.red;

	}

	public bool isSprayOn()
	{
		return sprayOn;
	}

	void OnCollisionEnter(Collision collision) 
	{
		//col = collision.gameObject;
		if (collision.gameObject.tag.Equals("Player")) {
			sprayOn = true;
			//Instantiate(iceball,spawn1.transform.position,Quaternion.identity);
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
