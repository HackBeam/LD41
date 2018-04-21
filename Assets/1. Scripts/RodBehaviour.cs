using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBehaviour : MonoBehaviour
{
	public GameObject pointerPrefab;
	public PoolSystemArray fishPool;
    public string fireAxis;

	private GameObject pointer;
    private bool keyDown;
    private bool fishing;

    private void Awake()
	{
		pointer = Instantiate(pointerPrefab, transform.position, Quaternion.identity);
		pointer.SetActive(false);
	}

	private void ThrowRod()
	{
		//TODO: Lock movement
		//TODO: Animation

		pointer.transform.position = transform.position;
		pointer.SetActive(true);
	}

	private void Fishing()
	{
		pointer.SetActive(false);
		//TODO: Animation
		ThrowFish();
	}

    private void ThrowFish()
    {
        GameObject fish = fishPool.GetFreeObject();
		fish.GetComponent<FishBehaviour>().StartFollowingParabola(transform.position, pointer.transform.position);
		fish.SetActive(true);

		//TODO: Unlock movement
		fishing = false;
	}

	private void Update()
	{
		if (Input.GetAxisRaw(fireAxis) > 0 && !keyDown && !fishing)
		{
			fishing = true;
			keyDown = true;
			ThrowRod();
		}
		else if (Input.GetAxisRaw(fireAxis) == 0 && keyDown)
		{
			keyDown = false;
			Fishing();
		}
	}
}
