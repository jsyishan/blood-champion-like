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
        self.curEnemyState = self.idleState;
    }

    public void ToSearchState() {
        self.curEnemyState = self.searchState;
    }

    public void ToPatrolState() {
        self.curEnemyState = self.patrolState;
    }

    public void ToAttackState() {
        Debug.Log ("Unable to transition to same state!");
    }

    private void Approach() {

    }

    private void Attack() {

    }

}
