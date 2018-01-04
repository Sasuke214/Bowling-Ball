using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public float angle;
	public float sx,sy;
	public float ex,ey;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 start = new Vector2 (sx, sy);
		Vector2 end = new Vector2 (ex, ey);
		print (CalculateAngle (start, end));
		//angle = Vector2.Angle (start, end);
	}
	float CalculateAngle(Vector2 startPoint,Vector2 endPoint)
	{
		Vector2 intersect = new Vector2 (endPoint.x, startPoint.y);
		float y = Mathf.Sqrt (Mathf.Pow ((endPoint.x-intersect.x),2)+Mathf.Pow((endPoint.y-intersect.y),2));
		float x = Mathf.Sqrt (Mathf.Pow ((intersect.x-startPoint.x),2)+Mathf.Pow ((intersect.y-startPoint.y),2));
		float rad = Mathf.Atan2 (y, x);
		float deg = Mathf.Rad2Deg * rad;
		return deg;
	}

}
