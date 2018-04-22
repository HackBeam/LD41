using System;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{

	public int damage = 1;
	private Vector3 parabStart;
	[HideInInspector]public Vector3 parabEnd;
	private float parabTime = 0;
    private float parabHeight;
    private bool followingParab = false;

	public float parabMaxHeight;
	public float parabSpeed;

	private Vector3 FollowParabola(float t)
    {
        Func<float, float> f = x => -4 * parabHeight * x * x + 4 * parabHeight * x;

        var mid = Vector3.Lerp(parabStart, parabEnd, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(parabStart.y, parabEnd.y, t), mid.z);
    }

	public void StartFollowingParabola(Vector3 startPoint, Vector3 endPoint)
	{
		if (!followingParab)
		{
			float distance = endPoint.x - startPoint.x;
			
			if (distance < 1)
			{
				parabHeight = parabMaxHeight * 1.5f;
			}
			else
			{
				parabHeight = parabMaxHeight;
			}

			followingParab = true;
			parabStart = startPoint;
			parabEnd = endPoint;
			parabTime = 0;
		}
	}

	private void OnEnable()
	{
		parabTime = 0;
	}

/* DEBUGGIN */
	private void Update()
	{
		if (followingParab)
		{
			parabTime += parabSpeed * Time.deltaTime;
			transform.position = FollowParabola(parabTime);

			if (parabTime > 2)
			{
				this.gameObject.SetActive(false);
				followingParab = false;
			}
		}
	}
/* ------- */
}
