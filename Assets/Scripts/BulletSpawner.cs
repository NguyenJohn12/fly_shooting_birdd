using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform BulletParent;

    public float spawnCooldown;
    public float spawnTime;
    private void Update()
    {
        CheckSpawnBullet();
    }

    private void CheckSpawnBullet()
    {
        if (spawnTime >= spawnCooldown)
        {
            spawnTime -= spawnCooldown;
            SpawnBullet();
        }
        else
        {
            spawnTime += Time.deltaTime;
        }
    }

    private void SpawnBullet()
    {
        var bullet = PoolingManager.Spawn(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.SetParent(BulletParent);
    }
}
