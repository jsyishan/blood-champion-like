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

    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToIdleState() {

    }

    public void ToSearchState() {
        Debug.Log ("Unable to transition to same state!");
    }

    public void ToPatrolState() {

    }

    public void ToAttackState() {

    }
}
