using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public GameObject ground;
    Vector3 cameraPosition;
    Vector3 movement;
    Vector2 touchPosition1;
    Vector2 touchPosition2;
    public bool isCamera;

    void Start () {
        ground = GameObject.FindGameObjectWithTag("Ground");
	}
	
	void Update () {
        
	}

    private void LateUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCamera = false;
            touchPosition1 = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            touchPosition2 = Input.mousePosition;
            transform.RotateAround(ground.transform.position, Vector3.up, (touchPosition2.x - touchPosition1.x) / 20);
            //transform.Rotate(Vector3.left, (touchPosition2.y - touchPosition1.y) / 10);
            if (Mathf.Abs(touchPosition1.x - touchPosition2.x) > 5 || Mathf.Abs(touchPosition1.y - touchPosition2.y) > 5) {
                isCamera = true;
            }
            touchPosition1 = touchPosition2;
        }
    }
}
