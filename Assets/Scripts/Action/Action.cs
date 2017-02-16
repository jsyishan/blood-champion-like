using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {

    protected GameObject gameObject;
    protected bool isFinished = false;

    public virtual void Start() {

    }

    public virtual void Update() {

    }

    public virtual void Destroy() {

    }

    public GameObject GetGameObject() {
        return gameObject;
    }

    public bool IsFinished() {
        return isFinished;
    }
}
