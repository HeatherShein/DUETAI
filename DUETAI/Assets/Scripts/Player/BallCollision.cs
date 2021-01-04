using UnityEngine;

/*
 *  Deals with collisions between player and obstacles.
 *  Triggers explosion, ends the game and restarts it.
 */
public class BallCollision : MonoBehaviour
{
    [SerializeField] bool AIPlay = false;

    ParticleSystem explosionFx;
    int ballIndex;

    void Start()
    {
        explosionFx = transform.GetChild(0).GetComponent<ParticleSystem>();
        ballIndex = transform.position.x > 0 ? 0 : 1;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.isGameOver = true;

            explosionFx.Play();
            Splatters.Instance.AddSplatter(other.transform, other.contacts[0].point, ballIndex);

            if (AIPlay)
            {
                Spawner.Instance.DestroyAllSpawnedObjects();
                ForwardMovement.Instance.Restart();
            }
            else
            {
                PlayerMovement.Instance.Restart();
            }
        }
    }
}
