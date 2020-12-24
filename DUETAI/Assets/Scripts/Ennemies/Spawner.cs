using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 *  Spawns obstacles with a custom interval
 *  Obstacles are spawned either on left, right or center.
 *  If centered, obstacles are twice as small.
 */
public class Spawner : MonoBehaviour
{

    #region Singleton class: Spawner

    public static Spawner Instance;

    #endregion

    [SerializeField] public Transform player;
    [SerializeField] private List<GameObject> cornerObstacles;
    [SerializeField] private List<GameObject> halfObstacles;
    [SerializeField] private List<GameObject> centerObstacles;

    #region SpawnParameters
    private enum SpawnPosition
    {
        Left,
        Left_Center,
        Center,
        Right_Center,
        Right
    }

    [SerializeField] private float minSpawnIntervalInSeconds;
    [SerializeField] private float maxSpawnIntervalInSeconds;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    private Vector3 pos = new Vector3(0f,0f,0f);
    #endregion

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        StartCoroutine(nameof(Spawn));
    }

    private IEnumerator Spawn()
    {
        GameObject spawnable = null;

        // Adapt according to the random position
        Array values = Enum.GetValues(typeof(SpawnPosition));
        SpawnPosition spawnPosition = (SpawnPosition)values.GetValue(Random.Range(0,values.Length));
        switch (spawnPosition)
        {
            case SpawnPosition.Left:
                pos.x = -xOffset;
                spawnable = GetRandomSpawnableFromList(cornerObstacles);
                break;
            case SpawnPosition.Left_Center:
                pos.x = -xOffset / 2;
                spawnable = GetRandomSpawnableFromList(halfObstacles);
                break;
            case SpawnPosition.Center:
                pos.x = 0;
                spawnable = GetRandomSpawnableFromList(centerObstacles);
                break;
            case SpawnPosition.Right_Center:
                pos.x = xOffset / 2;
                spawnable = GetRandomSpawnableFromList(halfObstacles);
                break;
            case SpawnPosition.Right:
                pos.x = xOffset;
                spawnable = GetRandomSpawnableFromList(cornerObstacles);
                break;
            default:
                Debug.LogError("Error: Spawn Position not found : " + spawnPosition.ToString());
                break;
        }

        // Make the obstacle spawn ahead of player
        pos.y = player.position.y + yOffset;

        // Instantiate the obstacle
        var spawned = Instantiate(spawnable, pos, transform.rotation, transform);
        spawnedObjects.Add(spawned);

        yield return new WaitForSeconds(Random.Range(minSpawnIntervalInSeconds, maxSpawnIntervalInSeconds));
        StartCoroutine(nameof(Spawn));
    }

    private GameObject GetRandomSpawnableFromList(List<GameObject> obstacles)
    {
        int randomIndex = Random.Range(0, obstacles.Count);
        return obstacles[randomIndex];
    }

    public void DestroyAllSpawnedObjects()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedObjects[i]);
            spawnedObjects.RemoveAt(i);
        }
    }
}
