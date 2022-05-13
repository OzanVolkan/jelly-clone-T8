using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMove : MonoBehaviour
{
    public static JellyMove instance;

    public float lerpValue = 4f;
    public float minY, maxY;
    public float minX, maxX;

    Camera cam;
    void Start()
    {
        instance = this;
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Movement();
        }
    }
    public void Movement()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 moveVec = cam.ScreenToWorldPoint(mousePos);
        float x = transform.localScale.x;
        moveVec.z = transform.localScale.z;
        moveVec.y *= 2f;
        moveVec.y = Mathf.Clamp(moveVec.y, minY, maxY);
        x = maxY / moveVec.y;

        moveVec.x = Mathf.Clamp(x, minX, maxX);

        transform.localScale = Vector3.Lerp(transform.localScale, moveVec, lerpValue);

        GhostJelly.instance.GhostScale(moveVec);
    }
}
