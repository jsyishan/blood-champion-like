using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : IEnemyState {


    private readonly StateUnit self;

    public SearchState(StateUnit stateUnit) {
        self = stateUnit;
    }

    public void Start() {

    }

    public void Update() {

        Look ();
    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToIdleState() {
        self.curEnemyState = self.idleState;
    }

    public void ToSearchState() {
        Debug.Log ("Unable to transition to same state!");
    }

    public void ToPatrolState() {
        self.curEnemyState = self.patrolState;
    }

    public void ToAttackState() {
        self.curEnemyState = self.attackState;
    }

    private void Look() {

        RaycastHit hit;
        if (Physics.Raycast (self.eyes.transform.position, self.eyes.transform.forward, out hit, self.sightRange) && hit.collider.CompareTag ("Unit")) {
            self.target = hit.transform;
            ToAttackState ();
        }
    }
}
