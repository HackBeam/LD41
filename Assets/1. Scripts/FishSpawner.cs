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

        PickingSystem(_fishesParticles[_rndSelection].gameObject, _rdomly);

        _throws++;

    }

    private void PickingSystem(GameObject _fishPlace, float _rdomly)
    {
        if (_rdomly >= .9f)
        {
             Instantiate(Fishes[0], _fishPlace.transform.position, Quaternion.identity);

        }

        if (_rdomly > .5f && _rdomly < .9f)
        {
             Instantiate(Fishes[1], _fishPlace.transform.position, Quaternion.identity);

        }

        else if (_rdomly >= .3f && _rdomly <= .5f)
        {
            Instantiate(Fishes[2], _fishPlace.transform.position, Quaternion.identity);

        }

        else if (_rdomly > .1f && _rdomly < .3f)
        {
             Instantiate(Fishes[3], _fishPlace.transform.position, Quaternion.identity);

        }

        else if (_rdomly <= .1f)
        {
           Instantiate(Fishes[4], _fishPlace.transform.position, Quaternion.identity);

        }
    }
}
