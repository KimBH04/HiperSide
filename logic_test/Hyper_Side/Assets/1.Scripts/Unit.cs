using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public bool MyUnit;

    [SerializeField]
    private Position pos;

    [Header("Status")]
    public int hp;
    public int damage;

    public float delay;
    public float firstDelay;
    public float lastDelay;

    [Range(.1f, 10f)]
    public float distance = 1f;

    private GameObject targetNexus;
    private Transform target;
    private Transform tempTarget;

    public enum Position
    {
        Gound,
        Air
    }

    public Position Pos => pos;

    void Awake()
    {
        targetNexus = GameObject.Find(MyUnit ? "RivalNexus" : "MyNexus");
        target = targetNexus.transform;
        tempTarget = target;
    }

    public Vector3 Target
    {
        get
        {
            return targetNexus.transform.position;
            //이게 왜 null인데?!?!?!?!?!?!
        }
    }

    public virtual Vector3? SeeingUnit()
    {
        return target.position;
    }
}
