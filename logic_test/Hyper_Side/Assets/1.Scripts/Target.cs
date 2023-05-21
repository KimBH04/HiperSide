using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Transform unit;
    private bool isEnemy;

    void FixedUpdate()
    {
        transform.position = new(unit.position.x, transform.position.y, isEnemy ? -30f : 30f);
    }

    public void SetUnit(GameObject @object)
    {
        unit = @object.transform;
    }

    public void SetIsEnemy(bool isEnemy)
    {
        this.isEnemy = isEnemy;
    }
}
