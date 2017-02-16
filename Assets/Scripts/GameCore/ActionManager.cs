using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : IGameManager {

    Dictionary<GameObject, Action> actionList = new Dictionary<GameObject, Action> ();

    public void Start() {

    }

    public void Update() {

        foreach (GameObject key in new List<GameObject> (actionList.Keys)) {
            Action action = actionList[key];
            action.Update ();
            if (action.IsFinished ()) {
                action.Destroy ();
                actionList.Remove (key);
            }
        }
    }

    public void Destroy() {

    }

    public void ExecAciton(Action action) {

        GameObject go = action.GetGameObject ();
        if (actionList.ContainsKey (go)) {
            actionList.Remove (go);
        }
        actionList.Add (go, action);
        action.Start ();
    }
}
