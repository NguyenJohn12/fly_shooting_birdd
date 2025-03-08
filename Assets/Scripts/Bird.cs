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
   }

   private void Jump()
   {
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
   }
}
