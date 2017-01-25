using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneManager : GameManager {

    public Scene nowScene = null;

	public void Start () {

	}
	
	public void Update () {

		if (nowScene != null) {
            nowScene.Update();
        }

	}

    public void Destroy() {

    }

    public void ChangeScene(Scene s) {

        if (nowScene != null) {

            nowScene.Exit();
            nowScene = null;
        }

        nowScene = s;
        nowScene.Enter();

        Debug.Log("Now Scene is " + nowScene.scene_name);
    }

    public Scene CreateLevel(string level) {

        return new Level(level);
    }

}
