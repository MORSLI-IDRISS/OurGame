using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelend : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Archer"))
        {
            SceneManager.LoadScene("level01");
        }
    }

}
