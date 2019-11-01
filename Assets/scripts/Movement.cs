using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public float speed =10f;
   private Rigidbody2D rgd; 
   private Vector2 velocity;
    
  void Start() 
    {
       rgd = GetComponent<Rigidbody2D>();
   }

   void Update() {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");
        
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        velocity = movement.normalized * speed;

   } 
   void FixedUpdate() {
      rgd.MovePosition(rgd.position+velocity *Time.fixedDeltaTime);    
   }

}