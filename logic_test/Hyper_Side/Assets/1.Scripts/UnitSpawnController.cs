using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnController : MonoBehaviour
{
    public Vector3[] spawnPos = new Vector3[3];

    void Awake()
    {
        Card.OnUnitSpawning += UnitSpawning;
    }

    void UnitSpawning(GameObject unit, int wayIndex)
    {
        Instantiate(unit, spawnPos[wayIndex], Quaternion.Euler(0f, 90f, 0f));
    }
}
