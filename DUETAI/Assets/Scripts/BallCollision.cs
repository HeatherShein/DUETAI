using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.isGameOver = true;

            PlayerMovement.Instance.Restart();
        }
    }
}
