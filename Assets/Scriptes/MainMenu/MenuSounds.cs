using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MenuSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _bylBylSound;
    [SerializeField] private AudioClip _menuTheme;
    private int _isSoundOn, _isMusicOn;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        CheckMenuThemeSound();
    }
    private void OnEnable()
    {
        EventActionController.ButtonClickAction += ActivateBylBylSound;
        EventActionController.MusicButtonClickAction += CheckMenuThemeSound;
    }
    private void OnDisable()
    {
        EventActionController.ButtonClickAction -= ActivateBylBylSound;
        EventActionController.MusicButtonClickAction -= CheckMenuThemeSound;
    }
    private void ActivateBylBylSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn == 1)
        {
            _audioSource.PlayOneShot(_bylBylSound);
        }
        
    }

    private void CheckMenuThemeSound()
    {
        _isMusicOn = PlayerPrefs.GetInt("IsMusicOn");
        if (_isMusicOn == 1)
        {
            _audioSource.clip = _menuTheme;
            _audioSource.loop = true;
            _audioSource.Play();
        }
        else if(_isMusicOn == 0)
        {
            _audioSource.Stop();
        }
    }
}
