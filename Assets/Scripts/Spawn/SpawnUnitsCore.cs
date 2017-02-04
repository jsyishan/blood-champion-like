using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnitsCore : MonoBehaviour {


    [Header("Contents")]
    public Transform[] contentPanels;

    void Start() {

        var datas = MainCore.unit_manager.units_datas;

        datas.GetField ("units", (JSONObject json_units) => {

            foreach (JSONObject unit in json_units.list) {
                var unitName = unit.GetField ("name").str;
                switch (unit.GetField ("type").str) {
                    case "Melee":
                    CreateUnits (0, unitName);
                    break;

                    case "Remote":
                    CreateUnits (1, unitName);
                    break;

                    case "Auxilary":
                    CreateUnits (2, unitName);
                    break;
                }
            }
        });
    }

    private void CreateUnits(int index, string unitName) {

        var unit = Instantiate (Resources.Load ("Prefabs/SpawnUnit"), contentPanels[index]);
        unit.name = unitName.Substring (5);
        
    }

}
