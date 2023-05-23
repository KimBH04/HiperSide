using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool isEnemy;

    [Header("status")]
    public int hp = 10;
    public int damage = 2;
    public float speed = 3f;

    [Range(0f, 30f)]
    public float distance = 10f;

    void Awake()
    {
        
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance))
        {
            Unit unit = hit.transform.GetComponent<Unit>();
            if (unit.isEnemy != isEnemy)
            {
                unit.Hit(damage);
            }
        }
    }

    void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
