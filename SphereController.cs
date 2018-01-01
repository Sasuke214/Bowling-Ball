using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using System.Diagnostics;

public class SphereController : MonoBehaviour {

	public GameObject child;
	public Vector3 initialPos;
	public float movex,movey;
	public float moveTime;
	public float moveSpeed;
	public bool borderReached;
	// Use this for initialization
	void Start () 
	{
		child = GameObject.FindGameObjectWithTag ("Ball");
		initialPos = child.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Delete))
		{
			child.GetComponent <Rigidbody> ().useGravity = true;
			child.GetComponent<sphereScript> ().Shoot = true;
			child.transform.SetParent (null);
		}
		if (child.transform.position.z <= -0.35f || child.transform.position.z >= 0.35f)
		{
			borderReached = true;
		}
		if (child.transform.position.z <= -0.35f && movex > 0f)
			borderReached = false;
		if (child.transform.position.z >= 0.35f && movex < 0f)
			borderReached = false;
		
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
	}
	void FixedUpdate()
	{
		if (movex != 0 && !borderReached)
		{
			Move ();
		}
	}
	void Move()
	{
		child.transform.position = Vector3.Lerp (child.transform.position, child.transform.position+Vector3.forward*movex*moveSpeed*Time.deltaTime, moveTime);
	}
}
