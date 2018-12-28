using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Camera cam;
    private void Start() {
        cam = GetComponent<Camera>();
    }
    public void Reposition(Vector2 dir) {
        Vector3 pos = transform.position;
        if(dir.x != 0) pos.x += cam.ViewportToWorldPoint(dir).x - pos.x;
        if(dir.y != 0) pos.y += cam.ViewportToWorldPoint(dir).y - pos.y;
        transform.position = pos;
    }
}