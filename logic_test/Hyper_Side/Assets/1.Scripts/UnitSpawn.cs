using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject unit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    GameObject temp = Instantiate(unit, hit.point + new Vector3(0f, 1f), Quaternion.identity);
                    /*temp.transform.position = hit.point + new Vector3(0f, 1f, 0f);*/
                }
            }
        }
    }
}
