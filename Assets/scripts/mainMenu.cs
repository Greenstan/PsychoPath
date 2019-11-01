using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;




public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 size = new Vector2(465, 50);
    RectTransform dimensions; 
    void Start()
    {
        if(this.name == "Button")
        { 
            dimensions = GetComponent<RectTransform>();
            dimensions.sizeDelta = size;
        }

    }
    public void Level()
    {
        SceneManager.LoadScene("Scene1");
    }
    

    void OnMouseOver()
    {
        
            print("this is over");
            size.x = 485;
            size.y = 485;

            dimensions.sizeDelta = size;
        

    }
}
