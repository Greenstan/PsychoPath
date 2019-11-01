using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    public bool held = false; 
    public GameObject draggedObject = null;
    string origtag;
    Movement movement;
    private void Start()
    {
        movement = GetComponent<Movement>();

    }


        void OnCollisionStay2D(Collision2D collision)
        {
            if (this.gameObject.name == "player1")
            {
                if (collision.collider.tag == "horizontal" || collision.collider.tag == "vertical" ||
                    collision.collider.tag == "L-shape-R" || collision.collider.tag == "L-shape-L" || collision.collider.tag == "L-shape")
                {
                    //All Colliders
                    Collider2D[] allColliders = collision.collider.GetComponents<Collider2D>();

                    if (draggedObject == null)
                        {
                            if (Input.GetKey(KeyCode.B))
                            {
                            
                                collision.collider.transform.SetParent(transform);
                            
                                movement.speed /= 2f;
                                //collision.collider.GetComponent<Collider2D>().enabled = false;
                                foreach (Collider2D col in allColliders) col.enabled = false;
                                //collision.collider.GetComponent<Rigidbody2D>().isKinematic = true;
                                draggedObject = collision.gameObject;
                            }
                     }
                 }
            }
        }


        public void Update()
        {
            if (gameObject.name == "player1")
            {
                
                if (draggedObject != null)
                {
                    //All Colliders
                    Collider2D[] allColliders = draggedObject.GetComponents<Collider2D>();

                    if (Input.GetKeyUp(KeyCode.B))
                        {
                            draggedObject.transform.SetParent(null);
                            foreach (Collider2D col in allColliders) col.enabled = true;
                            //draggedObject.GetComponent<Rigidbody2D>().isKinematic = false;

                            draggedObject = null;
                            movement.speed *= 2f;
                        }
                }
            }
        }
    

}