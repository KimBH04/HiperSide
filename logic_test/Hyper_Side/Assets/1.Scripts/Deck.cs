using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Transform camPos;
    public List<GameObject> units;

    private GameObject[] deck = new GameObject[4];

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            int idx = Random.Range(0, units.Count);
            deck[i] = units[idx];
            units.RemoveAt(idx);

            GameObject card = Instantiate(deck[i], transform.position + new Vector3(i * 1.7f, -1f), Quaternion.Euler(30f, 0, 0));
            card.transform.parent = transform;
        }
    }

    void Update()
    {
        transform.position = new Vector3(camPos.position.x, 0f, -6f);
    }
}
