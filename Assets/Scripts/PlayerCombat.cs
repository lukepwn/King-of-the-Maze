using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Enemy enemyBat;
    CharacterInfo character;
    private Animator animator;
    public Transform attackPoint;
    [SerializeField] private float attackRangeX = 1.34f;
    [SerializeField] private float attackRangeY = 3.05f;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("ATTACK", true);

        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(attackRangeX, attackRangeY), 0f, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log(enemy.name);
            if (hitEnemies != null)
                enemy.GetComponent<Enemy>().TakeDamage(character.playerDamage);
        }


    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireCube(attackPoint.position, new Vector2(attackRangeX, attackRangeY));
    }
}
