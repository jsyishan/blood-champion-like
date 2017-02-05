using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {


    public Text unitNameLabel;

    private Vector3 oriPos;
    private Vector3 oriScale;
    private int spawn_order = 0;
    private int spawn_cost = 0;
    private string spawn_unit = "";

    private Transform parentTrans;
    private int oriSiblingIndex;

    void Start() {

        //unitNameLabel.text = this.name;
    }

    public void OnBeginDrag(PointerEventData e) {

        oriPos = this.gameObject.GetComponent<RectTransform> ().position;
        oriScale = this.gameObject.GetComponent<RectTransform> ().localScale;
        spawn_unit = this.gameObject.name;

        parentTrans = transform.parent;
        oriSiblingIndex = transform.GetSiblingIndex ();
        transform.SetParent (transform.parent.parent.parent.parent.GetComponent<Transform> ());
    }

    public void OnDrag(PointerEventData e) {

        var rt = gameObject.GetComponent<RectTransform> ();
        rt.localScale = oriScale * 0.6f;

        Vector3 globalMousePos;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle (rt, e.position, e.pressEventCamera, out globalMousePos)) {
            rt.position = new Vector3 (globalMousePos.x, globalMousePos.y, globalMousePos.z + 1);
        }
    }

    public void OnEndDrag(PointerEventData e) {

        this.transform.SetParent (parentTrans);
        this.transform.SetSiblingIndex (oriSiblingIndex);
        this.transform.localScale = oriScale;

        EndJudging (e);
    }


    private void EndJudging(PointerEventData e) {

        var rt = gameObject.GetComponent<RectTransform> ();
        var target = SpawnOrder (rt);

        var suc = GameObject.Find ("SpawnUnitsCore").GetComponent<SpawnUnitsCore> ();

        if (target != null) {
            //Debug.Log ("Contained!");

            //Func<List<Spawn>, bool> cost = c =>
            //{
            //    MainCore.spawn_manager.GetSpawnList ().CopyTo (c.ToArray());
            //    return c.
            //};

            //if (MainCore.spawn_manager.curMoney > ) {

                MainCore.spawn_manager.AddSpawn (MainCore.spawn_manager.NewSpawn (spawn_unit, spawn_order));

                target.tag = "Untagged";
                target.gameObject.GetComponent<Image> ().material = Resources.Load ("Materials/spawn_zone_set") as Material;

                var spawnText = target.gameObject.GetComponentInChildren<Text> ();
                spawnText.text = unitNameLabel.text;
                spawnText.fontSize = 33;

                //MainCore.spawn_manager.curMoney -= 
                //suc.curMoney.text -= 
            //}

        } else {
            //Debug.Log ("Not correct space");
        }
        rt.position = oriPos;

    }


    private RectTransform SpawnOrder(RectTransform rt) {

        GameObject[] all_spawn_zones = GameObject.FindGameObjectsWithTag ("spawn");
        RectTransform temp = null;

        foreach (GameObject go in all_spawn_zones) {

            if (isContained (rt, go.GetComponent<RectTransform> ())) {
                temp = go.GetComponent<RectTransform> ();
                spawn_order = int.Parse (go.transform.parent.name.Substring (6));
                //switch (go.transform.parent.name) {
                //    case "First_Spawn":
                //        //Debug.Log ("Order: 1");
                //        spawn_order = 1;
                //        break;
                //    case "Second_Spawn":
                //        //Debug.Log ("Order: 2");
                //        spawn_order = 2;
                //        break;
                //    case "Third_Spawn":
                //        //Debug.Log ("Order: 3");
                //        spawn_order = 3;
                //        break;
                //    case "Fourth_Spawn":
                //        //Debug.Log ("Order: 4");
                //        spawn_order = 4;
                //        break;
                //    case "Fifth_Spawn":
                //        //Debug.Log ("Order: 4");
                //        spawn_order = 5;
                //        break;
                //    case "Sixth_Spawn":
                //        //Debug.Log ("Order: 4");
                //        spawn_order = 6;
                //        break;
                //    default:
                //        //Debug.Log ("Not correct order");
                //        spawn_order = 0;
                //        break;
                //}
            }
        }
        return temp;
    }


    private bool isContained(RectTransform whichIn, RectTransform whichHere) {

        Vector3 VecIn, VecHere;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle (
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
