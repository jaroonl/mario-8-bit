using System.Collections;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public Sprite emptyBlock;
    public int maxHits = 1;

    private bool animating;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!animating && collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotTest(transform, Vector2.up))
            {
                Hit();
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        maxHits--;

        if(maxHits == 0)
        {
            spriteRenderer.sprite = emptyBlock;
        }

        StartCoroutine(Animate());

    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapse = 0f;
        float duration = 0.125f;

        while(elapse < duration)
        {
            float t = elapse/duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapse += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }
}
