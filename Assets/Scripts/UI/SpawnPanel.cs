using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPanel : MonoBehaviour {

    private RectTransform[] rects = new RectTransform[3];
    private RectTransform thisPanel;

    private Vector2[] vecs = new Vector2[3];

    void Start() {

        thisPanel = this.transform.FindChild("FirstClass").GetComponent<RectTransform>();

        rects[0] = this.transform.FindChild("SecondClass").FindChild("melees").GetComponent<RectTransform>();
        rects[1] = this.transform.FindChild("SecondClass").FindChild("remotes").GetComponent<RectTransform>();
        rects[2] = this.transform.FindChild("SecondClass").FindChild("auxiliaries").GetComponent<RectTransform>();

        for(int i = 0; i < rects.Length; i++) {
            vecs[i] = rects[i].anchoredPosition;
        }
    }

    private void moveThis() {

        thisPanel.anchoredPosition = new Vector2(-3000, -421);
    }

    private void recoveryThis() {

        thisPanel.anchoredPosition = new Vector2(0, -421);
    }

    public void SwitchTo(int index) {

        moveThis();
        rects[index].anchoredPosition = new Vector2(0, 307);
    }

    public void BackTo(int index) {

        recoveryThis();
        rects[index].anchoredPosition = vecs[index];
    }

}
