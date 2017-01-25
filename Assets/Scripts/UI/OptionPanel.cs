using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour {

    public void onCallOptionPanel() {

        RectTransform exit_panel = GameObject.Find("Option_Panel").GetComponent<RectTransform>();

        exit_panel.anchoredPosition = new Vector2(0, 0);
    }
}
