using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Unit
{
    public float lifeTime = 10f;

    void Awake()
    {
        Init();
    }

    void FixedUpdate()
    {
        
    }

    public override Vector3? SeeingUnit()
    {
        Vector3? r = null;
        float minDis = distance;

        Collider[] colliders = Physics.OverlapSphere(transform.position, distance);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Ground") ||
                collider.gameObject == gameObject ||
                collider.GetComponent<Unit>().Sta == base.Sta ||
                collider.gameObject.name.Equals("MyNexus"))
                continue;

            print(collider);

            Vector3 pos = collider.transform.position;
            float dis = Vector3.Distance(transform.position, pos);

            if (minDis > dis)
            {
                minDis = dis;
                r = pos;
            }
        }

        return r;
    }
}
