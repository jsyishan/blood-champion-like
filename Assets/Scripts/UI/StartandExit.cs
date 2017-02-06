using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartandExit : MonoBehaviour {


    public void StartGame() {

        MainCore.scene_manager.ChangeScene (MainCore.scene_manager.CreateLevel ("spawn"));
    }

    public void Exit() {

        RectTransform exit_panel = GameObject.Find("Exit_Panel").GetComponent<RectTransform>();
        RectTransform block = GameObject.Find("Main_Menu_block").GetComponent<RectTransform>();

        block.anchoredPosition = new Vector2(656,0);
        exit_panel.anchoredPosition = new Vector2(0,0);

    }
}
