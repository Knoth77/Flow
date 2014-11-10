using UnityEngine;
using System.Collections;

public class DragonMuralTrigger : MonoBehaviour {


	public RiseWater rise;
	public GameObject fluid;
	private int particlesCount = 0;

	bool playerInRange = false;
	bool startWater = false;
	bool started = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startWater && !started) 
		{
			rise.startWaterRising ();
			fluid.SetActive(true);
			started = true;
		}
	}

	void OnParticleCollision(GameObject other)
	{

		if (playerInRange = false) 
		{
			particlesCount = 0;
			return;
		}

		particlesCount++;

		if (particlesCount > 100)
						startWater = true;

	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			playerInRange = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			playerInRange = false;
		}
	}


}
