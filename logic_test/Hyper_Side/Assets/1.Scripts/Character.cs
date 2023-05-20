using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : Unit
{
    [Range(.1f, 50f)]
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
        agent.destination = SeeingUnit() ?? target.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, seeingDis);
    }

    public override Vector3? SeeingUnit()
    {
        Vector3? r = null;
        Vector3 tp = transform.position;
        float dis = seeingDis * seeingDis;

        Collider[] colliders = Physics.OverlapSphere(tp, distance);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Ground"))
                continue;

            print(collider);

            Unit unit = collider.GetComponent<Unit>();
            bool[] tar = new bool[4];
            State state = unit.Sta & targetting;

            for (int i = 0; i < 4; i++)
            {
                tar[i] = ((int)state >> i) % 2 == 1;
            }

            if (!((tar[0] || tar[1]) && (tar[2] || tar[3])) || unit.Arm == base.Arm)
                continue;

            Vector3 collPos = collider.transform.position;
            float collDis = Mathf.Abs(Vector3.SqrMagnitude(tp) - Vector3.SqrMagnitude(collPos));

            if (collDis < dis)
            {
                dis = collDis;
                r = collPos;
            }
        }

        return r;
    }
}
