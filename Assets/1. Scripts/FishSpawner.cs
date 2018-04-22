using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    List<PickedFish> _fishesPoints;

    public List<GameObject> Fishes;

    public bool FishBool;
    int _rdomWhale;
    int _throws;



    private void Awake()
    {
        _fishesPoints = new List<PickedFish>(transform.GetComponentsInChildren<PickedFish>());
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
        /*foreach (var item in _fishesPoints)
        {
            item.gameObject.SetActive(false);
        }*/

        int pointSelected = Random.Range(0, _fishesPoints.Count);

        float fishSelected = Random.Range(0f, 1f);
        
        if (_throws == _rdomWhale)
        {
            fishSelected = .9f;
        }

        GameObject fish = PickingSystem(fishSelected);

        _fishesPoints[pointSelected].FishAppear(fish, fishSelected >= .9f); //gameObject.SetActive(true);

        //TODO: Intantiate fishes
        //_fishesPoints[pointSelected].GetComponent<PickedFish>().PassedFish = 
       // Instantiate(PickingSystem(fishSelected), _fishesPoints[pointSelected].transform.position, Quaternion.identity);

        _throws++;

    }

    public GameObject PickingSystem(float fishSelected)
    {
        GameObject _pickedFish = null;

        if (fishSelected >= .9f)
        {
            _pickedFish = Fishes[0];

        }

        if (fishSelected > .5f && fishSelected < .9f)
        {
            _pickedFish = Fishes[1];

        }

        else if (fishSelected >= .3f && fishSelected <= .5f)
        {
            _pickedFish = Fishes[2];

        }

        else if (fishSelected > .1f && fishSelected < .3f)
        {
             _pickedFish = Fishes[3];

        }

        else if (fishSelected <= .1f)
        {
          _pickedFish = Fishes[4];

        }

        return _pickedFish;
    }
}
