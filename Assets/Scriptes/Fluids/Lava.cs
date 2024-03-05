using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (true)
        {
            case true when collision.collider.CompareTag("Player"):
                EventActionController.GetEndGameEvent();
                break;
            case true when collision.collider.CompareTag("Water"):
                EventActionController.GetLavaTouchEvent();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case true when collision.collider.CompareTag("Jevelry"):
                EventActionController.GetLavaTouchEvent();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case true when collision.collider.CompareTag("Zombi"):
                EventActionController.GetLavaTouchZombiEvent();
                break;
        }
    }
}
