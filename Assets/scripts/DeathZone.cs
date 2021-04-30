using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Archer"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Archer"));
            GameOverManager.instance.OnPlayerDeath();
        }
    }
}
