using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UnitManager : GameManager {

    public List<Unit> units = new List<Unit> ();

    public List<UnitData> unitDataList = new List<UnitData> ();
    private string jsonString;
    public JSONObject units_datas;

    public void Start() {

        LoadDataFromJson ();
        CreateAllUnitData ();
    }

    public void Update() {


    }

    public void Destroy() {

    }

    private void LoadDataFromJson() {

        string jsonDataFilePath = Application.dataPath + "/Others/unit_datas.json";

        if (File.Exists (jsonDataFilePath)) {

            jsonString = File.ReadAllText (jsonDataFilePath);
            units_datas = new JSONObject (jsonString);

        } else {
            Debug.LogError ("Cannot load json file!");
        }
    }

    private void CreateAllUnitData() {

        units_datas.GetField ("units", (JSONObject json_units) => {

            foreach (JSONObject unit in json_units.list) {

                UnitData tmp_ud = new UnitData ();

                tmp_ud.id = unit.GetField ("id").str;
                tmp_ud.name = unit.GetField ("name").str;

                tmp_ud.cost = (int) unit.GetField("cost").f;

                tmp_ud.max_hp = unit.GetField ("max_hp").f;
                tmp_ud.atk = unit.GetField ("atk").f;
                tmp_ud.atk_fre = unit.GetField ("atk_fre").f;
                tmp_ud.atk_fre = unit.GetField ("atk_dis").f;
                tmp_ud.def = unit.GetField ("def").f;
                tmp_ud.speed = unit.GetField ("speed").f;
                
                unitDataList.Add (tmp_ud);
            }
        });
    }

}
