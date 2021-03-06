﻿using UnityEngine;
using DG.Tweening;

/*
 *  Singleton to globally access the Player's information
 *  Moves player forward.
 */
public class ForwardMovement : MonoBehaviour
{
    #region Singleton class: ForwardMovement

    public static ForwardMovement Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #endregion

    [SerializeField] CircleCollider2D redBallCollider;
    [SerializeField] CircleCollider2D blueBallCollider;

    [SerializeField] float speed;

    Rigidbody2D rb;
    public Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();

        MoveUp();
    }

    void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
    }

    public void Restart()
    {
        redBallCollider.enabled = false;
        blueBallCollider.enabled = false;
        rb.angularVelocity = 0f;
        rb.velocity = Vector2.zero;

        // Refresh position
        transform.DORotate(Vector3.zero, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutBack);

        transform
            .DOMove(startPosition, 1f)
            .SetDelay(1f)
            .SetEase(Ease.OutFlash)
            .OnComplete(() =>
            {
                redBallCollider.enabled = true;
                blueBallCollider.enabled = true;

                GameManager.Instance.isGameOver = false;
                MoveUp();
            });
    }

    public void RestartAI()
    {
        rb.angularVelocity = 0f;
        rb.velocity = Vector2.zero;

        transform.rotation = Quaternion.identity;
        transform.position = startPosition;
        MoveUp();
    }
}
