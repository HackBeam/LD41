<<<<<<< HEAD
﻿
#if UNITY_EDITOR
=======
﻿#if UNITY_EDITOR
>>>>>>> pablo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]

public class CheckForStandardAssets : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	    var guids = AssetDatabase.FindAssets("FXWater4Advanced", null);
	    Debug.Assert(guids.Length > 0, "Please add Unity's Standard Assets to make water works! https://www.assetstore.unity3d.com/en/#!/content/32351");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
<<<<<<< HEAD
#endif
=======
#endif
>>>>>>> pablo
