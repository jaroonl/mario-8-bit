using UnityEngine;

public class Goomba : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(collision.transform.DotTest(transform, Vector2.down))
            {
                GetComponent<Collider2D>().enabled = false;
                GetComponent<EntityMovement>().enabled = false;
                Destroy(gameObject);
            } else
            {
                player.Hit();
            }
        }
    }
}
