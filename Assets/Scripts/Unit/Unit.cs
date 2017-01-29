using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit : MonoBehaviour {

    public float hp;

    public float max_hp;
    public float atk;
    public float atk_fre;
    public float def;
    public float speed;


    void Start() {

        MainCore.unit_manager.units.Add (this.GetComponent<Unit> ());
        GetData ();
    }

    void OnDestroy() {

        MainCore.unit_manager.units.Remove (this.GetComponent<Unit> ());
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

    public void Attack() {

    }

    public void BeSpawned() {

    }

    protected void GetData() {

        foreach (UnitData ud in MainCore.unit_manager.unitDataList) {

            if (ud.name == this.name) {
                max_hp = ud.max_hp;
                atk = ud.atk;
                atk_fre = ud.atk_fre;
                def = ud.def;
                speed = ud.speed;

                hp = max_hp;
            }
        }
    }

}

public class RemoteUnit : Unit {

    public float atkDistance;

}
