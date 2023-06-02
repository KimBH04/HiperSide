using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Transform camPos;
    public List<GameObject> unitCards;
    public Queue<GameObject> unitQueue;

    private GameObject[] deck = new GameObject[4];

    void Start()
    {
        unitQueue = new();
        Card.OnDeckDrawing += Draw;

        for (int i = 0; i < 8; i++)
        {
            int idx = Random.Range(0, unitCards.Count);
            unitQueue.Enqueue(unitCards[idx]);
            unitCards.RemoveAt(idx);
        }

        for (int i = 0; i < 4; i++)
        {
            Draw(i);
        }
    }

    void Update()
    {
        transform.position = camPos.position + new Vector3(0f, -5f, 4f);
    }

    void Draw(int i)
    {
        int idx = Random.Range(0, unitCards.Count);
        deck[i] = Instantiate(unitCards[idx], transform.position + new Vector3(i * 1.7f, -1f), Quaternion.Euler(30f, 0, 0));
        deck[i].transform.parent = transform;
        deck[i].GetComponent<Card>().CardIndex = i;

        unitCards.RemoveAt(idx);

        unitCards.Add(unitQueue.Dequeue());
    }
}
