using System.Collections;
using UnityEngine;

public enum State
{
    WALK,
    ATTACK,
    DIE
}

public class Unit : MonoBehaviour
{
    public bool isEnemy;

    bool isDie;

    [Header("status")]
    public int hp = 10;
    public int damage = 2;
    public float speed = 3f;

    [Range(0f, 30f)]
    public float distance = 10f;

    public float delay = 2f;

    State state;

    void Start()
    {
        state = State.WALK;
        StartCoroutine(Statement());
    }

    void Update()
    {


        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance))
        {
            Unit unit = hit.transform.GetComponent<Unit>();
            if (unit.isEnemy != isEnemy)
            {

            }
        }

        Debug.DrawRay(transform.position, Vector3.forward, Color.red);
    }

    void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Statement()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.WALK:
                    break;

                case State.ATTACK:
                    break;

                case State.DIE:
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
