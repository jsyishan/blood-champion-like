using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : IEnemyState {

    private readonly StateUnit self;

    public WaitState(StateUnit stateUnit) {
        self = stateUnit;
    }

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
        // wait for a few seconds
        /* wrong here, prompt that the method doesn't exist
         * StartCoroutine(Wait(2.0));
         */
        // then change to search state
        //...
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
        Debug.Log ("Unable to transition to same state!");
    }

    public void ToDeadState() {
        self.curEnemyState = self.deadState;
    }

    //force the troops to wait for a few seconds
    public IEnumerator Wait(float waitTime) {
        //wait for a few seconds
        yield return new WaitForSeconds (waitTime);
    }
}
