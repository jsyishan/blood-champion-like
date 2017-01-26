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
    public static SpawnManager spawn_manager = new SpawnManager();

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

}
