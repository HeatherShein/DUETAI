using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  Level Selection based on the level name.
 */
public class LevelSelector : MonoBehaviour
{
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
