using System;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{

	private Vector3 parabStart;
	[HideInInspector]public Vector3 parabEnd;
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

	public void StartFollowingParabola(Vector3 startPoint, Vector3 endPoint)
	{
		if (!followingParab)
		{
			followingParab = true;
			parabStart = startPoint;
			parabEnd = endPoint;
			parabTime = 0;
		}
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
