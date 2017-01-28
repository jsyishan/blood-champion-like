using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameManager {

    List<Spawn> spawn_list = new List<Spawn> ();
    List<List<Spawn>> spawn_order = new List<List<Spawn>> ();

    private float spawn_time = 3.0f;
    private int index_of_orders = 0;
    private int index_of_units= 0;

    public void Start() {

    }

    public void Update() {

    }

    public void Destroy() {

    }

    private void SpawnByOrder() {

        //for(int i = 0; i < spawn_order.Count; i++) {
        //    foreach(Spawn s in spawn_order[i]) {
        //        Debug.Log (s.GetUnit () + "  " + s.GetOrder ());
        //        try {
        //            Instantiate (Resources.Load (
        //                "Prefabs/Units/" + MainCore.unit_manager.GetUnitName (s.GetUnit ())),
        //                new Vector3 (spawn_field[0].position.x, spawn_field[0].position.y + 1, spawn_field[0].position.z),
        //                new Quaternion (0, 0, 0, 0)
        //                );
        //        } catch(Exception e) {
        //            Debug.Log (e.Message);
        //        }
        //    }
        //}
    }

    private void CreateSpawnOrder() {

        int order_count = 4;

        for(int i = 1; i < order_count + 1; i++) {

            List<Spawn> tmp_list = new List<Spawn> ();
            foreach(Spawn s in spawn_list) {
                if(s.GetOrder () == i) {
                    tmp_list.Add (s);
                }
            }
            spawn_order.Add (tmp_list);
        }

        ClearSpawnList ();
        SpawnByOrder ();
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

    }


}
