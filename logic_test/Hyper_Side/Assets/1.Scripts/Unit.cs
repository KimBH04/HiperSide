﻿using System;
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
    protected State targetting;
    // protected : 외부 클래스에서 접근할 수 없지만
    // 상속받은 자식 클래스에선 접근할 수 있습니다.

    [Header("Status")]
    public int hp;
    public int damage;

    public float delay;
    public float firstDelay;
    public float lastDelay;

    [Range(.1f, 10f)]
    public float distance = 1f;

    protected GameObject targetNexus;
    private Transform target;
    private Transform tempTarget;

    // 선언 시 입력되는 숫자 또는 인스펙터에서 체크한 값에 따라 타겟팅이 됩니다.
    // 예시 :
    // 5 = Buliding + Ground; 지상에 있는 유닛이면 모두 타겟팅 됩니다.
    // 15 = Buliding + Character + Ground + Air; 필드에 있는 모든 유닛이 타겟팅 됩니다.
    //
    // 또는 유닛의 상태에 대해서도 선언이 가능합니다.
    // 예시 :
    // 10 = Character + Ground; 지상 유닛 입니다.
    // 사용할 수 없는 값을 입력한 경우 예기지 못한 오류가 생길 수 있습니다.
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
            targetNexus = gameObject;
        }

        target = targetNexus.transform;
        tempTarget = target;
    }

    public Transform TargetTrans
    {
        get
        {
            if (!target)
                target = tempTarget;

            return target;
        }

        set
        {
            target = value;
        }
    }

    public virtual Vector3? SeeingUnit()
    {
        return new();
    }
}
