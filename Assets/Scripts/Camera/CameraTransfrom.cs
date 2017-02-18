using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransfrom : MonoBehaviour {

    private Transform camTrans;
    
    private bool isEntering = false;
    private int direction = 0;

    private float rotX;
    private float rotY;

    public float TRANS_SPEED = 3.0f;

    public float SCALE_SENSETIVE = 5.0f;
    public float MAX_SCALE_SIZE = 30.0f;
    public float MIN_SCALE_SIZE = 3.0f;

    public float ROTATE_SPEED = 1.5f;
    public float MAX_ROTATE_ANGLE = 30.0f;
    public float MIN_ROTATE_ANGLE = 10.0f;


	void Start () {

        camTrans = this.transform;
        rotX = camTrans.eulerAngles.x;
        rotY = camTrans.eulerAngles.y;
	}
	
	void Update () {

        OnMouseScroll ();
        OnMouseRotate ();
        OnMouseTranslate ();
	}

    private void OnMouseScroll() {

        var fov = Camera.main.fieldOfView;
        fov += -Input.GetAxis ("Mouse ScrollWheel") * SCALE_SENSETIVE;
        Camera.main.fieldOfView = Mathf.Clamp (fov, MIN_SCALE_SIZE, MAX_SCALE_SIZE);
    }

    private float ClampAngle(float angle, float min, float max) {

        if (angle < -360) {
            angle += 360;
        } else if (angle > 360) {
            angle -= 360;
        }
        return Mathf.Clamp (angle, min, max);
    }

    private void OnMouseRotate() {

        if (Input.GetKey (KeyCode.Mouse1)) {

            rotX += Input.GetAxis ("Mouse X") * ROTATE_SPEED;
            rotY -= Input.GetAxis ("Mouse Y") * ROTATE_SPEED;

            rotY = ClampAngle (rotY, MIN_ROTATE_ANGLE, MAX_ROTATE_ANGLE);

            var rot = Quaternion.Euler (rotY, rotX, 0);
            camTrans.rotation = Quaternion.Slerp (camTrans.rotation, rot, Time.deltaTime * 3.0f);

        }
    }

    private void OnMouseTranslate() {

        if (isEntering) {
            switch (direction) {
                //Left
                case 0:
                camTrans.position = new Vector3 (camTrans.position.x - Time.deltaTime * TRANS_SPEED, camTrans.position.y, camTrans.position.z);
                break;
                //Right
                case 1:
                camTrans.position = new Vector3 (camTrans.position.x + Time.deltaTime * TRANS_SPEED, camTrans.position.y, camTrans.position.z);
                break;
                //Top
                case 2:
                camTrans.position = new Vector3 (camTrans.position.x, camTrans.position.y, camTrans.position.z + Time.deltaTime * TRANS_SPEED);
                break;
                //Bottom
                case 3:
                camTrans.position = new Vector3 (camTrans.position.x, camTrans.position.y, camTrans.position.z - Time.deltaTime * TRANS_SPEED);
                break;
            }
        }
    }

    public void OnMouseEnter(int dir) {

        direction = dir;
        isEntering = true;
    }

    public void OnMouseExit() {

        isEntering = false;
    }
}
