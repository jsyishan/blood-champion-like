using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCore : MonoBehaviour {

    public float SPAWN_TIME = 2.0f;

    [Header ("Spawn Field")]
    public Transform[] spawn_field = null;

    private float spawn_time = 0f;


    void Start() {

        for(int i = 0; i < MainCore.spawn_manager.spawn_order.Count; i++) {
            foreach(Spawn s in MainCore.spawn_manager.spawn_order[i]) {
                var go = Instantiate (Resources.Load ("Prefabs/Spawner"),
                    new Vector3 (spawn_field[0].position.x, spawn_field[0].position.y + 0.8f, spawn_field[0].position.z),
                    new Quaternion (0, 0, 0, 0),
                    this.transform
                    ) as GameObject;
                var spawner = go.GetComponent<Spawner> ();
                spawn_time += SPAWN_TIME;
                spawner.SetSpawnData (s, spawn_time);
            }
        }

    }

}
