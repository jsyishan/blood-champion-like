using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : GameManager {

    public List<Unit> units = new List<Unit> ();

    

    public void Start() {

    }

    public void Update() {

        
    }

    public void Destroy() {

    }


    public string GetUnitName(string u_name) {
        return "Unit_" + u_name;
    }



    private void OnSpawn(bool ifSpawn) {

        if(ifSpawn) {
           // SpawnCore
        }
    }

    private void ResolveSpawnOrderList() {

    }

}
