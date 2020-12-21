using UnityEngine;
using DG.Tweening;

/*
 *  Makes an obstacle rotate with a rotation duration you determine.
 */
public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] float rotationDuration;

    void Start()
    {
        transform
            .DORotate(new Vector3(0f, 0f, 1f), rotationDuration)
            .SetLoops(-1, LoopType.Incremental);
    }
}
