using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RodBehaviour : MonoBehaviour
{
	public GameObject pointerPrefab;
	public PoolSystemArray fishPool;
    public string fireAxis;
	public Transform fishSpawnPoint;

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

		Vector3 pointerPos = fishSpawnPoint.position;
		pointerPos.y += 1;
		
		//TODO: Animation

		pointer.transform.position = pointerPos;
		pointer.SetActive(true);
	}

	private void Fishing()
	{
		pointer.SetActive(false);
		//TODO: Animation

        GameObject fish = fishPool.GetFreeObject();
		fish.transform.position = fishSpawnPoint.position;
		
		Vector3[] waypoints = new[] { new Vector3(-0.04983821f,0.4744337f,-0.01836145f), new Vector3(0.08313101f,0.8105265f,0f), new Vector3(-0.03325231f,1.138894f,-0.01836145f), new Vector3(-0.2909583f,1.267747f,-0.01836145f) };
		Sequence s = DOTween.Sequence();
		FishBehaviour fishBehaviour = fish.GetComponent<FishBehaviour>();
		fish.SetActive(true);
		
		s.Append(fish.transform.DOPath(waypoints, 0.1f, PathType.CatmullRom).SetEase(Ease.Linear))
		 .AppendCallback(() => fishBehaviour.StartFollowingParabola(transform.position, pointer.transform.position))
		 .AppendCallback(() => fishing = false);
		
		//TODO: Unlock movement
		
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