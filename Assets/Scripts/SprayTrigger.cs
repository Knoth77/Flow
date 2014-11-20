using UnityEngine;
using System.Collections;

public class SprayTrigger : MonoBehaviour {

	public TriggerColor theSprayTrig;
	public GameObject wall;
	public GameObject wallTrig;

	void Start()
	{

		particleEmitter.emit = false;
	}

	void Update()
	{
		if (theSprayTrig != null && theSprayTrig.isSprayOn ()) {
			particleEmitter.emit = true;
				}
		if(wall != null && wall.gameObject.collider.enabled == false)
		{
			particleEmitter.emit = true;
		}
		if (wallTrig != null && wallTrig.gameObject.collider.enabled == false) {
			particleEmitter.emit = false;
				}
	}

	void OnParticleCollision(GameObject other) 
	{
		Rigidbody body = other.rigidbody;
		if(other.gameObject.tag.Equals("Iceball"))
		   {
		   other.gameObject.rigidbody.mass = 1;
		}
		if (gameObject.particleEmitter.worldVelocity.z < -100) {
						if (body) {
								Vector3 direction = Vector3.back;
								body.AddForce (direction * 10);
						}
				} 
		else if (gameObject.particleEmitter.worldVelocity.x > 100){
						if (body) {
								Vector3 direction = Vector3.left;
								body.AddForce (direction * 10);

						}
				}
		else if (gameObject.particleEmitter.worldVelocity.x < -100){
			if (body) {
				Vector3 direction = Vector3.right;
				body.AddForce (direction * 10);
				
			}
		}

	}
}
