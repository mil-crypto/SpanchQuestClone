using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioSource _audioSourceGameTheme;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _winSounds;
    [SerializeField] private AudioClip _looseSounds;
    [SerializeField] private AudioClip _gameTheme;
    [SerializeField] private AudioClip _zombiSound;
    [SerializeField] private AudioClip _surpriseSound;
    [SerializeField] private AudioClip _selectorSound;
    [SerializeField] private AudioClip _buttonsSound;

    private bool _isWin;
    private bool _isLoose;
    private int _isSoundOn, _isMusicOn;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _isWin = false;
        _isLoose = false;
        CheckGameThemeSound();
    }
    private void OnEnable()
    {
        EventActionController.WinGameAction += ActivateWinSound;
        EventActionController.EndGameAction += ActivateLooseSound;
        EventActionController.EndExplosionBombAction += ActivateExplosionSound;
        EventActionController.MusicButtonClickAction += CheckGameThemeSound;
        EventActionController.SelectorAction += ActivateSelectorSound;
        EventActionController.OpenBlockAction += ActivateSurpriseSound;
        EventActionController.ZombiSoundAction += ActivateZombiSound;
        EventActionController.ButtonsSoundAction += ActivateButtonsSound;
    }
    private void OnDisable()
    {
        EventActionController.WinGameAction -= ActivateWinSound;
        EventActionController.EndGameAction -= ActivateLooseSound;
        EventActionController.EndExplosionBombAction -= ActivateExplosionSound;
        EventActionController.MusicButtonClickAction -= CheckGameThemeSound;
        EventActionController.SelectorAction -= ActivateSelectorSound;
        EventActionController.OpenBlockAction -= ActivateSurpriseSound;
        EventActionController.ZombiSoundAction -= ActivateZombiSound;
        EventActionController.ButtonsSoundAction -= ActivateButtonsSound;
    }

    private void ActivateSelectorSound()
    {
        _isSoundOn= PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn==1)
        {
            _audioSource.PlayOneShot(_selectorSound);
        }
    }

    private void ActivateButtonsSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn == 1)
        {
            _audioSource.PlayOneShot(_buttonsSound);
        }
    }
    private void ActivateSurpriseSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        var zombi = FindObjectOfType< ZombiCollisions > ();
        if (_isSoundOn == 1&&zombi!=null)
        {
            _audioSource.PlayOneShot(_surpriseSound);
        }
    }

    private void ActivateZombiSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn == 1)
        {
            _audioSource.PlayOneShot(_zombiSound);
        }
    }
    private void ActivateWinSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (!_isWin && _isSoundOn == 1)
        {
            _audioSource.PlayOneShot(_winSounds);
            _isWin = true;
        }
        EventActionController.EndGameAction -= ActivateLooseSound;
    }

    private void ActivateLooseSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (!_isLoose && _isSoundOn == 1)
        {
            _audioSource.PlayOneShot(_looseSounds);
            _isLoose = true;
        }
        EventActionController.WinGameAction -= ActivateWinSound;
    }

    private void ActivateExplosionSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn == 1)
        {
            _audioSource.PlayOneShot(_explosionSound);
        }
    }
    private void CheckGameThemeSound()
    {
        _isMusicOn = PlayerPrefs.GetInt("IsMusicOn");
        if (_isMusicOn == 1)
        {
            _audioSourceGameTheme.clip = _gameTheme;
            _audioSourceGameTheme.loop = true;
            _audioSourceGameTheme.Play();
        }
        else if (_isMusicOn == 0)
        {
            _audioSourceGameTheme.Stop();
        }
    }
}
