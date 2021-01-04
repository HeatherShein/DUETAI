using UnityEngine;

/*
 *  Cleans obstacles in AI plays
 */
public class ObstacleCleaner : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    Transform target;

    private void Start()
    {
        target = ForwardMovement.Instance.transform;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }

}
