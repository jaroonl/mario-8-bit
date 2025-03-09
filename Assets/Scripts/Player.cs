using UnityEngine;

public class Player : MonoBehaviour
{

    public void Hit()
    {
        Death();
    }

    private void Death()
    {
        GameManager.Instance.ResetLevel();
    }
}
