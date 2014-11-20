using UnityEngine;
using System.Collections;

public class MazeIceBallSpawner : MonoBehaviour {

	public GameObject spawn1;
	public TriggerColor trig;
	public Rigidbody iceball;
	public GameObject wall;
	public GameObject wallTrig;
	private float Timer = 0.0f;
	
	void Start () 
	{
		//Instantiate(iceball,spawn1.transform.position,Quaternion.identity);
	}
	
	
	void Update () 
	{
		Timer -= Time.deltaTime;
		
		if (Timer <= 0 && (trig == null || trig.isSprayOn()) && 
		    (wall == null || wall.collider.enabled == false)
		    && (wallTrig == null || wallTrig.collider.enabled == true))
		{
			Timer = 5.0f;
			Instantiate(iceball,spawn1.transform.position,Quaternion.identity);
		}
	}
}
