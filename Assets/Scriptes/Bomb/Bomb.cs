using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Bomb : MonoBehaviour
{
    private Rigidbody2D _bombRigid;

    private void Start()
    {
        _bombRigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava")|| collision.gameObject.CompareTag("Water"))
        {
            _bombRigid.velocity = new Vector2(0, 0);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            _bombRigid.velocity = new Vector2(0, _bombRigid.velocity.y);
        }

    }
}
