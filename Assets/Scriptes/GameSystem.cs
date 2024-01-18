using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    private void OnEnable()
    {
        EventActionController.RestartGameAction += RestartGame;
        EventActionController.NextLevelAction += NextLevel;
    }
    private void OnDisable()
    {
        EventActionController.RestartGameAction -= RestartGame;
        EventActionController.NextLevelAction -= NextLevel;
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void NextLevel()
    {
        int currentLvl = SceneManager.GetActiveScene().buildIndex;
        if (currentLvl <= SceneLoadInfo.GetMaxPassedLvl()&&currentLvl<SceneLoadInfo.MaxLevel)
        {
            SceneManager.LoadScene(currentLvl + 1);
        }
        else
            Debug.Log("Это максимальный уровень");
        if (currentLvl < SceneLoadInfo.MaxLevel)
        {
            SceneLoadInfo.SetCurrentLevel(currentLvl + 1);
        }
    }
}
