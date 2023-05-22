using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform cam;

    private float clickPoint;

    void Awake()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            clickPoint = Input.mousePosition.x;

        }
    }
}
