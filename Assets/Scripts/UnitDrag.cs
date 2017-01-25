using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    Vector3 oriPos;

    public void OnBeginDrag(PointerEventData e) {

        oriPos = this.gameObject.GetComponent<RectTransform>().position;
    }

    public void OnDrag(PointerEventData e) {

        SetDraggedPosition(e);
    }

    public void OnEndDrag(PointerEventData e) {

        BackToOriginPos(e);
    }

    private void SetDraggedPosition(PointerEventData e) {

        var rt = gameObject.GetComponent<RectTransform>();

        Vector3 globalMousePos;
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, e.position, e.pressEventCamera, out globalMousePos)) {
            rt.position = globalMousePos;
        }
    }

    private void BackToOriginPos(PointerEventData e) {

        var rt = gameObject.GetComponent<RectTransform>();

        if (rt.position.x > 665 && rt.position.x < 855) {
            if(rt.position.y > 850 && rt.position.y < 950) {
                GameObject.Find("NO.1").GetComponent<Material>().color = Color.red;
                Debug.Log("Touch");
            }
        } else {
            rt.position = oriPos;
        }
        
    }
}
