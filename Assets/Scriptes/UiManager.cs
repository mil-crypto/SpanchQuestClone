using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel, _winGamePanel , _engSuccesImage, _ruSuccesImage, _engFailImage, _ruFailImage;
    [SerializeField] private TextMeshProUGUI _levelText;
    [Header("SuccesPanel")]
    [SerializeField] private Transform _succesPanelEndPlace, _succesPanel, _restartButtomWinEndPlace, _restartButtomWin;

    [Header("FailPanel")]
    [SerializeField] private Transform _failEndPlace, _fail, _restartButtomFailPlace, _restartButtomFail;

    private string _lang;
    private void Awake()
    {
        _lang= YandexGame.EnvironmentData.language;
        SwitchLanguage("eng");
    }
    void Start()
    {
        _endGamePanel.SetActive(false);
        _winGamePanel.SetActive(false);
        Debug.Log("Lang= " + _lang);
        _levelText.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
    private void OnEnable()
    {
        EventActionController.WinGameAction += OpenWinGamePanel;
        EventActionController.WinGameAction += SuccesAnim;
        EventActionController.WinGameAction += RestartWinButtonAnim;

        EventActionController.EndGameAction += OpenEndGamePanel;
        EventActionController.EndGameAction += FailAnim;
        EventActionController.EndGameAction += RestartFailButtonAnim;

        EventActionController.UpdateLevelAction += UpdateLevelNumber;
    }

    private void OnDisable()
    {
        EventActionController.WinGameAction -= OpenWinGamePanel;
        EventActionController.WinGameAction -= SuccesAnim;
        EventActionController.WinGameAction -= RestartWinButtonAnim;

        EventActionController.EndGameAction -= OpenEndGamePanel;
        EventActionController.EndGameAction -= FailAnim;
        EventActionController.EndGameAction -= RestartFailButtonAnim;

        EventActionController.UpdateLevelAction -= UpdateLevelNumber;
    }
    public void RestartGame()
    {
        EventActionController.GetRestartEvent();
        EventActionController.GetButtonClickAction();
    }
    public void NextLevel()
    {
        EventActionController.GetNextLevelEvent();
        EventActionController.GetButtonClickAction();
        EventActionController.GetUpdateLevelAction();
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
    }

    private void UpdateLevelNumber()
    {
        _levelText.text = SceneLoadInfo.GetCurrentLevel().ToString();
        
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
                _ruSuccesImage.SetActive(true);
                _ruFailImage.SetActive(true);
                _engSuccesImage.SetActive(false);
                _engFailImage.SetActive(false);
                break;
        }
    }
}
