using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

/*
 *  Agent that is in charge to rotate the player in order to avoid obstacles
 */
public class Rotater : Agent
{
    [SerializeField] float rotationSpeed;

    Rigidbody2D rb;
    float touchPosX;
    Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    public override void OnEpisodeBegin()
    {
        Spawner.Instance.DestroyAllSpawnedObjects();
        ForwardMovement.Instance.RestartAI();
    }

    void Stop()
    {
        rb.angularVelocity = 0f;
    }

    void RotateLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }

    void RotateRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            AddReward(0.1f);
            Destroy(collision.gameObject);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 1)
            RotateLeft();
        else if (actions.DiscreteActions[0] == 2)
            RotateRight();
        else
            Stop();
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
            actionsOut[0] = 1;
        else if (Input.GetKey(KeyCode.RightArrow))
            actionsOut[0] = 2;

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            actionsOut[0] = 0;
    }
}
