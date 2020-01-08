using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhit : MonoBehaviour
{
    [Header("傷害")]
    public int damage = 50;

    public float enemyhp = 10;

    public void DieFold(float damage)
    {
        enemyhp -= damage;

        if (enemyhp <= 0)
        {
            Destroy(gameObject);
            npc.count.PlayerGet();
        }
    }
}
