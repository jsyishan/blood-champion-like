using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameManager {

    void Start();
    void Update();
    void Destroy();

}

public class MainCore : MonoBehaviour {

    public static ISceneManager scene_manager = new ISceneManager();

    List<GameManager> game_manager = new List<GameManager>();



    void Awake () {

        DontDestroyOnLoad(transform.gameObject);

        game_manager.Add(scene_manager);

        for (int i = 0; i < game_manager.Count; i++) {
            game_manager[i].Start();
        }


    }

    void Start() {

        //scene_manager.ChangeScene(scene_manager.CreateLevel("spawn"));
    }
	

	void Update () {

        for(int i = 0; i < game_manager.Count; i++) {
            game_manager[i].Update();
        }
    }

    void OnDestroy() {

        for(int i = 0; i < game_manager.Count; i++) {
            game_manager[i].Destroy();
            game_manager[i] = null;
        }
    }


    public void ChangeScene(string scene) {

        scene_manager.ChangeScene(scene_manager.CreateLevel(scene));
    }

    public void Exit() {

        RectTransform exit_panel = GameObject.Find("Exit_Panel").GetComponent<RectTransform>();
        RectTransform block = GameObject.Find("Main_Menu_block").GetComponent<RectTransform>();

        block.anchoredPosition = new Vector2(656, 0);
        exit_panel.anchoredPosition = new Vector2(0, 0);

    }

}
