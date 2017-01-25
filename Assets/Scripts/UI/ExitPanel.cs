using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour {


    public void Remain() {

        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-1000);

        RectTransform block = GameObject.Find("Main_Menu_block").GetComponent<RectTransform>();
        block.anchoredPosition = new Vector2(1500, 0);
    }

    public void Exit() {

        Application.Quit();
    }


}
