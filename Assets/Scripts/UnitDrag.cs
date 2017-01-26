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

        var rt = gameObject.GetComponent<RectTransform>();

        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, e.position, e.pressEventCamera, out globalMousePos)) {
            rt.position = globalMousePos;
        }
    }

    public void OnEndDrag (PointerEventData e) {

        EndJudging(e);
    }


    private void EndJudging (PointerEventData e) {

        var rt = gameObject.GetComponent<RectTransform>();

        //Debug.Log("ugui position: x-" + rt.position.x + "  y-" + rt.position.y);
        //Debug.Log("World position: x-" + Camera.main.ScreenToWorldPoint(rt.position).x + " y-" + Camera.main.ScreenToWorldPoint(rt.position).y);
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, e.position, e.pressEventCamera, out globalMousePos)) {
            //Debug.Log(globalMousePos);
        }

        //Vector3 temp;
        //var tem = GameObject.Find("1").GetComponent<RectTransform>();
        //if(RectTransformUtility.ScreenPointToWorldPointInRectangle(tem,Camera.main.WorldToScreenPoint(tem.position),Camera.main,out temp)) {
        //    Debug.Log(temp);
        //}

        GameObject[] tems = GameObject.FindGameObjectsWithTag("spawn");
        RectTransform tem = null;

        foreach (GameObject go in tems) {
            if (isContained(rt, go.GetComponent<RectTransform>())) {
                if (go.transform.parent.name == "First_Spawn") {
                    tem = go.GetComponent<RectTransform>();
                    Debug.Log("Order: 1");
                } else if (go.transform.parent.name == "Second_Spawn") {
                    tem = go.GetComponent<RectTransform>();
                    Debug.Log("Order: 2");
                } else {
                    Debug.Log("Not correct order");
                }
            }
        }

        if (tem != null) {
            Debug.Log("Contained!");
        } else {
            Debug.Log("Not correct space");
            rt.position = oriPos;
        }
        
    }


    private bool isContained(RectTransform whichIn,RectTransform whichHere) {

        Vector3 VecIn, VecHere;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle (
                whichIn,
                Camera.main.WorldToScreenPoint(whichIn.position),
                Camera.main, 
                out VecIn) && 
            RectTransformUtility.ScreenPointToWorldPointInRectangle (
                whichHere,
                Camera.main.WorldToScreenPoint(whichHere.position),
                Camera.main,
                out VecHere)) {

            //Debug.Log(VecIn);
            //Debug.Log(VecHere);
            if (Mathf.Abs (VecIn.x - VecHere.x) < 0.2 && Mathf.Abs (VecIn.y - VecHere.y) < 0.2) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    
}
