using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.

	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

	public bool onGround = true;
	private bool jumped = false;
	public float jumpForce = 1400f;

	private bool ladderClimb = false;
	

	public bool movementDisabled = false;
	

	private UnderwaterScript underWaterInfo;
	private bool isUnderWater;

	public PlayerSpray waterGun;




	void Awake ()
	{
		playerRigidbody = GetComponent <Rigidbody> ();
		underWaterInfo = GetComponent<UnderwaterScript> ();
	}


	void Update()
	{

		if (Input.GetMouseButton (0)) {
						waterGun.shoot = true;
				} else
						waterGun.shoot = false;

		if (ladderClimb) 
		{
			if(Input.GetKey("w"))
			{
				transform.position += Vector3.up;
			}
		}


		if (!isUnderWater) 
		{
			if (Input.GetButtonDown ("Jump") && onGround) 
			{
			jumped = true;
			}
		} 
		else 
		{
			if(Input.GetButton("Jump"))
			{
				//rigidbody.constantForce.relativeForce = new Vector3 (0,20,0);
				Vector3 up = new Vector3 (0,5,0);
				rigidbody.velocity = up;

			}
			else
			{
				//rigidbody.constantForce.relativeForce = new Vector3 (0,0,0);
				//rigidbody.velocity = Vector3.zero;
			}
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


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "LadderTrig") 
		{
			ladderClimb = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "LadderTrig") 
		{
			ladderClimb = false;
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

		isUnderWater = underWaterInfo.isUnderWater ();



		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if (jumped  && !movementDisabled) 
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

