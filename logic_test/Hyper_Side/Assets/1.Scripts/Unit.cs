using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private Army army;
    [SerializeField]
    private State state;
    [SerializeField]
    private State targetting;

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

    // ���� �� �ԷµǴ� ���ڿ� ���� Ÿ������ �˴ϴ�.
    // ���� :
    // 5 = Buliding + Ground; ���� �ִ� �����̸� ��� Ÿ���� �˴ϴ�.
    // 15 = Buliding + Character + Ground + Air; �ʵ忡 �ִ� ��� ������ Ÿ���� �˴ϴ�.
    //
    // �Ǵ� ������ ���¿� ���ؼ��� ������ �����մϴ�.
    // ���� :
    // 10 = Character + Ground; ���� ���� �Դϴ�.
    // ����� �� ���� ���� �Է��� ��� ������ ���� ������ ���� �� �ֽ��ϴ�.
    [Flags]
    public enum State
    {
        Building = 1,
        Character = 2,
        Ground = 4,
        Air = 8
    }

    public enum Army
    {
        Ally,
        Enemy,
        MidNexus
    }

    public State Sta => state;
    public Army Arm => army;

    public void Init()
    {
        if (army == Army.Ally)
        {
            targetNexus = GameObject.Find("RivalNexus");
        }
        else if (army == Army.Enemy)
        {
            targetNexus = GameObject.Find("MyNexus");
        }
        else
        {

        }

        target = targetNexus.transform;
        tempTarget = target;
    }

    public Vector3 TargetPosition
    {
        get
        {
            return target.position;
        }
    }

    public virtual Vector3? SeeingUnit()
    {
        return null;
    }
}
