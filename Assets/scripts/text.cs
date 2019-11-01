using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    public TextMeshProUGUI gui;
    GameObject box;
    GameObject space1;
    GameObject space2;

    public TMP_InputField ans;
    public GameObject elec1;
    public GameObject elec2;

    public Sprite elecSpritegreen;

    public TextMeshProUGUI pass;
    public GameObject canvas;

    bool smthn = false;
    string collidedWith;
    Movement movement;
    cycle cycle;

    void Start()
    {
        movement = GetComponent<Movement>();
        cycle = GetComponent<cycle>();
        space1 = GameObject.Find("p1");
        space2= GameObject.Find("p2");

        box = GameObject.Find("textbox");
        box.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "password")
        {
            collidedWith = collision.name;
            
            box.gameObject.SetActive(true);
            gui.text = "press space to read";
            //canvas.gameObject.SetActive(true);

            smthn = true;
            
        }


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        box.gameObject.SetActive(false);
        smthn = false;
    }
    //private void Update()
    //{
    //    gui.text = "collision";

    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && smthn)
        {
            
            //canvas.gameObject.SetActive(true);
            if (canvas.gameObject.activeSelf)
            {
                
                canvas.gameObject.SetActive(false);
                movement.enabled = true;
                cycle.enabled = true;



            }
            else
            {
                canvas.gameObject.SetActive(true);
                movement.enabled = false;
                cycle.enabled = false;


                //movement.enabled = true;

                if (collidedWith == "p2") {
                    pass.text = "What has hands but can not clap?";
                    

                }
                if (collidedWith== "p1") {
                    pass.text = "What has a head and a tail, but no body?";
                    
                }


            }
        }

       
    }
    public void submit()
    {
        //Input field Text
        string inputText= ans.text;

        if (collidedWith == "p2")
        {
            if (inputText == "clock")
            {
                print("correct");
                canvas.gameObject.SetActive(false);
                movement.enabled = true;
                cycle.enabled = true;
                space2.SetActive(false);

                elec2.GetComponent<SpriteRenderer>().sprite = elecSpritegreen;

            }
            else
            {
                print("ans is not correct " + ans.text.ToLower().Trim());
                print(ans.text.ToLower().Trim() == "clock");
            }
        }
        else if (collidedWith == "p1")
        {
            if (inputText == "coin")
            {
                print("correct");
                canvas.gameObject.SetActive(false);
                movement.enabled = true;
                cycle.enabled = true;
                space1.SetActive(false);

                elec1.GetComponent<SpriteRenderer>().sprite = elecSpritegreen;

            }
            else
            {
                print("ans is not correct " + ans.text.ToLower().Trim());
                print(ans.text.ToLower().Trim() == "coin");
            }
        }
    }
}
