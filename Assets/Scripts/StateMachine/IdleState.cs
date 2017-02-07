using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState {

    private readonly StateUnit self;

    public IdleState(StateUnit stateUnit) {
        self = stateUnit;
    }

    public void Start() {

    }

    public void Update() {

    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToIdleState() {
        Debug.Log ("Unable to transition to same state!");
    }

    public void ToSearchState() {

    }

    public void ToPatrolState() {

    }

    public void ToAttackState() {

    }
}
