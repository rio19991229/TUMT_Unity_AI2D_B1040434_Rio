using UnityEngine;

public class die : MonoBehaviour
{
    public int damage = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<play>().Damage(damage);
        }
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemy>().DieFold(damage);
        }
    }
}
