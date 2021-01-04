using UnityEngine;

/*
 *  Agent that is in charge to rotate the player in order to avoid obstacles
 */
public class Rotater : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    [SerializeField] Rigidbody2D rb;
    float touchPosX;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
                touchPosX = cam.ScreenToWorldPoint(Input.mousePosition).x;

            if (Input.GetMouseButton(0))
            {
                if (touchPosX > 0.01f)
                    RotateRight();
                else
                    RotateLeft();
            }
            else
                rb.angularVelocity = 0f;

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftArrow))
                RotateLeft();
            else if (Input.GetKey(KeyCode.RightArrow))
                RotateRight();

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                rb.angularVelocity = 0f;
#endif
        }
    }

    void RotateLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }

    void RotateRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }
}
