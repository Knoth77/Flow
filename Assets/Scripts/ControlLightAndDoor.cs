using UnityEngine;
using System.Collections;

public class ControlLightAndDoor : MonoBehaviour {

	private Light light;
	private bool hit = false;
	public float smooth = 2.0f;
	private Animator gateAnim;
	private int particleCount = 0;


	void Start () 
	{
		light = gameObject.GetComponentInChildren<Light> ();
		GameObject g = GameObject.Find ("EntranceGate");
		gateAnim = g.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hit) 
		{
			increaseLight();
		}
	}

	void OnParticleCollision(GameObject other)
	{

		particleCount++;

		if (particleCount >= 100) 
		{

						if (!hit) { // THE FIRST PARTICLE COLLISION
								gateAnim.SetBool ("Lowered", true);
								gateAnim.SetBool ("Raised", false);
						}

						hit = true;

		}

	}

	void increaseLight()
	{
		light.range = Mathf.Lerp (light.range, 30.0f, smooth * Time.deltaTime);
	}
}
