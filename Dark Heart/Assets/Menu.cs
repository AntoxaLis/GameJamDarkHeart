using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static void boutton()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            SceneManager.LoadScene("Menu");  // Chargement de la sc�ne "jeu"
        }
        else
        {
            SceneManager.LoadScene("GamePlay");       // Chargement de la sc�ne 0
        }
    }
    public void quitter()
    {
        Application.Quit();
    }
}
