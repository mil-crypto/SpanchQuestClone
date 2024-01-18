using UnityEngine;
public class MrCrabs : MonoBehaviour
{
    [SerializeField] private Animator _mrCrabsAnimator;
    [SerializeField] private Color _mrCrabsDeathColor;
    [SerializeField] private Vector2 _posWalkLeft, _posWalkRight;
    [SerializeField] private int _mrCrabsSpeed;
    [SerializeField] private float _startTimer;
    [SerializeField] private bool _mrCrabsRandomWalkLeft;
    [SerializeField] private bool _isWalk;
    private bool _onFloor;
    private float _timer;
    private Rigidbody2D _mrCrabsRigid;
    private int _direction;
    private void Start()
    {
        _timer = _startTimer;
        _mrCrabsRigid = GetComponent<Rigidbody2D>();
        _mrCrabsAnimator.SetBool("IsDeath", false);
        _direction = 0;

    }
    private void Update()
    {
            CheckMrCrabs();
        if (_mrCrabsAnimator.GetInteger("IsWin") == 0)
        {
            _mrCrabsRigid.velocity = new Vector2(_direction * _mrCrabsSpeed, 0); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (true)
        {
            case true when collision.collider.CompareTag("Player"):
                EventActionController.GetEndGameEvent();
                break;
            case true when collision.collider.CompareTag("Floor"):
                _onFloor = true;
                break;
        }
    }
    private void OnEnable()
    {
        EventActionController.LavaTouchCrabsAction += MrCrabsLooseAnim;
        EventActionController.EndGameAction += MrCrabsWinAnim;
        EventActionController.EndGameAction += MrCrabsRemoveCollider;
        EventActionController.WinGameAction += MrCrabsRemoveCollider;
    }

    private void OnDisable()
    {
        EventActionController.LavaTouchCrabsAction -= MrCrabsLooseAnim;
        EventActionController.EndGameAction -= MrCrabsWinAnim;
        EventActionController.EndGameAction -= MrCrabsRemoveCollider;
        EventActionController.WinGameAction -= MrCrabsRemoveCollider;
    }
    private void CheckMrCrabs()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            if (_mrCrabsRandomWalkLeft)
            {
                _isWalk = false;
                _direction = MrCrabsRandomWalkLeft(_direction);
            }
            else if (_isWalk&&_onFloor)
            {
                _mrCrabsRandomWalkLeft = false;
                _direction = MrCrabsRandomWalk(_direction);
            }
            else if (!_mrCrabsRandomWalkLeft&&!_isWalk)
            {
                _mrCrabsAnimator.SetInteger("Speed", 0);
            }
            _timer = _startTimer;
        }
    }
    private int MrCrabsRandomWalkLeft(int currentDirection)
    {
        int randLeft = Random.Range(-1, 1);
        int randRight = Random.Range(0, 2);
        int dir = 0;
        switch (currentDirection)
        {
            case 0:
                dir = -1;
                _mrCrabsAnimator.SetBool("IsRight", false);
                break;
            case 1:
                dir = randLeft;
                if (dir == -1)
                {
                    _mrCrabsAnimator.SetBool("IsRight", false);
                    _timer = 1;
                }
                else if (dir == 0)
                {
                    _timer = 0.5f;
                }
                break;
            case -1:
                dir = randRight;
                if (dir == 1)
                {
                    _mrCrabsAnimator.SetBool("IsRight", true);
                    _timer = 0.5f;
                }
                else if (dir == 0)
                {
                    _timer = 0.5f;
                }
                break;
        }
        _mrCrabsAnimator.SetInteger("Speed", dir);
        return dir;
    }

    private int MrCrabsRandomWalk(int currentDirection)
    {
        int randLeft = Random.Range(-1, 1);
        int randRight = Random.Range(0, 2);
        int rand = Random.Range(-1, 2);
        int dir = 0;
        switch (currentDirection)
        {
            case 0:
                dir = rand;
                _mrCrabsAnimator.SetBool("IsRight", false);
                break;
            case 1:
                dir = randLeft;
                if (dir == -1)
                {
                    _mrCrabsAnimator.SetBool("IsRight", false);
                    _timer = 1;
                }
                else if (dir == 0)
                {
                    _timer = 0.1f;
                }
                break;
            case -1:
                dir = randRight;
                if (dir == 1)
                {
                    _mrCrabsAnimator.SetBool("IsRight", true);
                    _timer = 1f;
                }
                else if (dir == 0)
                {
                    _timer = 0.1f;
                }
                break;
        }
        _mrCrabsAnimator.SetInteger("Speed", dir);
        return dir;
    }
    private void MrCrabsLooseAnim()
    {
        _mrCrabsAnimator.SetInteger("IsWin", -1);
        _mrCrabsRigid.GetComponent<SpriteRenderer>().color = _mrCrabsDeathColor;
    }
    private void MrCrabsWinAnim()
    {
        _mrCrabsAnimator.SetInteger("IsWin", 1);
    }
    private void MrCrabsRemoveCollider()
    {
        if (_mrCrabsAnimator.GetInteger("IsWin") != 0)
        {
            _mrCrabsRigid.GetComponent<Rigidbody2D>().isKinematic = true;
            _mrCrabsRigid.GetComponent<Collider2D>().enabled = false;
            _mrCrabsRigid.velocity = new Vector2(0, 0);
        }
    }
}
