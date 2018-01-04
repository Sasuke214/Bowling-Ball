using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowBall : MonoBehaviour
{
	public Vector3 ClickedPos;

	public Vector3 StartPoint;
	public Vector3 EndPoint;
	public bool mobile;
	[Range(0,20)]
	public float ForceToHit;

	public Vector3 Force = new Vector3 (0f, 0f, 10f);
	public float angle;
	void  Update()
	{
		if (!mobile)
		{

			if (Input.GetMouseButtonDown (0))
			{
				StartPoint=Camera.main.ScreenToViewportPoint (Input.mousePosition);
			}
			if (Input.GetMouseButtonUp (0))
			{
				EndPoint=Camera.main.ScreenToViewportPoint (Input.mousePosition);
				angle = CalculateAngle (StartPoint, EndPoint);
				if(EndPoint.x<StartPoint.x)
					angle=90+(90-angle);
				transform.GetComponent <SphereController> ().direction.y = -angle;
			}
		}
		else
		{
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Began)
				{
					StartPoint=Camera.main.ScreenToViewportPoint (touch.position);

				}
				if (touch.phase == TouchPhase.Ended)
				{
					EndPoint=Camera.main.ScreenToViewportPoint  (touch.position);
					angle = CalculateAngle (StartPoint, EndPoint);
					if(EndPoint.x<StartPoint.x)
						angle=90+(90-angle);
					transform.GetComponent <SphereController> ().direction.y = angle;
				}


			}


		}

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