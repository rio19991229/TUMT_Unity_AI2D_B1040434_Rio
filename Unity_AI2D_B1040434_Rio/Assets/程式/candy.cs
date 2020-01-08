using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "play")
        {
            Destroy(gameObject);
            npc.count.countCandy += 1;
        }
    }
}
