using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoisePositionXY : MonoBehaviour {
	public float maxPosition;
	public float minPosition;
	// Update is called once per frame
	void Update () {
		float y = Mathf.Lerp(minPosition, maxPosition, Mathf.PerlinNoise(Time.time, Time.time));
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}
}
