using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IEnemyState {

    private readonly StateUnit self;

    public DeadState(StateUnit stateUnit) {
        self = stateUnit;
    }
	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		//Dead();
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
        self.curEnemyState = self.attackState;
    }

    public void ToWaitState() {
        self.curEnemyState = self.waitState;
    }

    public void ToDeadState() {
        Debug.Log ("Unable to transition to same state!");
    }

    public void Dead() {
        // save body for a few seconds 
        // and then delete which means that the unit is really dead and cant reborn.
    }
}
