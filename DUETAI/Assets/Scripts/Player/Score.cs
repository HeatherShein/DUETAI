using UnityEngine;
using TMPro;

/*
 *  Displays Player's score based on the distance he reached.
 */
public class Score : MonoBehaviour
{
    [SerializeField] bool AIPlay = false;
    [SerializeField] public Transform player;
    [SerializeField] public TextMeshProUGUI display;
    [SerializeField] Rotater rotater;
     
    void Update()
    {
        if (AIPlay)
        {
            display.text = "Score : " + (rotater.score).ToString("#.0");
        }
        else
        {
            display.text = "Score : " + (player.position.y - PlayerMovement.Instance.startPosition.y).ToString("0");
        }
    }
}
