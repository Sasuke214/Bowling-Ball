using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	Rigidbody rb;
	public Vector3 direction;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent <Rigidbody> ();
		direction = transform.forward;
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.velocity = direction * Time.deltaTime * 10f;
	}
}
