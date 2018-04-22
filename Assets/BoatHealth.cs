using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHealth : MonoBehaviour {

	public LayerMask fishLayer;
	public int MaxHealth;
	private int currentHealth;

	private void OnTriggerEnter(Collider other){
        if (fishLayer == (fishLayer | (1 << other.gameObject.layer)))
        {
			
		}
	}
}
