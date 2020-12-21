using UnityEngine;
using DG.Tweening;

/*
 *  Makes an obstacle slide with a slide distance and a slide duration you determine.
 */
public class ObstacleSliding : MonoBehaviour
{
    [SerializeField] float slideDistance;
    [SerializeField] float slideDuration;

    void Start()
    {
        transform
            .DOLocalMoveX(slideDistance, slideDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutBack);
    }
}
