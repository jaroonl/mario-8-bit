using System.Collections;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    public Sprite emptyBlock;
    public int maxHits = 1;

    private bool animating;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up))
            {
                Destroy(gameObject); 
            }
        }
    }
}
