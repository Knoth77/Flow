﻿using UnityEngine;
using System.Collections;

public class ShootForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject other) {
		Rigidbody body = other.rigidbody;
		if (body) {
			Vector3 direction = Vector3.forward;
			body.AddForce(-direction * 5);
		}
	}

}
