using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateUnit : MonoBehaviour {

    public Transform eyes;
    public Transform navPoint;

    public float atkDistance;
    public float sightRange = 20f;
    public Vector3 offsetToEyes = new Vector3 (0f, 8f, 0f);

    [HideInInspector] public Transform target;
    [HideInInspector] public IEnemyState curEnemyState;

    //Declare more states below ...
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public SearchState searchState;
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public AttackState attackState;


    [HideInInspector] public NavMeshAgent navMeshAgent;
    private List<IEnemyState> state_list = new List<IEnemyState> ();

    private Unit unit;

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

        navMeshAgent = GetComponent<NavMeshAgent> ();
        navPoint = GameObject.Find("NavPoint").GetComponent<Transform>();
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

    private void InitUnitData() {

        unit = this.GetComponent<Unit> ();
        atkDistance = unit.atk_dis;
    }
}
    