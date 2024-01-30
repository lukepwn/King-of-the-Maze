using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int damage = 1;
    [SerializeField] private int currentHp = 100;
    private Rigidbody2D rb;
    private GameObject targetGameobject;
    public float speed = 2f;

    public GameObject bat;


    CharacterInfo targetCharacter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetGameobject = target.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Target();
    }

    void Target()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<CharacterInfo>();
        }
        targetCharacter.TakeDamage(damage);

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log("bat hp: " + currentHp);

        if (currentHp <= 0)
            Destroy(bat);
    }
}
