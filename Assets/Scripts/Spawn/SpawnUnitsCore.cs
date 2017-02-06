using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnitsCore : MonoBehaviour {


    public Transform[] contentPanels;

    public Text curMoney;

    void Start() {

        Setup ();
        UpdateCurMoney ();
    }

    private void Setup() {

        var datas = MainCore.unit_manager.units_datas;

        datas.GetField ("units", (JSONObject json_units) => {

            foreach (JSONObject unit in json_units.list) {
                var unitName = unit.GetField ("name").str;
                var unitId = unit.GetField ("id").str;
                switch (unit.GetField ("type").str) {
                    case "Melee":
                    CreateUnits (0, unitName, unitId);
                    break;

                    case "Remote":
                    CreateUnits (1, unitName, unitId);
                    break;

                    case "Auxilary":
                    CreateUnits (2, unitName, unitId);
                    break;
                }
            }
        });
    }

    private void CreateUnits(int index, string unitName, string unitId) {

        var unit = Instantiate (Resources.Load ("Prefabs/SpawnUnit"), contentPanels[index]) as GameObject;
        unit.name = unitId.Substring(5);
        unit.GetComponentInChildren<Text> ().text = unitName;
    }

    public void UpdateCurMoney() {
        curMoney.text = MainCore.spawn_manager.curMoney.ToString ();
    }

}
