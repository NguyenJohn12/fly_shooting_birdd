using UnityEngine;

public class Bird : MonoBehaviour
{
   public Rigidbody2D rb; 
   public float jumpForce;
   private void Update()
   {
      /// khi click chuột
      if (Input.GetMouseButtonDown(0))
      {
         Jump();
      }

      if (transform.position.y >= 3.8f)
      {
         transform.position = new Vector3(transform.position.x, 3.8f, transform.position.z);
      }
      else if (transform.position.y <= -4.1f)
      {
         transform.position = new Vector3(transform.position.x, -4.1f, transform.position.z);
      }
   }

   private void Jump()
   {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Block"))
      {
         Debug.Log("Bullet Collide with Block");
      }
   }
}
