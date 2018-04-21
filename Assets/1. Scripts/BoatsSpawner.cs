using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatsSpawner : MonoBehaviour
{
   public Transform[] Roads;
   

    public List<GameObject> Boats;
    int _selectedShip;

     GameObject lastestShipCreated;
     GameObject newShip;

    public Vector3 SpawnerPos;

    // Use this for initialization
    void Start () {

        

        InvokeRepeating("BoatsReady", 0, 1);

    }
	
	// Update is called once per frame
	void Update () {

        

    }

    private void BoatsReady()
    {
        SelectRoad();
        CreatingShip();
    }

    void SelectRoad()
    {
        int _rndNum = Random.Range(0, Roads.Length);
        transform.position = Roads[_rndNum].position + SpawnerPos;
    }

    void CreatingShip()
    {
        if (lastestShipCreated == null)
        {

            PickingSystem();
            Instantiate(newShip, transform.position, Quaternion.identity);
            lastestShipCreated = newShip;

        }

        else if (lastestShipCreated != null)
        {


            PickingSystem();

            //if (newShip = lastestShipCreated)
            //{
            //    PickingSystem();
            //}

            if (newShip != lastestShipCreated)
            {
                Instantiate(newShip, transform.position, Quaternion.identity);
                lastestShipCreated = newShip;
                return;
            }
        }
        //{
        //    GameObject _newship = new GameObject();

            //    float _rdomly = Random.Range(0f, 1f);

            //    if (_rdomly > .6f)
            //    {
            //        _newship.name = Boats[0].name;

            //    }

            //    else if (_rdomly >= .3f && _rdomly <= .6f)
            //    {
            //        _newship.name = Boats[1].name;
            //    }

            //    else if (_rdomly > .1f && _rdomly < .3f)
            //    {
            //        _newship.name = Boats[2].name;
            //    }

            //    else if (_rdomly <= .1f)
            //    {
            //        _newship.name = Boats[3].name;
            //    }

            //    if(_newship != lastestShipCreated)
            //    {

            //    }
            //}





    }

    private void PickingSystem()
    {
        float _rdomly = Random.Range(0f, 1f);

        if (_rdomly > .6f)
        {
            newShip = Boats[0];
            newShip.name = Boats[0].name;

        }

        else if (_rdomly >= .3f && _rdomly <= .6f)
        {
            newShip = Boats[1];
            newShip.name = Boats[1].name;

        }

        else if (_rdomly > .1f && _rdomly < .3f)
        {
            newShip = Boats[2];
            newShip.name = Boats[2].name;

        }

        else if (_rdomly <= .1f)
        {
            newShip = Boats[3];
            newShip.name = Boats[3].name;

        }
    }
}
