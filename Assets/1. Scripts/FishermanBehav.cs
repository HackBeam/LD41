using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishermanBehav : MonoBehaviour {

    public float Speed;
    public float maxLimit;
    public float minLimit;
    Animator _anim;
    public bool isInWater;

	// Use this for initialization
	void Awake ()
    {
        _anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
        Animations();
	}

    void Movement()
    {
        float _vertical = Input.GetAxis("Vertical");

        if (_vertical != 0)
        {

            transform.Translate(Vector3.forward * _vertical * Speed * Time.deltaTime, Space.World);
        }
    }

    void Animations()
    {
        float _vertical = Input.GetAxis("Vertical");



        if (_vertical != 0)
        {
            _anim.SetBool("isIdling", false);
            _anim.SetBool("isWalking", true);
            _anim.SetBool("isPullingBack", false);
        }

        else 
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isIdling", true);
            _anim.SetBool("isPullingBack", false);
        }

        if(isInWater)
        {
            _anim.SetBool("isInWater", isInWater);
            _anim.SetBool("isIdling", false);
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isPullingBack", false);
        }
/*
        if(Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine(WaitingforShot());
            //_anim.SetTrigger("isThrowing");
            
        }
*/
    }
/*
    IEnumerator WaitingforShot()
    {
        _anim.speed = 4;
        _anim.SetBool("isWalking", false);
        _anim.SetBool("isIdling", false);


        _anim.Play("Throw", -1, 0f);
        
        yield return new WaitForSeconds(1f);
        
        yield return null;
        _anim.speed = 1;
    }
*/
}


