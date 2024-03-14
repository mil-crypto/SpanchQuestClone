using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MenuSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _menuTheme;
    [SerializeField] private AudioClip _buttonsSound;
    private int _isMusicOn;
    private int _isSoundOn;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        CheckMenuThemeSound();
    }
    private void OnEnable()
    {
        EventActionController.MusicButtonClickAction += CheckMenuThemeSound;
        EventActionController.ButtonsSoundAction += ActivateButtonsSound;
    }
    private void OnDisable()
    {
        EventActionController.MusicButtonClickAction -= CheckMenuThemeSound;
        EventActionController.ButtonsSoundAction -= ActivateButtonsSound;
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
    private void ActivateButtonsSound()
    {
        _isSoundOn = PlayerPrefs.GetInt("IsSoundOn");
        if (_isSoundOn == 1)
        {
            _audioSource.PlayOneShot(_buttonsSound);
        }
    }
}
