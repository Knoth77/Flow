using UnityEngine;
using System.Collections;

public class PlayerSpray : MonoBehaviour {


	private ParticleEmitter emitter;
	private float scaler = 20.0f;
	public bool shoot = false;


	void Start () 
	{
	
		emitter = gameObject.GetComponent<ParticleEmitter> ();

	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Quaternion rot = Camera.main.transform.rotation;

		Particle[] particles = emitter.particles;

		if (!shoot) {
						emitter.emit = false;
						return;
				} else
						emitter.emit = true;

		int i = 0;
		while (i < particles.Length) 
		{
			if(Mathf.Abs(particles[i].velocity.z) < 1)
			{
				float rndX = Random.Range(0,0.3f);
				float rndY = Random.Range(0,1.0f);
				float rndZ = Random.Range(0,0.3f);



				Vector3 shootVec = Camera.main.transform.forward;
				Vector3 rndVec = new Vector3(rndX, rndY, rndZ);


				shootVec.x = Camera.main.transform.forward.x * 30;
				shootVec.y = Camera.main.transform.forward.y * 20;
				shootVec.z = Camera.main.transform.forward.z * 40;

				shootVec += rndVec;

				particles[i].velocity = shootVec;

			

			
	

			}

			i++;
		}

		emitter.particles = particles;

		//emitter.worldVelocity.Set (10, 10, 10);
	}


	void OnParticleCollision(GameObject gbo)
	{
		//gameObject.camera.transform.forward
		//gameObject.GetComponentInParent<Camera> ().transform.forward;
		if (gbo.tag.Equals ("Iceball")) 
			gbo.rigidbody.AddForce (100 * (Camera.main.transform.forward));
	}





}
