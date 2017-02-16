using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDelay : Action {

    private float timer;
    private float curTime;

    public ActionDelay(GameObject go, float t) {

        gameObject = go;
        timer = t >= 0.0f ? t : 0.0f;
        curTime = 0.0f;
    }

    public override void Start () {
		
	}
	
	public override void Update () {

        if (curTime >= timer) {
            isFinished = true;
        } else {
            curTime += Time.deltaTime;
        }
	}

    public override void Destroy() {

    }

}
