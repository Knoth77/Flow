using UnityEngine;
using System.Collections;

public class IceBallSpawner : MonoBehaviour {


	public GameObject spawn1;
	public GameObject spawn2;
	public Rigidbody iceball;
	private float Timer = 0.0f;

	void Start () 
	{
	
	}
	

	void Update () 
	{

		Timer -= Time.deltaTime;

		if (Timer <= 0)
		{
			Timer = 5.0f;
			Instantiate(iceball,spawn1.transform.position,Quaternion.identity);
			Instantiate(iceball,spawn2.transform.position,Quaternion.identity);
		}
	}
}
