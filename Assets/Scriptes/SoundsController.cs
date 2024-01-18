using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioSource _audioSourceLaud;
    [SerializeField] private AudioSource _bubleAudioSource;
    [SerializeField] private AudioClip _steamSound;
    [SerializeField] private AudioClip _bubleSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip[] _winSounds;
    [SerializeField] private AudioClip[] _looseSounds;
    [SerializeField] private AudioClip _gameTheme;

    [SerializeField] private float _audioVolume, _audioLaudVolume;

    private bool _isWin;
    private bool _isLoose;
    private int _isSoundOn, _isMusicOn;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _isWin = false;
        _isLoose = false;
        CheckGameThemeSound();
        ActivateBubleSound();
    }
    private void OnEnable()
    {
        EventActionController.LavaTouchWaterAction += ActivateSteamSound;
        EventActionController.WinGameAction += ActivateWinSound;
        EventActionController.EndGameAction += ActivateLooseSound;
        EventActionController.ActivateBublesAction += ActivateBubleSound;
        EventActionController.EndExplosionBombAction += ActivateExplosionSound;
        EventActionController.MusicButtonClickAction += CheckGameThemeSound;
    }
    private void OnDisable()
    {
        EventActionController.LavaTouchWaterAction -= ActivateSteamSound;
        EventActionController.WinGameAction -= ActivateWinSound;
        EventActionController.EndGameAction -= ActivateLooseSound;
        EventActionController.ActivateBublesAction -= ActivateBubleSound;
        EventActionController.EndExplosionBombAction -= ActivateExplosionSound;
        EventActionController.MusicButtonClickAction -= CheckGameThemeSound;
    }

    private void ActivateSteamSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn == 1)
        {
            _audioSourceLaud.PlayOneShot(_steamSound);
        }
    }

    private void ActivateWinSound()
    {
        SetAudioVolume();
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (!_isWin && _isSoundOn == 1)
        {
            int count = _winSounds.Length;
            int rand = Random.Range(0, count);
            _audioSource.PlayOneShot(_winSounds[rand]);
            _isWin = true;
        }
        EventActionController.EndGameAction -= ActivateLooseSound;
    }

    private void ActivateLooseSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (!_isLoose && _isSoundOn == 1)
        {
            int count = _looseSounds.Length;
            int rand = Random.Range(0, count);
            _audioSource.PlayOneShot(_looseSounds[rand]);
            _isLoose = true;
        }
        EventActionController.WinGameAction -= ActivateWinSound;
    }
    private void SetAudioVolume()
    {
        _audioSource.volume = _audioVolume;
        _audioSourceLaud.volume = _audioLaudVolume;
    } 

    private void ActivateBubleSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn == 1)
        {
            _bubleAudioSource.PlayOneShot(_bubleSound);
        }
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
            _audioSource.clip = _gameTheme;
            _audioSource.loop = true;
            _audioSource.Play();
        }
        else if (_isMusicOn == 0)
        {
            _audioSource.Stop();
        }
    }
}
