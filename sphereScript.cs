using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class sphereScript : MonoBehaviour {

	[Range(0,2000)]
	public float forcex;
	[Range(0,2000)]
	public float forcey;
	public bool Shoot;

	Rigidbody rb;
	public float x=0f,y=0f;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//x = Input.GetAxis ("Horizontal");
	//	y = Input.GetAxis ("Vertical");

	}
	void FixedUpdate()
	{
		if (Shoot)
		{
			RotateMe ();
		}

	}
	void OnCollisionStay(Collision col)
	{
		if (Shoot)
		{
			if (col.gameObject.tag == "Accelerate")
			{
				forcey += 0.05f;
				y += 0.05f;
				AccelerateMe ();
			}
			else
			if (col.gameObject.tag == "Rotate")
			{
				forcex += 1f;
				x += 0.03f;
				RotateMe ();
			}
			else
			{
				x -= 0.05f;
				y -= 0.05f;
			}
		}
	}
	void AccelerateMe()
	{
		//rb.AddForce ();	
		rb.velocity=new Vector3(y,0f,x)*Time.deltaTime*-forcey;
	}
	void RotateMe()
	{
		rb.velocity=new Vector3(y,0f,x)*Time.deltaTime*-forcey;
		rb.AddTorque (new Vector3(y,0f,x)*Time.deltaTime*forcex);	
	}
}
