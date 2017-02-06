using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour {

    public void BackToMain() {

        MainCore.spawn_manager.ClearSpawnList ();
        MainCore.spawn_manager.curMoney = 15;
        MainCore.scene_manager.ChangeScene (MainCore.scene_manager.CreateLevel("main_scene"));
    }
}
