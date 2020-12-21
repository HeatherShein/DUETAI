using UnityEngine;
using TMPro;

/*
 *  Displays Player's score based on the distance he reached.
 */
public class Score : MonoBehaviour
{

    [SerializeField] public Transform player;
    [SerializeField] public TextMeshProUGUI display;

    void Update()
    {
        display.text = "Score : " + (player.position.y - PlayerMovement.Instance.startPosition.y).ToString("0");
    }
}
