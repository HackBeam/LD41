using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedFish : MonoBehaviour
{

	public ParticleSystem normalParticles;
	public ParticleSystem whaleParticles;

    private GameObject passedFish;

	public void FishAppear(GameObject fish, bool isWhale)
	{
		passedFish = fish;

		if (isWhale)
			whaleParticles.gameObject.SetActive(true);
		else
			normalParticles.gameObject.SetActive(true);
	}

	public GameObject GetFish()
	{
		GameObject result = passedFish;
		passedFish = null;

		whaleParticles.gameObject.SetActive(false);
		normalParticles.gameObject.SetActive(false);

		return result;
	}
}
