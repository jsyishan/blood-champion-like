using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface IGameManager {

    void Start();
    void Update();
    void Destroy();
}

public class MainCore : MonoBehaviour {

    [HideInInspector] public static JSONObject configData; 

    public static GameSceneManager scene_manager = new GameSceneManager();
    public static SpawnManager spawn_manager = new SpawnManager();
    public static UnitManager unit_manager = new UnitManager ();
    public static StateManager state_manager = new StateManager ();
    public static ActionManager action_manager = new ActionManager ();

    List<IGameManager> game_manager = new List<IGameManager>();


    void Awake () {

        LoadGameConfigJsonFile ();

        game_manager.Add(scene_manager);
        game_manager.Add (spawn_manager);
        game_manager.Add (unit_manager);
        game_manager.Add (state_manager);
        game_manager.Add (action_manager);

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

    private void LoadGameConfigJsonFile() {

        var jsonString = Application.dataPath + "/Others/config.json";

        if (File.Exists (jsonString)) {
            configData = new JSONObject (File.ReadAllText (jsonString));
        } else {
            Debug.LogError ("Cannot load json file!");
        }
    }

}
