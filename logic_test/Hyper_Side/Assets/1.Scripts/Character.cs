using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : Unit
{
    [Range(.1f, 20f)]
    public float seeingDis = 1f;

    public float speed;

    private NavMeshAgent agent;

    void Awake()
    {
        Init();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = distance;
    }

    void FixedUpdate()
    {
        agent.destination = SeeingUnit() ?? TargetPosition;
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
