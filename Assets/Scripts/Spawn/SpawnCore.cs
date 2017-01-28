using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCore : MonoBehaviour {

    [Header ("Spawn Field")]
    public Transform[] spawn_field = null;


    private float SPAWN_TIME = 2.0f;
    private float spawn_time = 2.0f;


    void Start() {

        for(int i = 0; i < MainCore.spawn_manager.spawn_order.Count; i++) {
            foreach(Spawn s in MainCore.spawn_manager.spawn_order[i]) {
                var go = Instantiate (Resources.Load ("Prefabs/Spawner"),
                    new Vector3 (spawn_field[0].position.x, spawn_field[0].position.y + 1, spawn_field[0].position.z),
                    new Quaternion (0, 0, 0, 0),
                    this.transform
                    ) as GameObject;
                var spawner = go.GetComponent<Spawner> ();
                spawner.SetSpawnData (s, spawn_time);
                spawn_time += SPAWN_TIME;
            }
        }

    }

    void Update() {

    }

    //private void SpawnTimeCounter() {

    //    spawn_time -= Time.deltaTime;
    //    // Debug.Log (spawn_time);
    //    if(spawn_time <= 0) {
    //        spawn_time = 3.0f;
    //        ifTime = true;
    //    }
    //    ifTime = false;
    //}


}
