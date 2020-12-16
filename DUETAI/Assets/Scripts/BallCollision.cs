using UnityEngine;

public class BallCollision : MonoBehaviour
{
    ParticleSystem explosionFx;

    void Start()
    {
        explosionFx = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.isGameOver = true;

            explosionFx.Play();

            PlayerMovement.Instance.Restart();
        }
    }
}
