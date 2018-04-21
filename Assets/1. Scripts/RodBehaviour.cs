﻿using System;
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
	private bool rodDown = false;
	private FishermanBehav movementComp;
	private Animator _anim;

    private void Awake()
	{
		pointer = Instantiate(pointerPrefab, transform.position, Quaternion.identity);
		pointer.SetActive(false);
		movementComp = GetComponent<FishermanBehav>();
		_anim = GetComponent<Animator>();
	}

	private void ThrowRod()
	{
		movementComp.enabled = false;

		StartCoroutine(WaitingforShot());
	}

	IEnumerator WaitingforShot()
    {
        _anim.speed = 4;
        _anim.SetBool("isWalking", false);
        _anim.SetBool("isIdling", false);


        _anim.Play("Throw", -1, 0f);
        
        yield return new WaitForSeconds(0.5f);
        
        //yield return null;

        _anim.speed = 8;

		Vector3 pointerPos = fishSpawnPoint.position;
		pointerPos.y += 10;
		
		pointer.transform.position = pointerPos;
		pointer.SetActive(true);
		rodDown = true;
    }

	private void Fishing()
	{
		pointer.SetActive(false);
		_anim.speed = 1;
		//TODO: Animation up

        GameObject fish = fishPool.GetFreeObject();
		fish.transform.position = fishSpawnPoint.position;
		
		Vector3[] waypoints = new[] { new Vector3(-0.04983821f,0.4744337f,-0.01836145f), new Vector3(0.08313101f,0.8105265f,0f), new Vector3(-0.03325231f,1.138894f,-0.01836145f), new Vector3(-0.2909583f,1.267747f,-0.01836145f) };
		Sequence s = DOTween.Sequence();
		FishBehaviour fishBehaviour = fish.GetComponent<FishBehaviour>();
		fish.SetActive(true);
		
		s.Append(fish.transform.DOPath(waypoints, 0.1f, PathType.CatmullRom).SetEase(Ease.Linear))
		 .AppendCallback(() => fishBehaviour.StartFollowingParabola(transform.position, pointer.transform.position))
		 .AppendCallback(SetidleState);
		
	}

	private void SetidleState()
	{
		fishing = false;
		movementComp.enabled = true;
		_anim.SetBool("isIdling", true);
	}
	
	private void Update()
	{
		if (Input.GetAxisRaw(fireAxis) > 0 && !keyDown && !fishing)
		{
			fishing = true;
			keyDown = true;
			ThrowRod();
		}
		else if (Input.GetAxisRaw(fireAxis) == 0 && keyDown && rodDown)
		{
			keyDown = false;
			rodDown = false;
			Fishing();
		}
	}
}