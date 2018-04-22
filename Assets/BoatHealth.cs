using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHealth : MonoBehaviour {

	public LayerMask fishLayer;
	public int MaxHealth;
	private int currentHealth;

	void Start()
	{
		currentHealth = MaxHealth;
	}

	private void OnTriggerEnter(Collider other){
        if (fishLayer == (fishLayer | (1 << other.gameObject.layer)))
        {
			currentHealth -= other.GetComponent<FishBehaviour>().damage;
			Debug.Log(currentHealth);
			if(currentHealth < 0){
				Destroy(gameObject);
			}
		}
	}
}
