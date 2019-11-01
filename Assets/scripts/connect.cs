using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connect : MonoBehaviour
{
    //current position
    private Rigidbody2D pos;

    GameObject parent;
    SpriteRenderer spriteRenderer;

    public bool isConnected;
    public Sprite notConnected;
    public Sprite connected;


    
    void Start()
    {
        parent = GameObject.Find("player2");
        pos = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }


    private void Update()
    {
        if (gameObject.tag != "Electricity")
        {
            // Change sprite based on whether it is connected or not
            if (isConnected)
                gameObject.GetComponent<SpriteRenderer>().sprite = connected;
            else
                gameObject.GetComponent<SpriteRenderer>().sprite = notConnected;

         }
    }
    void connectedAfterDelay()
    {
        isConnected = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // position of colliding object 
        Vector2 collisionPosition = new Vector2(collision.transform.position.x, collision.transform.position.y);

        // horizontal wires
        if (collision.tag == "horizontal" && gameObject.tag == "horizontal")
        {

            if (collision.GetComponent<connect>().isConnected)
            {
                if (transform.position.x > collision.transform.position.x)
                {
                    //Snap to left
                    collisionPosition.x += 3f;
                    pos.MovePosition(collisionPosition);
                }
                else if (transform.position.x < collision.transform.position.x)
                {
                    //Snap to Right
                    collisionPosition.x -= 3f;
                    pos.MovePosition(collisionPosition);
                }
                //Wait for two seconds 
                Invoke("connectedAfterDelay", 2);
            }

        }

        //vertical wires 
        else if (collision.tag == "vertical" && gameObject.tag == "vertical")
        {

            if (collision.GetComponent<connect>().isConnected)
            {
                if (transform.position.y > collision.transform.position.y)
                {
                    //Snap above
                    collisionPosition.y += 3f;
                    pos.MovePosition(collisionPosition);
                }
                else if (transform.position.y < collision.transform.position.y)
                {
                    //Snap below
                    collisionPosition.y -= 3f;
                    pos.MovePosition(collisionPosition);
                }
                //Wait for two seconds 
                Invoke("connectedAfterDelay", 2);
            }
        }

        // connecting L-shape wires
        else if (gameObject.tag == "L-shape")
        {

            //connections to horizontal wires
            if (collision.tag == "horizontal")
            {
                if (collision.GetComponent<connect>().isConnected)
                {
                    if (transform.position.x > collision.transform.position.x)
                    {
                        //Snap to left
                        print("l shape");
                        collisionPosition.x += 3.5f;
                        collisionPosition.y -= 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    else if (transform.position.x < collision.transform.position.x)
                    {
                        //Snap to Right
                        collisionPosition.x -= 3.5f;
                        collisionPosition.y -= 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    //Wait for two seconds 
                    Invoke("connectedAfterDelay", 2);

                }
            }
            else if (collision.tag == "vertical")
            {
                if (collision.GetComponent<connect>().isConnected)
                {
                    if (transform.position.y > collision.transform.position.y)
                    {
                        //Snap above
                        collisionPosition.y += 3.5f;
                        collisionPosition.x -= 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    else if (transform.position.y < collision.transform.position.y)
                    {
                        //Snap below
                        collisionPosition.y -= 3.5f;
                        collisionPosition.x -= 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    //Wait for two seconds 
                    Invoke("connectedAfterDelay", 2);
                }
            }

        }
        
        else if (collision.tag == "L-shape")
        {
            if (tag == "horizontal")
            {
                if (collision.GetComponent<connect>().isConnected)
                {
                    if (transform.position.x > collision.transform.position.x)
                    {
                        //Snap to left
                        print("l shape");
                        collisionPosition.x += 3.5f;
                        collisionPosition.y += 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    else if (transform.position.x < collision.transform.position.x)
                    {
                        //Snap to Right

                        collisionPosition.x -= 3.5f;
                        collisionPosition.y += 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    //Wait for two seconds 
                    Invoke("connectedAfterDelay", 2);
                }

            }
            else if (tag == "vertical")
            {
                if (collision.GetComponent<connect>().isConnected)
                {
                    if (transform.position.y > collision.transform.position.y)
                    {
                        //Snap above
                        collisionPosition.y += 3.5f;
                        collisionPosition.x -= 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    else if (transform.position.y < collision.transform.position.y)
                    {
                        //Snap below
                        collisionPosition.y -= 3.5f;
                        collisionPosition.x += 1.4f;
                        pos.MovePosition(collisionPosition);
                    }
                    //Wait for two seconds 
                    Invoke("connectedAfterDelay", 2);
                }

            }
        }
        else if (collision.tag == "Electricity" && gameObject.tag == "horizontal")
        {


            if (collision.GetComponent<connect>().isConnected)
            {
                
                if (transform.position.x > collision.transform.position.x)
                {
                    collisionPosition.x += 3f;
                    //pos.MovePosition(collisionPosition);
                    collisionPosition.y += 0.9f;
                    pos.MovePosition(collisionPosition);
                }
                else if (transform.position.x < collision.transform.position.x)
                {
                    collisionPosition.x -= 3f;
                    //pos.MovePosition(collisionPosition);
                    collisionPosition.y -= 0.9f;
                    pos.MovePosition(collisionPosition);
                }
                //Wait for two seconds 
                Invoke("connectedAfterDelay", 2);
            }


        }
        
     }


    // void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag != "Electricity")
    //    {
    //        isConnected = false;
    //    }
    //}

}
