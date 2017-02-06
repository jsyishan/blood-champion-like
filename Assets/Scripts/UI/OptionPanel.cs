using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour {

    RectTransform option_panel;
    RectTransform main_panel;

    void Start() {
        option_panel = GameObject.Find ("Option_Panel").GetComponent<RectTransform> ();
        main_panel = GameObject.Find ("Main_Scene").GetComponent<RectTransform> ();
    }

    public void CallOptionPanel() {

        option_panel.anchoredPosition = new Vector2(0, 0);
        main_panel.anchoredPosition = new Vector2 (0, 1500);
    }

    public void BackToMainScene() {

        option_panel.anchoredPosition = new Vector2 (-2000, 0);
        main_panel.anchoredPosition = new Vector2 (0, 0);
    }
}
