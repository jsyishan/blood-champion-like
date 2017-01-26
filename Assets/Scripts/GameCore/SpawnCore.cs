using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCore : MonoBehaviour {

    [Header("Spawn Field")]
    public Transform[] spawn_field = null;

    List<Spawn> spawn_list = null;
    List<List<Spawn>> spawn_order = new List<List<Spawn>> ();

    void Start () {

        ToSpawn ();
	}
	
	void Update () {
		
	}

    public void ToSpawn() {

        spawn_list = MainCore.spawn_manager.GetSpawnList ();

        List<Spawn> tmp1_list = new List<Spawn> ();
        List<Spawn> tmp2_list = new List<Spawn> ();
        foreach(Spawn s in spawn_list) {
            if(s.GetOrder () == 1) {
                tmp1_list.Add (s);
            } else if(s.GetOrder () == 2) {
                tmp2_list.Add (s);
            }
        }
        spawn_order.Add (tmp1_list);
        spawn_order.Add (tmp2_list);

        foreach(List<Spawn> list in spawn_order) {
            foreach(Spawn s in list) {
                Debug.Log (s.GetUnit () + "  " + s.GetOrder ());
            }
        }

        //InvokeRepeating ("SpawnByOrder", 3.0f, 5.0f);
    }

    private void SpawnByOrder() {

        foreach(Spawn s in spawn_list) {
            // Debug.Log (s.GetUnit ());
            try {
                Instantiate (Resources.Load (
                    "Prefabs/Units/" + MainCore.unit_manager.GetUnitName (s.GetUnit ())),
                    new Vector3 (spawn_field[0].position.x, spawn_field[0].position.y + 1, spawn_field[0].position.z),
                    new Quaternion (0, 0, 0, 0)
                    );
            } catch(Exception e) {
                Debug.Log (e.Message);
            }
        }
    }

}
