using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public float maxPosition;
    void Start()
    {
        Move(0f);
    }

    public void Move(float position)
    {
        position -= .5f;
        transform.position = new Vector3(
            position * maxPosition,
            transform.position.y,
            transform.position.z);
    }
}
