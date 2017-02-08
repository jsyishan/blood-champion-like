using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {


    private readonly StateUnit self;

    public PatrolState(StateUnit stateUnit) {
        self = stateUnit;
    }

    public void Start() {

    }

    public void Update() {

        Patrol ();
    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToIdleState() {
        self.curEnemyState = self.idleState;
    }

    public void ToSearchState() {
        self.curEnemyState = self.searchState;
    }

    public void ToPatrolState() {
        Debug.Log ("Unable to transition to same state!");
    }

    public void ToAttackState() {
        self.curEnemyState = self.attackState;
    }

    private void Patrol() {


    }
}
