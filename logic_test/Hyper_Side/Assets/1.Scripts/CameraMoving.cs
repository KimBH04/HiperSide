using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public void Move(float position)
    {
        position -= .5f;
        transform.position = new Vector3(position * 50f, 10f, -20f);
    }
}
