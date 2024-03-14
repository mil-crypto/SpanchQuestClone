using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel, _winGamePanel , _engSuccesImage, _ruSuccesImage, _engFailImage, _ruFailImage;
    [SerializeField] private GameObject _hint;
    private Transform _startHintTransform;

    [SerializeField] private bool _isFirstLevel;

    [Header("SuccesPanel")]
    [SerializeField] private Transform _succesPanelEndPlace, _succesPanel, _restartButtomWinEndPlace, _restartButtomWin;

    [Header("FailPanel")]
    [SerializeField] private Transform _failEndPlace, _fail, _restartButtomFailPlace, _restartButtomFail;


    private string _lang;
    private void Awake()
    {
        _lang= YandexGame.EnvironmentData.language;
        SwitchLanguage(_lang);
    }
    void Start()
    {
        _startHintTransform = _hint.transform;
        if (_isFirstLevel)
        {
            RewardedForVideo();
        }
        else
        {
            _hint.SetActive(false);
        }
        _endGamePanel.SetActive(false);
        _winGamePanel.SetActive(false);
    }
    private void OnEnable()
    {
        EventActionController.WinGameAction += OpenWinGamePanel;
        EventActionController.WinGameAction += SuccesAnim;
        EventActionController.WinGameAction += RestartWinButtonAnim;

        EventActionController.EndGameAction += OpenEndGamePanel;
        EventActionController.EndGameAction += FailAnim;
        EventActionController.EndGameAction += RestartFailButtonAnim;

        YandexGame.CloseVideoEvent += RewardedForVideo;
    }

    private void OnDisable()
    {
        EventActionController.WinGameAction -= OpenWinGamePanel;
        EventActionController.WinGameAction -= SuccesAnim;
        EventActionController.WinGameAction -= RestartWinButtonAnim;

        EventActionController.EndGameAction -= OpenEndGamePanel;
        EventActionController.EndGameAction -= FailAnim;
        EventActionController.EndGameAction -= RestartFailButtonAnim;


        YandexGame.CloseVideoEvent -= RewardedForVideo;
    }
    public void RestartGame()
    {
        EventActionController.GetRestartEvent();
        EventActionController.GetButtonClickAction();
        EventActionController.GetButtonsSoundAction();
    }
    public void NextLevel()
    {
        EventActionController.GetNextLevelEvent();
        EventActionController.GetButtonClickAction();
        EventActionController.GetUpdateLevelAction();
        EventActionController.GetButtonsSoundAction();
    }

    private void OpenEndGamePanel()
    {
        _endGamePanel.SetActive(true);
        EventActionController.WinGameAction -= OpenWinGamePanel;
        EventActionController.WinGameAction -= SuccesAnim;
        EventActionController.WinGameAction -= RestartWinButtonAnim;

    }
    private void OpenWinGamePanel()
    {
        _winGamePanel.SetActive(true);
        EventActionController.EndGameAction -= OpenEndGamePanel;
        EventActionController.EndGameAction -= FailAnim;
        EventActionController.EndGameAction -= RestartFailButtonAnim;
    }

    public void SuccesAnim()
    {
        _succesPanel.DOMoveY(_succesPanelEndPlace.position.y,0.5f);
        if((int)_succesPanel.position.y== (int)_succesPanelEndPlace.position.y)
            EventActionController.GetStopGameEvent();
    }
    public void RestartWinButtonAnim()
    {
        _restartButtomWin.DOMoveY(_restartButtomWinEndPlace.position.y, 1f);
    }

    public void FailAnim()
    {
        _fail.DOMoveY(_failEndPlace.position.y, 0.5f);
        if((int)_fail.position.y==(int)_failEndPlace.position.y)
            EventActionController.GetStopGameEvent();
    }
    public void RestartFailButtonAnim()
    {
        _restartButtomFail.DOMoveY(_restartButtomFailPlace.position.y, 1f);
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
        EventActionController.GetButtonClickAction();
        EventActionController.GetUpdateLevelInMainMenuAction();
        EventActionController.GetButtonsSoundAction();

    }


    private void SwitchLanguage(string lang)
    {
        switch (lang)
        {
            case "ru":
                _ruSuccesImage.SetActive(true);
                _ruFailImage.SetActive(true);
                _engSuccesImage.SetActive(false);
                _engFailImage.SetActive(false);
                break;
            case "eng":
                _engSuccesImage.SetActive(true);
                _engFailImage.SetActive(true);
                _ruSuccesImage.SetActive(false);
                _ruFailImage.SetActive(false);
                break;
            default:
                _engSuccesImage.SetActive(true);
                _engFailImage.SetActive(true);
                _ruSuccesImage.SetActive(false);
                _ruFailImage.SetActive(false);
                break;
        }
    }

    private IEnumerator Wait(GameObject gameObject)
    {
        yield return new WaitForSecondsRealtime(6f);
        gameObject.SetActive(false);
    }


    private void RewardedForVideo()
    {
        _hint.transform.DOScale (new Vector2(1f,1f),0.001f);
        _hint.SetActive(true);
        _hint.transform.DOScale(new Vector2(1.6f,1.6f), 0.6f).SetLoops(-1,LoopType.Yoyo);
        StartCoroutine("Wait",_hint);
    }

}
