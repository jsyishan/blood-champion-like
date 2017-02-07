using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUnit : MonoBehaviour {

    [HideInInspector] public IEnemyState curEnemyState;

    //Declare more states below ...
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public SearchState searchState;
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public AttackState attackState;

    private List<IEnemyState> state_list = new List<IEnemyState> ();

    void Awake() {

        //Instanciate more states below ...
        idleState = new IdleState (this);
        searchState = new SearchState (this);
        patrolState = new PatrolState (this);
        attackState = new AttackState (this);

        //Add more states into the 'state_list' below ...
        state_list.Add (idleState);
        state_list.Add (searchState);
        state_list.Add (patrolState);
        state_list.Add (attackState);


        MainCore.state_manager.AddStateUnit (this);
    }

    void Start() {
        curEnemyState = idleState;
    }

    void Update() {
        for (int i = 0; i < state_list.Count; i++) {
            state_list[i].Update ();
        }
    }

    void OnTriggerEnter(Collider other) {
        for (int i = 0; i < state_list.Count; i++) {
            state_list[i].OnTriggerEnter (other);
        }
    }

    void OnDestroy() {
        MainCore.state_manager.RemoveStateUnit (this);
    }
}
    