using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton class: GameManager

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion


    [HideInInspector] public bool isGameOver =false;
}
