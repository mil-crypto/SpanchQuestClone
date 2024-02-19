using System;
using UnityEngine;

public class EventActionController : MonoBehaviour
{
    public static event Action ButtonClickAction;
    public static event Action RestartGameAction;
    public static event Action NextLevelAction;
    public static event Action UpdateLevelAction;
    public static event Action UpdateLevelInMainMenuAction;

    public static event Action EndGameAction;
    public static event Action WinGameAction;
    public static event Action StopGameAction;

    public static event Action LavaTouchWaterAction;
    public static event Action LavaTouchZombiAction;

    public static event Action ActivateBublesAction;

    public static event Action EndExplosionBombAction;

    public static event Action MusicButtonClickAction;

    public static event Action OpenBlockAction;
    public static event Action ZombiCollisionPlayerAction;

    public static void GetRestartEvent()
    {
        RestartGameAction?.Invoke();
    }
    public static void GetNextLevelEvent()
    {
        NextLevelAction?.Invoke();
    }
    public static void GetEndGameEvent()
    {
        EndGameAction?.Invoke();
    }
    public static void GetLavaTouchEvent()
    {
        LavaTouchWaterAction?.Invoke();
    }
    public static void GetWinGameEvent()
    {
        WinGameAction?.Invoke();
    }
    public static void GetStopGameEvent()
    {
        StopGameAction?.Invoke();
    }

    public static void GetButtonClickAction()
    {
        ButtonClickAction?.Invoke();
    }

    public static void GetLavaTouchZombiEvent()
    {
        LavaTouchZombiAction?.Invoke();
        WinGameAction?.Invoke();
    }

    public static void GetUpdateLevelAction()
    {
        UpdateLevelAction?.Invoke();
    }

    public static void GetActivateBublesAction()
    {
        ActivateBublesAction?.Invoke();
    }

    public static void GetUpdateLevelInMainMenuAction()
    {
        UpdateLevelInMainMenuAction?.Invoke();
    }

    public static void GetEndExplosionBombAction()
    {
        EndExplosionBombAction?.Invoke();
    }

    public static void GetMusicButtonClickAction()
    {
        MusicButtonClickAction?.Invoke();
    }

    public static void GetOpenBlockAction()
    {
        OpenBlockAction?.Invoke();
    }
    public static void GetZombiCollisionPlayerAction()
    {
        ZombiCollisionPlayerAction?.Invoke();
    }
}
