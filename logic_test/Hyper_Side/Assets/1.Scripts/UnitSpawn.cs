using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject ally;
    public GameObject enemy;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ArmySpawn(ally, 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ArmySpawn(enemy, 1);
        }
    }

    void ArmySpawn(GameObject army, int isEnemy)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                GameObject temp = Instantiate(army, hit.point + new Vector3(0f, 1f), Quaternion.Euler(0f, isEnemy * 180f, 0f));
            }
        }
    }
}
