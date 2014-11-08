using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.

	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

	public bool onGround = true;
	private bool jumped = false;
	public float jumpForce = 1400f;

	public bool movementDisabled = false;

	private bool disableLeft = false;
	private bool disableRight = false;
	private bool disableForward = false;
	private bool disableBackwards = false;




	void Awake ()
	{
		playerRigidbody = GetComponent <Rigidbody> ();
	}


	void Update()
	{

		/*if (playerRigidbody.velocity.y == 0 && !onGround) 
		{
			onGround = true;
		}*/

		if (Input.GetButtonDown ("Jump") && onGround) 
		{
			jumped = true;
		}
	}

	void OnCollisionStay(Collision collisionInfo)
	{
		foreach (ContactPoint contact in collisionInfo.contacts) 
		{
			if(contact.otherCollider.gameObject.tag == "Level_Floor")
			{
				onGround = true;
			}



		}
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		foreach (ContactPoint contact in collisionInfo.contacts) 
		{
			if(contact.otherCollider.gameObject.tag == "Level_Floor")
			{
				onGround = false;
				
			}

		}
	}

	
	
	void FixedUpdate ()
	{

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");


		if (jumped) 
		{
			Jump ();
			jumped = false;
		}



		if (movementDisabled) 
		{
			h = 0;
			v = 0;
		}

		Move (h, v);
		

	
	}



	
	void Move (float h, float v)
	{

		movement.Set (h, 0f, v);

		//Debug.Log (movement.ToString ());

		movement = Camera.main.transform.rotation * movement;
		movement.y = 0f;
		

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Jump()
	{
		playerRigidbody.AddForce (jumpForce * Vector3.up);
	}


	

}

