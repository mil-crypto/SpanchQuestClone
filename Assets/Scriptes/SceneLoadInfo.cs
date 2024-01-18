using UnityEngine;

public class SceneLoadInfo : MonoBehaviour
{
    private static readonly int maxLevel = 27;
    public static int MaxLevel{
        get
        {
            return maxLevel;
        }
    }
    public static int GetCurrentLevel()
    {
        int currentLvl;
        if (PlayerPrefs.GetInt("currentLevel") == 0)
        {
            currentLvl = 1;
        }
        else
        {
            currentLvl = PlayerPrefs.GetInt("currentLevel");
        }
        return currentLvl;
    }
    public static void SetCurrentLevel(int currentLevel)
    {
        if (currentLevel > GetMaxPassedLvl())
        {
            PlayerPrefs.SetInt("maxPassedLvl", currentLevel);
        }
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        PlayerPrefs.Save();
    }
    public static int GetMaxPassedLvl()
    {
        int maxPasLvlv;
        if (PlayerPrefs.GetInt("maxPassedLvl") != 0)
        {
            maxPasLvlv = PlayerPrefs.GetInt("maxPassedLvl");
        }
        else
        {
            maxPasLvlv = 1;
        }

        return maxPasLvlv;
    }
}
