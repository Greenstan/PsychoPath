using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycle : MonoBehaviour
{
    public GameObject p1;
    public GameObject cam2;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("player1");
        

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.C))
        {

            p1.SetActive(true);
            //cam2.SetActive(true);
            this.gameObject.SetActive(false);

        }
        else
        {
            p1.SetActive(false);
        }
    }
}
