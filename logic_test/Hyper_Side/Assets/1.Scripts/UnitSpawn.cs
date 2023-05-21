using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject ally;
    public GameObject enemy;

    public GameObject target;

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
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Ground"))
        {
            GameObject unit = Instantiate(army, hit.point + new Vector3(0f, 1f), Quaternion.Euler(0f, isEnemy * 180f, 0f));
            GameObject temp = Instantiate(target, unit.transform.position + new Vector3(0f, 1f, isEnemy == 0 ? 26.5f : -26.5f), Quaternion.identity);
            Target tar = temp.GetComponent<Target>();

            unit.GetComponent<Unit>().SetTarget(temp);

            tar.SetUnit(unit);
            tar.SetIsEnemy(isEnemy == 1);
        }
    }
}
