using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("status")]
    public int hp = 10;
    public int damage = 2;
    public float speed = 3f;

    [Range(0f, 30f)]
    public float distance = 10f;

}
