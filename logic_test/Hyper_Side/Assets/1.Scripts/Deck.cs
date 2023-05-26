using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Transform camPos;
    public List<GameObject> unitCards;

    private GameObject[] deck = new GameObject[4];

    void Start()
    {
        Card.OnDeckDrawing += Drawing;

        for (int i = 0; i < 4; i++)
        {
            Draw(i);

            GameObject card = Instantiate(deck[i], transform.position + new Vector3(i * 1.7f, -1f), Quaternion.Euler(30f, 0, 0));
            card.transform.parent = transform;
        }
    }

    void Update()
    {
        transform.position = new Vector3(camPos.position.x, 0f, -6f);
    }

    void Drawing()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!deck[i])
            {
                Draw(i);
            }
        }
    }
    void Draw(int i)
    {
        int idx = Random.Range(0, unitCards.Count);
        deck[i] = unitCards[idx];
        unitCards.RemoveAt(idx);
    }
}
