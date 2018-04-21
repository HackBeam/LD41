using System;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{

	private Vector3 parabStart;
	private Vector3 parabEnd;
	private float parabTime = 0;
	private bool followingParab = false;

	public float parabHeight;
	public float parabSpeed;

	private Vector3 FollowParabola(float t)
    {
        Func<float, float> f = x => -4 * parabHeight * x * x + 4 * parabHeight * x;

        var mid = Vector3.Lerp(parabStart, parabEnd, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(parabStart.y, parabEnd.y, t), mid.z);
    }

	private void StartFollowingParabola(Vector3 startPoint, Vector3 endPoint)
	{
		if (!followingParab)
		{
			followingParab = true;
			parabStart = startPoint;
			parabEnd = endPoint;
		}
	}

/* DEBUGGIN */
	private void Update()
	{
		if (followingParab)
		{
			parabTime += parabSpeed * Time.deltaTime;
			transform.position = FollowParabola(parabTime);
		}
	}
/* ------- */
}
