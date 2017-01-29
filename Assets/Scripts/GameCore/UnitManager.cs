using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class UnitManager : GameManager {

    public List<Unit> units = new List<Unit> ();
    public UnitsData units_data = new UnitsData ();
    public List<UnitData> units_data_list = new List<UnitData> ();

    private string jsonDataFileName = "unit_datas.json";
    private JsonData jsonData;

    public void Start() {

        LoadDataFromJson ();
    }

    public void Update() {

        
    }

    public void Destroy() {

    }

    private void LoadDataFromJson() {

        string jsonDataFilePath = Path.Combine (Application.streamingAssetsPath, jsonDataFileName);

        if(File.Exists (jsonDataFilePath)) {

            string dataAsJson = File.ReadAllText (jsonDataFilePath);

            units_data = JsonUtility.FromJson<UnitsData> (dataAsJson);
            Debug.Log (units_data);
            Debug.Log (units_data.unit_data);
            //Debug.Log (units_data.unit_data[0]);
            for(var i = 0; i < units_data.unit_data.Count; i++) {

                UnitData ud = units_data.unit_data[i];
                Debug.Log (ud.atk);
                units_data_list.Add (ud);
            }
        } else {
            Debug.LogError ("Cannot load json file!");
        }
    }


}
