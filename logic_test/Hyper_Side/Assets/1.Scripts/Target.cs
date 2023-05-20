using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Vector3 unit;
    private bool isEnemy;

    void FixedUpdate()
    {
        transform.position = new(unit.x, transform.position.y, isEnemy ? -26.5f : 26.5f);
    }

    public void SetUnit(GameObject @object)
    {
        unit = @object.transform.position;
    }

    public void SetIsEnemy(bool isEnemy)
    {
        this.isEnemy = isEnemy;
    }
}
