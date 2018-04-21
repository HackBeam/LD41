using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehaviour : MonoBehaviour
{
	public LayerMask waterLayer;
	public float movSpeed;
	public float maxDistance;

	private float currentDistance;

	private void OnEnable()
	{
		RaycastHit hit;
		Physics.Raycast(transform.position, -transform.up, out hit, 100, waterLayer);
		transform.position = hit.point;
		currentDistance = 0;
		StartCoroutine(Move());
	}

	IEnumerator Move()
	{
		while(currentDistance < maxDistance && enabled)
		{
			Vector3 mov = Vector3.right * movSpeed * Time.deltaTime;
			currentDistance += mov.x;
			transform.Translate(mov);
			yield return null;
		}
	}
}
