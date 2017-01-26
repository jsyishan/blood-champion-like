using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameManager {

    List<Spawn> spawn_list = new List<Spawn>();

    public void Start() {
        
    }

    public void Update() {

    }

    public void Destroy() {

    }

    public void AddSpawn(Spawn s) {

        Debug.Log ("Unit: " + s.GetUnit() + ", Order: " + s.GetOrder());
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

}
