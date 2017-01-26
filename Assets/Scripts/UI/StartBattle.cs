using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour {


    public void BattleStart() {
        MainCore.scene_manager.ChangeScene (MainCore.scene_manager.CreateLevel ("two_players", "2players"));
        MainCore.unit_manager.Spawning ();
    }
}
