using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : Unit
{
    public float speed;

    [Range(.1f, 20f)]
    public float seeingDis = 1f;

    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void FixedUpdate()
    {
        agent.destination = SeeingUnit() ?? Target;
    }

    public override Vector3? SeeingUnit()
    {
        Vector3? r = null;
        float minDis = seeingDis;

        Collider[] colliders = Physics.OverlapSphere(transform.position, seeingDis);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Ground") ||
                collider.gameObject == gameObject ||
                collider.GetComponent<Unit>().MyUnit == MyUnit ||
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
