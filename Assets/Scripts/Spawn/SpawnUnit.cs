using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private Vector3 oriPos;
    private int spawn_order = 0;
    private string spawn_unit = "";


    public void OnBeginDrag(PointerEventData e) {

        oriPos = this.gameObject.GetComponent<RectTransform> ().position;
        spawn_unit = this.gameObject.name;
    }

    public void OnDrag(PointerEventData e) {

        var rt = gameObject.GetComponent<RectTransform> ();

        Vector3 globalMousePos;
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle (rt, e.position, e.pressEventCamera, out globalMousePos)) {
            rt.position = globalMousePos;
        }
    }

    public void OnEndDrag(PointerEventData e) {

        EndJudging (e);
    }


    private void EndJudging(PointerEventData e) {

        var rt = gameObject.GetComponent<RectTransform> ();

        //Debug.Log("ugui position: x-" + rt.position.x + "  y-" + rt.position.y);
        //Debug.Log("World position: x-" + Camera.main.ScreenToWorldPoint(rt.position).x + " y-" + Camera.main.ScreenToWorldPoint(rt.position).y);
        //Vector3 globalMousePos;
        //if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, e.position, e.pressEventCamera, out globalMousePos)) {
        //    //Debug.Log(globalMousePos);
        //}
        //Vector3 temp;
        //var tem = GameObject.Find("1").GetComponent<RectTransform>();
        //if(RectTransformUtility.ScreenPointToWorldPointInRectangle(tem,Camera.main.WorldToScreenPoint(tem.position),Camera.main,out temp)) {
        //    Debug.Log(temp);
        //}
        var target = SpawnOrder (rt);

        if(target != null) {
            //Debug.Log ("Contained!");
            MainCore.spawn_manager.AddSpawn (MainCore.spawn_manager.NewSpawn(spawn_unit, spawn_order));

            target.tag = "Untagged";
            target.gameObject.GetComponent<Image> ().material = Resources.Load ("Materials/spawn_zone_set") as Material;

            target.gameObject.GetComponentInChildren<Text> ().text = spawn_unit.ToUpper();
        } else {
            //Debug.Log ("Not correct space");
        }
        rt.position = oriPos;

    }


    private RectTransform SpawnOrder(RectTransform rt) {

        GameObject[] all_spawn_zones = GameObject.FindGameObjectsWithTag ("spawn");
        RectTransform temp = null;

        foreach(GameObject go in all_spawn_zones) {

            if(isContained (rt, go.GetComponent<RectTransform> ())) {
                temp = go.GetComponent<RectTransform> ();
                switch (go.transform.parent.name) {
                    case "First_Spawn":
                        //Debug.Log ("Order: 1");
                        spawn_order = 1;
                        break;
                    case "Second_Spawn":
                        //Debug.Log ("Order: 2");
                        spawn_order = 2;
                        break;
                    case "Third_Spawn":
                        //Debug.Log ("Order: 3");
                        spawn_order = 3;
                        break;
                    case "Fourth_Spawn":
                        //Debug.Log ("Order: 4");
                        spawn_order = 4;
                        break;
                    case "Fifth_Spawn":
                        //Debug.Log ("Order: 4");
                        spawn_order = 5;
                        break;
                    case "Sixth_Spawn":
                        //Debug.Log ("Order: 4");
                        spawn_order = 6;
                        break;
                    default:
                        //Debug.Log ("Not correct order");
                        spawn_order = 0;
                        break;
                }
            }
        }
        return temp;
    }


    private bool isContained(RectTransform whichIn, RectTransform whichHere) {

        Vector3 VecIn, VecHere;
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle (
                whichIn,
                Camera.main.WorldToScreenPoint (whichIn.position),
                Camera.main,
                out VecIn) &&
            RectTransformUtility.ScreenPointToWorldPointInRectangle (
                whichHere,
                Camera.main.WorldToScreenPoint (whichHere.position),
                Camera.main,
                out VecHere)) {

            //Debug.Log(VecIn);
            //Debug.Log(VecHere);
            if(Mathf.Abs (VecIn.x - VecHere.x) < 0.2 && Mathf.Abs (VecIn.y - VecHere.y) < 0.2) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }


}
