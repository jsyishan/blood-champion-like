using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn {

    private string spawn_unit;
    private int spawn_order;
    private int spawn_cost;
   
    public Spawn(string unit, int order) {

        spawn_unit = unit;
        spawn_order = order;
    }

    public string GetUnit() {
        return spawn_unit;
    }

    public int GetOrder() {
        return spawn_order;
    }

}
