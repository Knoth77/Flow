using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.

	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	
	void Awake ()
	{
	
		

		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	
	void FixedUpdate ()
	{

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

	
		

		Move (h, v);
		

	
	}
	
	void Move (float h, float v)
	{

		movement.Set (h, 0f, v);

		movement = Camera.main.transform.rotation * movement;
		

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}
	

}

