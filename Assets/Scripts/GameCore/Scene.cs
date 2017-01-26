using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene {

    public string scene_name;

    public Scene() {

        scene_name = "main_scene";
    }

    public virtual void Enter() {
        
    }

    public virtual void Update() {

    }

    public virtual void Exit() {

    }

}

public class Level : Scene {

    public Level(string level_name, string level_paras = "") {

        scene_name = level_name;
        LevelParas (level_paras);
    }

    public override void Enter() {

        SceneManager.LoadSceneAsync("Scenes/" + scene_name);
    }

    private void LevelParas(string paras) {

        switch(paras) {
            case "2players":
                
                break;
            default:
                break;
        }
    }

}
