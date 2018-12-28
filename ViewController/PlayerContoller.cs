using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Use this for initialization
    public int speed = 5;
    Camera cam;
    public CameraController con;
    Rigidbody2D rb;
    Collider2D col;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        cam = con.cam;
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if(!GeometryUtility.TestPlanesAABB(planes, col.bounds)) {
            Vector3 pos = cam.WorldToViewportPoint(transform.position);
            Vector2 dir = Vector2.zero;
            if(pos.x >= 1) dir.x = 1;
            else if(pos.x <= 0) dir.x = -1;
            if(pos.y >= 1) dir.y = 1;
            else if(pos.y <= 0) dir.y = -1;
            con.Reposition(dir);
        }
        Vector2 vel = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        rb.velocity = vel;
    }
}