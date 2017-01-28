using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCore : MonoBehaviour {

    [Header ("Spawn Field")]
    public static Transform[] spawn_field = null;


    private bool ifSpawn = false;
    private bool ifTime = false;

    void Start() {
        
    }

    void Update() {

        //if(ifSpawn) {
        //    if (spawn_order.Count != 0) {
        //        SpawnTimeCounter ();
        //    }
        //}
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
