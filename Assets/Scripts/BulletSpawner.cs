using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        var bullet = PoolingManager.Spawn(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.SetParent(transform);
    }
}
