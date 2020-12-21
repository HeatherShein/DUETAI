using UnityEngine;

/*
 *  Main Menu offers two types of games : regular and AI ones.
 */
public class MainMenu : MonoBehaviour
{

    [SerializeField] LevelSelector levelSelector;
    [SerializeField] string levelSelect;
    [SerializeField] string levelAI;

    public void PlayGame()
    {
        levelSelector.Select(levelSelect);
    }

    public void AIGame()
    {
        levelSelector.Select(levelAI);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
