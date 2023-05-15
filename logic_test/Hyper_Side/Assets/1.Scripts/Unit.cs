using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private bool MyUnit;

    [SerializeField]
    private Position pos;

    [SerializeField]
    private State state;

    [Header("Status")]
    public int hp;
    public int damage;
    public float speed;

    [Range(.1f, 20f)]
    public float seeingDis = 1f;

    [Range(.1f, 10f)]
    public float distance = 1f;

    public float delay;
    public float firstDelay;
    public float lastDelay;

    private GameObject _Nexus;
    //private Nexus nex;
    private Transform Target;
    private Transform targetTemp;

    private NavMeshAgent agent;

    public enum Position
    {
        Gound,
        Air
    }

    public enum State
    {
        Character,
        Building
    }

    public bool IsEnemy => !MyUnit;
    public Position Pos => pos;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        _Nexus = GameObject.Find(MyUnit ? "MyNexus" : "RivalNexus");
        Target = _Nexus.transform;

        targetTemp = Target;

        if (state == State.Building)
            speed = 0f;
    }

    void FixedUpdate()
    {
        agent.destination = SeeingUnit() ?? Target.position;
    }

    Vector3? SeeingUnit()
    {
        Vector3? r = null;
        float minDis = seeingDis;

        Collider[] colliders = Physics.OverlapSphere(transform.position, seeingDis);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Ground"))
                return null;

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
