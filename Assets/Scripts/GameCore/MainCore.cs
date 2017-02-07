using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager {

    void Start();
    void Update();
    void Destroy();
}

public class MainCore : MonoBehaviour {

    public static GameSceneManager scene_manager = new GameSceneManager();
    public static SpawnManager spawn_manager = new SpawnManager();
    public static UnitManager unit_manager = new UnitManager ();
    public static StateManager state_manager = new StateManager ();

    List<IGameManager> game_manager = new List<IGameManager>();


    void Awake () {
   
        game_manager.Add(scene_manager);
        game_manager.Add (spawn_manager);
        game_manager.Add (unit_manager);
        game_manager.Add (state_manager);

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
