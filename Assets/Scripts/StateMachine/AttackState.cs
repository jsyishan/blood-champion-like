using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState {


    private readonly StateUnit self;

    public AttackState(StateUnit stateUnit) {
        self = stateUnit;
    }

    public void Start() {

    }

    public void Update() {

    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToIdleState() {

    }

    public void ToSearchState() {

    }

    public void ToPatrolState() {

    }

    public void ToAttackState() {
        Debug.Log ("Unable to transition to same state!");
    }

}
