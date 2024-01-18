using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator _spanchWinAnimator;
    [SerializeField] private GameObject _spanchNormal, _spanchSad,  _spanchFan;
    private void Start()
    {
        _spanchWinAnimator.SetInteger("Win",0);
        _spanchNormal.SetActive(true);
        _spanchSad.SetActive(false);
        _spanchFan.SetActive(false);
    }
    private void OnEnable()
    {
        EventActionController.WinGameAction += GetRandomWinAnim;
        EventActionController.EndGameAction += GetLooseAnim;
    }

    private void OnDisable()
    {
        EventActionController.WinGameAction -= GetRandomWinAnim;
        EventActionController.EndGameAction -= GetLooseAnim;
    }

    private void GetRandomWinAnim()
    {
        _spanchSad.SetActive(false);
        _spanchNormal.SetActive(false);
        _spanchFan.transform.position = _spanchNormal.transform.position;
        _spanchFan.SetActive(true);
        int _currentWinAnim = Random.Range(1, 4);
        _spanchWinAnimator.SetInteger("Win", _currentWinAnim);
        int id= _spanchWinAnimator.GetInteger("Win");
    }

    private void GetLooseAnim()
    {
        _spanchNormal.SetActive(false);
        _spanchFan.SetActive(false);
        _spanchSad.transform.position = _spanchNormal.transform.position;
        _spanchSad.SetActive(true);
    }
}
