using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    protected float hp;
    protected float atk;
    protected float def;
    protected float speed;

    public Unit() {

    }

    void Start() {

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
