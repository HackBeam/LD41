using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {

	public float speed = 20f;
	public LayerMask dockLayer;

	private void Update()
	{
		transform.position += Vector3.left * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if(dockLayer == (dockLayer | (1 << other.gameObject.layer))){
			Destroy(gameObject);
		}
	}

}
