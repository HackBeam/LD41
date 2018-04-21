using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to pool GameObjects
/// </summary>
public class PoolSystemArray : MonoBehaviour
{
	public List<GameObject> prefabList;

	[HideInInspector]
	public int currentIndex = 0;

	[HideInInspector]
	public List<GameObject> list;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		foreach (Transform t in transform)
		{
			list.Add(t.gameObject);
			Next();
		}
	}

	/// <summary>
	/// Iterates the index to the next object. ONLY USE FOR EDITOR PURPOSES.
	/// </summary>
	public void Next()
	{
		currentIndex++;
		if (currentIndex > prefabList.Count - 1)
		{
			currentIndex = 0;
		}
	}

	/// <summary>
	/// Iterates the index to the previous object. ONLY USE FOR EDITOR PURPOSES.
	/// </summary>
	public void Previous()
	{
		currentIndex--;
		if (currentIndex < 0)
		{
			currentIndex = prefabList.Count - 1;
		}
		Debug.Log(currentIndex);
	}

	/// <summary>
	/// Instantiates a new GameObject. ONLY USE FOR EDITOR PURPOSES.
	/// </summary>
	/// <returns>The new GameObject instantiated</returns>
	public GameObject CreateElement()
	{
		GameObject o = Instantiate(prefabList[currentIndex], Vector3.zero, Quaternion.identity, transform);
		o.SetActive(false);
		list.Add(o);
		Next();
		return o;
	}

	/// <summary>
	/// Gets a GameObject from the pool or creates a new one if all pulled objects are in use.
	/// </summary>
	/// <returns>The selected GameObject. This GameObject is not Active in hiearchy</returns>
	public GameObject GetFreeObject()
	{
		GameObject go = list.Find(item => item.activeInHierarchy == false);

		if (go == null)
			go = CreateElement();

		return go;
	}

	/// <summary>
	/// Gets the first pooled GameObject that matches with the given index. ONLY USE FOR EDITOR PURPOSES.
	/// </summary>
	/// <param name="index">Index to search</param>
	/// <returns>The selected GameObject. If no GameObject pooled at the given index, thows an exception.</returns>
	public GameObject GetFreeByIndex(int index)
	{
		if (index > list.Count - 1)
		{
			GameObject go = null;
			for (int i = list.Count; i <= index; i++)
			{
				go = CreateElement();
			}
			return go;
		}
		else if (index < 0)
		{
			throw new System.IndexOutOfRangeException();
		}
		else
		{
			return (!list[index].activeInHierarchy ? list[index] : GetFreeByIndex(index + prefabList.Count));
		}
	}
}
