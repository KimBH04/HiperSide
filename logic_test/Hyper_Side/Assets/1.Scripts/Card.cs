using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    public delegate void UnitSpawningHandler(GameObject unit, int wayIndex);
    public static event UnitSpawningHandler OnUnitSpawning;

    public GameObject unit;

    Material mat;
    Vector3 defaultPos;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().materials[0];
        defaultPos = transform.localPosition;
    }

    void OnMouseDrag()
    {
        Vector3 m = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        transform.localPosition = new Vector3((m.x - 0.5f) * 12.7f, (m.y - 0.2f) * 6.5f, m.y * 3f);

        mat.color = new Color(1, 1, 1, 0.34f);

        //Debug.Log(m.ToString());
    }

    void OnMouseUp()
    {
        float z = transform.localPosition.z;
        if (z > 2.1f)
        {
            Debug.Log("3");
            OnUnitSpawning(unit, 2);
        }
        else if (z > 1.4f)
        {
            Debug.Log("2");
            OnUnitSpawning(unit, 1);
        }
        else if (z > 0.7f)
        {
            Debug.Log("1");
            OnUnitSpawning(unit, 0);
        }
        else
        {
            transform.DOLocalMove(defaultPos, 0.3f).SetEase(Ease.OutExpo);
            //transform.localPosition = defaultPos;
            mat.color = new Color(1, 1, 1, 1);
        }
    }
}
