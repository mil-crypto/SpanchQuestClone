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
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                break;
            case true when collision.collider.CompareTag("Jevelry"):
                EventActionController.GetLavaTouchEvent();
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                break;
            case true when collision.collider.CompareTag("Zombi"):
                EventActionController.GetLavaTouchZombiEvent();
                break;
        }
    }
}
