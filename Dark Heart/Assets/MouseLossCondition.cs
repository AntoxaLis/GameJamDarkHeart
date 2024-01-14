using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseLossCondition : MonoBehaviour
{
    public int gameState = 0;

    [SerializeField] public GameObject canvas;

    [SerializeField] public GameObject intruct;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && gameState == 0)
        {

            gameState = 1;

        }

        if(Input.GetMouseButtonUp(0) && gameState == 1)
        {

            gameState = 2;

        }

        if(gameState == 1)
        {

            Debug.Log("Playing");

            intruct.SetActive(false);

        }

        else if(gameState == 2)
        {

            Debug.Log("Loss");
            canvas.SetActive(true);
            SceneManager.LoadScene("GameOver");  // Chargement de la scène "jeu"
        }

    }
}
