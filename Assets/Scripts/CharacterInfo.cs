using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{

    public int maxHp = 100;
    public int currentHp = 100;

    public int playerDamage = 10;
    // Start is called before the first frame update

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        //Debug.Log("player hp: " + currentHp);
        // if (currentHp <= 0)
        //     gameObject.Destroy();
    }
}
