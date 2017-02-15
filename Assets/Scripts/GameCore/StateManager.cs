using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyState {

    void Start();
    void Update();
    void OnTriggerEnter(Collider other);

    //Add more states below...
    void ToIdleState();
    void ToSearchState();
    void ToPatrolState();
    void ToAttackState();
    void ToWaitState();
    void ToDeadState();

}


public class StateManager : IGameManager {

    public List<StateUnit> stateUnit_list = new List<StateUnit> ();

    public void Start() {

    }

    public void Update() {

    }

    public void Destroy() {

    }

    public void AddStateUnit(StateUnit su) {
        stateUnit_list.Add (su);
    }

    public void RemoveStateUnit(StateUnit su) {
        stateUnit_list.Remove (su);
    }
}
