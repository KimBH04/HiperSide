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
    public bool isDie;

    [Header("status")]
    public int hp = 10;
    public int damage = 2;
    public float speed = 3f;

    [Range(0f, 30f)]
    public float distance = 10f;

    public float delay = 2f;

    public Transform pivot;

    State state;

    private Animator anime;
    private readonly int hashWalk = Animator.StringToHash("isWalking");
    private readonly int hashAttack = Animator.StringToHash("isAttack");

    void Start()
    {
        anime = GetComponent<Animator>();
        state = State.WALK;
        StartCoroutine(CheckingStatement());
    }

    void Update()
    {
        if (state == State.DIE)
            return;

        if (Physics.Raycast(transform.position, new Vector3(1f, 0f, 0f), out RaycastHit hit, distance))
        {
            if (hit.transform.CompareTag("UNIT"))
            {
                Unit unit = hit.transform.GetComponent<Unit>();
                if (unit.isEnemy != isEnemy)
                {
                    state = State.ATTACK;
                    unit.Damage(damage);
                    goto here;
                }
            }
        }
        state = State.WALK;
    here:;
        Debug.DrawRay(pivot.position, new Vector3(distance * (isEnemy ? -1 : 1), 0f, 0f), Color.red);

        if (state == State.WALK)
        {
            transform.position += speed * Time.deltaTime * new Vector3(isEnemy ? -1 : 1, 0f);
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            isDie = true;
            state = State.DIE;
            Destroy(gameObject, 1f);
        }
    }

    IEnumerator CheckingStatement()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.WALK:
                    anime.SetBool(hashWalk, true);
                    anime.SetBool(hashAttack, false);
                    break;

                case State.ATTACK:
                    anime.SetBool(hashWalk, false);
                    anime.SetBool(hashAttack, true);
                    break;

                case State.DIE:
                    isDie = true;
                    anime.SetBool(hashWalk, false);
                    anime.SetBool(hashAttack, false);
                    break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
