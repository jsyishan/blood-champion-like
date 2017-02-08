using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCore : MonoBehaviour {

    public float SPAWN_TIME;  //Time interval for spawning each unit, revise it in 'config.json'

    [Header ("Spawn Field")]
    public Transform[] spawn_field = null;

    private float spawn_time = 0f;


    void Start() {

        SPAWN_TIME = MainCore.configData.GetField ("SPAWN_TIME").f;

        for(int i = 0; i < MainCore.spawn_manager.spawn_order.Count; i++) {
            foreach(Spawn s in MainCore.spawn_manager.spawn_order[i]) {
                var offset = 0f;
                var go = Instantiate (Resources.Load ("Prefabs/Spawner"),
                    new Vector3 (spawn_field[0].position.x + offset, spawn_field[0].position.y, spawn_field[0].position.z),
                    new Quaternion (0, 0, 0, 0),
                    this.transform
                    ) as GameObject;
                offset += 0.0f;
                var spawner = go.GetComponent<Spawner> ();
                spawn_time += SPAWN_TIME;
                spawner.SetSpawnData (s, spawn_time);
            }
        }

    }

}
