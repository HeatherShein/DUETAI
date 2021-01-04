using UnityEngine;

/*
 *  Follows the player.
 */
public class CameraFollow : MonoBehaviour
{
    [SerializeField] bool AIPlay = false;
    Transform target;

    void Start()
    {
        if (AIPlay)
        {
            target = ForwardMovement.Instance.transform;
        }
        else
        {
            target = PlayerMovement.Instance.transform;
        }
    }
    
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
