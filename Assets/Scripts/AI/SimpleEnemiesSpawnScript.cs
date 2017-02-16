using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemiesSpawnScript : MonoBehaviour {

    public float deltaTime = 10.0f;
    public GameObject enemy;

    private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer >= deltaTime) {

            timer = 0;
            var go = Instantiate (enemy, this.transform.position, Quaternion.identity) as GameObject;
            go.tag = "AI";

        }
	}
}
