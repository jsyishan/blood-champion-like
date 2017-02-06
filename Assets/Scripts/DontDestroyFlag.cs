using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyFlag : MonoBehaviour {

    public static bool isInstanciated = false;
    public GameObject mc;

	void Awake () {

        if (!isInstanciated) {
            var go = Instantiate (mc) as GameObject;
            DontDestroyOnLoad (go);
            isInstanciated = true;
        }
	}
	
}
