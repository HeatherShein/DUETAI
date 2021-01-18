using UnityEngine;
using Unity.MLAgents;

/*
 *  Deals with collisions between player and obstacles.
 *  Triggers explosion, ends the game and restarts it.
 */
public class BallCollision : MonoBehaviour
{
    [SerializeField] bool AIPlay = false;
    [SerializeField] Rotater rotater;

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
            Debug.Log(other.gameObject);

            GameManager.Instance.isGameOver = true;

            explosionFx.Play();
            Splatters.Instance.AddSplatter(other.transform, other.contacts[0].point, ballIndex);

            if (AIPlay)
            {
                rotater.AddReward(-1f);
                rotater.EndEpisode();
            }
            else
            {
                PlayerMovement.Instance.Restart();
            }
        }
    }
}
