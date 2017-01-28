using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    private float spawn_time = 2.0f;
    private float timer = 0.0f;

    private Spawn spawn = null;


	void Start () {
        //Debug.Log (spawn_time);
        
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if(timer >= spawn_time) {
            try {
                Instantiate (Resources.Load (
                    "Prefabs/Units/Unit_" + spawn.GetUnit()),
                    this.transform.position,
                    new Quaternion (0, 0, 0, 0),
                    this.transform
                    );
                
            } catch(Exception e) {
                Debug.Log (e.Message);
            }
            timer = 0;
            Destroy (this);
        }

    }

    public void SetSpawnData(Spawn s, float t) {
        spawn_time = t;
        spawn = s;
    }
}
