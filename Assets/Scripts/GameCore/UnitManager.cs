using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : GameManager {

    List<Unit> units = new List<Unit> ();

    List<Spawn> spawn_list;


    public void Start() {

    }

    public void Update() {

    }

    public void Destroy() {

    }

    public void Spawning() {

        spawn_list = MainCore.spawn_manager.GetSpawnList ();
        foreach(Spawn s in spawn_list) {
            //Debug.Log (s.GetUnit ());

        }
    }

    public string GetUnitName(string u_name) {
        return "Unit_" + u_name;
    }
}
