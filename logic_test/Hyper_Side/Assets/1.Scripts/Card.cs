using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour
{
    public delegate void UnitSpawningHandler(GameObject unit, int wayIndex);
    public static event UnitSpawningHandler OnUnitSpawning;

    public delegate void DeckDrawingHandler(int idx);
    public static event DeckDrawingHandler OnDeckDrawing;

    public GameObject unit;
    private Deck deck;

    private int cardIndex;

    public int CardIndex
    {
        set => cardIndex = value;
    }

    Material mat;
    Vector3 defaultPos;

    void Start()
    {
        deck = GetComponentInParent<Deck>();
        mat = GetComponent<MeshRenderer>().materials[0];
        defaultPos = transform.localPosition;
    }

    void OnMouseDrag()
    {
        Vector3 m = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        transform.localPosition = new Vector3((m.x - 0.5f) * 12.7f, (m.y - 0.2f) * 6.5f, m.y * 3f);

        mat.color = new Color(1, 1, 1, 0.34f);

        Debug.Log(m.ToString());
    }

    void OnMouseUp()
    {
        float z = transform.localPosition.z;
        if (z < 2.5f)
        {
            if (z > 1.9f)
            {
                Debug.Log("3");

                ThrowCard(2);
                return;
            }
            else if (z > 1.3f)
            {
                Debug.Log("2");

                ThrowCard(1);
                return;
            }
            else if (z > 0.7f)
            {
                Debug.Log("1");

                ThrowCard(0);
                return;
            }
        }

        transform.DOLocalMove(defaultPos, 0.3f).SetEase(Ease.OutExpo);
        //transform.localPosition = defaultPos;
        mat.color = new Color(1, 1, 1, 1);
    }

    void ThrowCard(int idx)
    {
        GameObject card = Resources.Load<GameObject>("card");

        deck.unitQueue.Enqueue(card);
        OnUnitSpawning(unit, idx);
        OnDeckDrawing(cardIndex);
        Destroy(gameObject);
    }
}
