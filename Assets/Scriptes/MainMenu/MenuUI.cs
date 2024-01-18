using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lvlText;
    [SerializeField] private GameObject _lock, _previousLevelButton, _nextLevelButton;
    [SerializeField] private Image _soundImage, _musicImage;
    [SerializeField] private Sprite _on, _of;
    [SerializeField] private GameObject _engChoiceRim, _ruChoiceRim;

    private int _currLvl;

    private void Start()
    {
        _lock.SetActive(false);
        CheckSoundAndMusic();
        GetCurentLevel();
        if (PlayerPrefs.GetInt("currentLevel") <= 0)
        {
            _lvlText.text = 1.ToString();
            _previousLevelButton.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("currentLevel") <= 1)
        {
            _previousLevelButton.SetActive(false);
        }
        StartCheckLangRim(PlayerPrefs.GetString("lang"));
    }

    private void OnEnable()
    {
        EventActionController.UpdateLevelInMainMenuAction += GetCurentLevel;
    }

    private void OnDisable()
    {
        EventActionController.UpdateLevelInMainMenuAction -= GetCurentLevel;
    }
    public void StartGame()
    {
        if (_currLvl <= SceneLoadInfo.GetMaxPassedLvl())
        {
            SceneManager.LoadScene(SceneLoadInfo.GetCurrentLevel());
        }
        EventActionController.GetButtonClickAction();
    }

    public void PreviousLevel()
    {
        _currLvl = SceneLoadInfo.GetCurrentLevel();
        int _maxCurLvl = SceneLoadInfo.GetMaxPassedLvl();

        if (_currLvl <= 1)
        {
            _lvlText.text = 1.ToString();
            SceneLoadInfo.SetCurrentLevel(1);
            _currLvl = 1;
            _lock.SetActive(false);
        }
        else if (_currLvl > 1)
        {
            _lvlText.text = (_currLvl - 1).ToString();
            SceneLoadInfo.SetCurrentLevel(_currLvl - 1);
            _lock.SetActive(false);
            _currLvl -= 1;
        }
        CheckButtonStatus(_currLvl, _maxCurLvl);
        EventActionController.GetButtonClickAction();
    }

    public void NextLevel()
    {
        _currLvl = SceneLoadInfo.GetCurrentLevel();
        int _maxCurLvl = SceneLoadInfo.GetMaxPassedLvl();

        if (_maxCurLvl >= SceneLoadInfo.MaxLevel)
            _maxCurLvl = SceneLoadInfo.MaxLevel;
        if (_currLvl < _maxCurLvl && _currLvl < SceneLoadInfo.MaxLevel)
        {
            SceneLoadInfo.SetCurrentLevel(_currLvl + 1);
            _lvlText.text = (_currLvl + 1).ToString();
            _currLvl += 1;
        }
        else if (_currLvl == _maxCurLvl && _currLvl < SceneLoadInfo.MaxLevel)
        {
            _lvlText.text = (_currLvl + 1).ToString();
            _lock.SetActive(true);
            _currLvl += 1;

        }
        CheckButtonStatus(_currLvl, _maxCurLvl);
        EventActionController.GetButtonClickAction();
    }
    public void SoundCheck()
    {
        if (PlayerPrefs.GetInt("IsSoundOn") == 0)
        {
            PlayerPrefs.SetInt("IsSoundOn", 1);
            _soundImage.sprite = _on;
        }
        else if (PlayerPrefs.GetInt("IsSoundOn") == 1)
        {
            PlayerPrefs.SetInt("IsSoundOn", 0);
            _soundImage.sprite = _of;
        }
        EventActionController.GetButtonClickAction();
    }
    public void MusicCheck()
    {
        if (PlayerPrefs.GetInt("IsMusicOn") == 0)
        {
            PlayerPrefs.SetInt("IsMusicOn", 1);
            _musicImage.sprite = _on;
        }
        else if (PlayerPrefs.GetInt("IsMusicOn") == 1)
        {
            PlayerPrefs.SetInt("IsMusicOn", 0);
            _musicImage.sprite = _of;
        }
        EventActionController.GetMusicButtonClickAction();
    }

    private void CheckSoundAndMusic()
    {
        if (PlayerPrefs.GetInt("IsSoundOn") == 0)
        {
            _soundImage.sprite = _of;
        }
        else if (PlayerPrefs.GetInt("IsSoundOn") == 1)
        {
            _soundImage.sprite = _on;
        }
        if (PlayerPrefs.GetInt("IsMusicOn") == 0)
        {
            _musicImage.sprite = _of;
        }
        else if (PlayerPrefs.GetInt("IsMusicOn") == 1)
        {
            _musicImage.sprite = _on;
        }
    }

    private void GetCurentLevel()
    {
        _lvlText.text = PlayerPrefs.GetInt("currentLevel").ToString();
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }

    private void CheckButtonStatus(int curLvl, int maxLvl)
    {
        if (curLvl <= 1)
        {
            _previousLevelButton.SetActive(false);
            _nextLevelButton.SetActive(true);
        }
        else if (curLvl > 1 && curLvl < maxLvl)
        {
            _previousLevelButton.SetActive(true);
            _nextLevelButton.SetActive(true);
        }
        else if (curLvl >= maxLvl + 1||curLvl>=20)
        {
            _previousLevelButton.SetActive(true);
            _nextLevelButton.SetActive(false);
        }
    }

    public void RuLangButton()
    {
        _ruChoiceRim.SetActive(true);
        _engChoiceRim.SetActive(false);
        PlayerPrefs.SetString("lang", "ru");
        Debug.Log("lang= " + PlayerPrefs.GetString("lang"));
    }

    public void EngLangButton()
    {
        _ruChoiceRim.SetActive(false);
        _engChoiceRim.SetActive(true);
        PlayerPrefs.SetString("lang", "eng");
        Debug.Log("lang= " + PlayerPrefs.GetString("lang"));
    }
    private void StartCheckLangRim(string lang)
    {
        switch (lang)
        {
            case "ru":
                _ruChoiceRim.SetActive(true);
                _engChoiceRim.SetActive(false);
                break;
            case "eng":
                _ruChoiceRim.SetActive(false);
                _engChoiceRim.SetActive(true);
                break;
            default:
                _ruChoiceRim.SetActive(true);
                _engChoiceRim.SetActive(false);
                break;
        }
    }
}
