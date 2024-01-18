using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (true)
        {
            case true when collision.collider.CompareTag("Player"):
                EventActionController.GetWinGameEvent();
                break;
        }
    }
}
