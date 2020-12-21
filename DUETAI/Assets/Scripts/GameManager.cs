using UnityEngine;

/*
 *  Game Manager.
 *  Deals with gmae over.
 */
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
