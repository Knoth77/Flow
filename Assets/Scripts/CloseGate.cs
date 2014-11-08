using UnityEngine;
using System.Collections;

public class CloseGate : MonoBehaviour {

	// Use this for initialization

	public Animator gateAnim;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			closeGate();
		}
	}

	void closeGate()
	{
		gateAnim.SetBool ("Lowered", false);
		gateAnim.SetBool ("Raised", true);
	}
}
