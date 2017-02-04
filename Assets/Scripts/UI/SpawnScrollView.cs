using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnScrollView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private Vector3 oriPos;


    public void OnBeginDrag(PointerEventData e) {

        //oriPos = this.GetComponent<RectTransform> ().position;
    }

    public void OnDrag(PointerEventData e) {

    }

    public void OnEndDrag(PointerEventData e) {

        //this.GetComponent<RectTransform> ().position = oriPos;
    }

}