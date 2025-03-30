using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float despawnTime;
    private void OnEnable()
    {
        Invoke(nameof(Despawn), despawnTime);
    }
    private void Update()
    {
        transform.position += Vector3.right * (speed * Time.deltaTime);
    }

    
    private void Despawn()
    {
        PoolingManager.Despawn(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Debug.Log("Bullet Collide with Block");
            Despawn();
        }
    }
}
