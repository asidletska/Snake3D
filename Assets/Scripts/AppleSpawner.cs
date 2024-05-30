using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public Collider spawnCollider;
    public float spawnInterval = 2f;

    private void Start()
    {
        SpawnApple();
    }

    public void SpawnApple()
    {
        Bounds bounds = spawnCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Instantiate(applePrefab, position: new Vector3(randomX, randomY, randomZ), Quaternion.identity);
    }
}
