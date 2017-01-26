using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn {

    public string spawn_unit;
    public int spawn_order;
   
    public Spawn(string unit, int order) {

        spawn_unit = unit;
        spawn_order = order;
    }

}
