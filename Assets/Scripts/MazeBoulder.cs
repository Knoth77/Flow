using UnityEngine;
using System.Collections;

public class MazeBoulder : MonoBehaviour {

	float newX = 68.62f;
	float newY = 179.04f;
	float newZ = -51.881f;

	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag.Equals ("Level_Walls")) 
		{
						Destroy (gameObject);
		} 
		else if (collision.gameObject.tag.Equals ("BreakableWall")) 
		{
						gameObject.rigidbody.AddForce (collision.relativeVelocity * -100);
				}
		if (collision.gameObject.tag.Equals ("Player")) 
				{
			collision.gameObject.transform.position = new Vector3(newX, newY, newZ);
				}
	}
}
