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

        Look ();
        MoveToNavPoint ();
    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToIdleState() {
        Debug.Log ("Unable to transition to same state!");
    }

    public void ToSearchState() {
        self.curEnemyState = self.searchState;
    }

    public void ToPatrolState() {
        self.curEnemyState = self.patrolState;
    }

    public void ToAttackState() {
        self.curEnemyState = self.attackState;
    }

    public void ToWaitState() {
        self.curEnemyState = self.waitState;
    }

    public void ToDeadState() {
        self.curEnemyState = self.deadState;
    }

    private void MoveToNavPoint() {
        self.navMeshAgent.destination = self.navPoint.position;
    }

    private void Look() {

        RaycastHit hit;
        if (Physics.Raycast (self.eyes.transform.position, self.eyes.transform.forward, out hit, self.sightRange) && hit.collider.CompareTag ("Unit")) {
            self.target = hit.transform;
            ToSearchState ();
        }
    }
}
