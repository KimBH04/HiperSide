using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnController : MonoBehaviour
{
    public Transform[] spawnTrans = new Transform[3];

    void Awake()
    {
        Card.OnUnitSpawning += UnitSpawning;
    }

    void UnitSpawning(GameObject unit, int wayIndex)
    {
        Instantiate(unit, spawnTrans[wayIndex].position, Quaternion.Euler(0f, 90f, 0f));
    }
}
