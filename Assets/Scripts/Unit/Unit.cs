using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit : MonoBehaviour {

    protected float max_hp;
    protected float hp;
    protected float atk;
    protected float atk_fre;
    protected float def;
    protected float speed;

    private UnitData ud = new UnitData();

    void Awake() {

        //try {
        //    var json = Resources.Load ("Json/unit_datas").ToString ();
        //    ud = JsonUtility.FromJson<UnitData> (json);
        //    Debug.Log (ud);
        //} catch (Exception e) {
        //    Debug.Log (e);
        //}
    }

    void Start() {

        MainCore.unit_manager.units.Add (this.GetComponent<Unit> ());
    }

    public Unit GetEnemy(GameObject go) {

        if(go != null) {
            return go.GetComponent<Unit> ();
        } else {
            return null;
        }
    }


    public void BeDamaged(Unit enemy) {
        hp -= enemy.atk - def;
    }

    public float GetHp() {
        return hp;
    }

    public void Attack() {

    }

    public void BeSpawned() {

    }

}

public class RemoteUnit : Unit {

    private float atkDistance;

}
