﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : IGameManager {

    List<Spawn> spawn_list = new List<Spawn> ();
    public List<List<Spawn>> spawn_order = new List<List<Spawn>> ();


    public int curMoney;  //Current Money which can be used to pay for each spawn, revise it in 'config.json' 

    private int ORDER_COUNT = 13;  //The amount of the spawn orders

    public void Start() {
        curMoney = (int) MainCore.configData.GetField ("START_MONEY").f;
    }

    public void Update() {

    }

    public void Destroy() {

    }


    private void CreateSpawnOrder() {

        for(int i = 1; i < ORDER_COUNT + 1; i++) {

            List<Spawn> tmp_list = new List<Spawn> ();
            foreach(Spawn s in spawn_list) {
                if(s.GetOrder () == i) {
                    tmp_list.Add (s);
                }
            }
            spawn_order.Add (tmp_list);
        }

        ClearSpawnList ();
    }

    public void AddSpawn(Spawn s) {

        Debug.Log ("Unit: " + s.GetUnit () + ", Order: " + s.GetOrder ());
        spawn_list.Add (s);
    }

    public Spawn NewSpawn(string name, int order) {
        return new Spawn (name, order);
    }

    public List<Spawn> GetSpawnList() {
        return spawn_list;
    }

    public void ClearSpawnList() {
        spawn_list.Clear ();
    }

    public bool IsEmpty() {
        return spawn_list.Count == 0 ? true : false;
    }


    public void ToSpawn() {

        CreateSpawnOrder ();
    }


}
