using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    List<ParticleSystem> _fishesParticles;

    public List<GameObject> Fishes;

    public bool FishBool;
    int _rdomWhale;
    int _throws;



    private void Awake()
    {
        _fishesParticles = new List<ParticleSystem>(transform.GetComponentsInChildren<ParticleSystem>());
        _rdomWhale = Random.Range(0, 6);
    }

    // Use this for initialization
    void Start () {

        RandomizingFishesParticles();
	}
	
	// Update is called once per frame
	void Update () {

        if(FishBool)
        {
            RandomizingFishesParticles();
            FishBool = !FishBool;
        }
		
	}

    void RandomizingFishesParticles()
    {
        foreach (var item in _fishesParticles)
        {
            item.gameObject.SetActive(false);
        }
        int _rndSelection = Random.Range(0, _fishesParticles.Count);
        _fishesParticles[_rndSelection].gameObject.SetActive(true);

        float _rdomly = Random.Range(0f, 1f);
        
        if (_throws == _rdomWhale)
        {
            _rdomly = .9f;
        }


        //TODO: Intantiate fishes
        _fishesParticles[_rndSelection].GetComponent<PickedFish>().PassedFish = PickingSystem(_rdomly);
       // Instantiate(PickingSystem(_rdomly), _fishesParticles[_rndSelection].transform.position, Quaternion.identity);

        _throws++;

    }

    public GameObject PickingSystem(float _rdomly)
    {
        GameObject _pickedFish = null;

        if (_rdomly >= .9f)
        {
            _pickedFish = Fishes[0];

        }

        if (_rdomly > .5f && _rdomly < .9f)
        {
            _pickedFish = Fishes[1];

        }

        else if (_rdomly >= .3f && _rdomly <= .5f)
        {
            _pickedFish = Fishes[2];

        }

        else if (_rdomly > .1f && _rdomly < .3f)
        {
             _pickedFish = Fishes[3];

        }

        else if (_rdomly <= .1f)
        {
          _pickedFish = Fishes[4];

        }

        return _pickedFish;
    }
}
