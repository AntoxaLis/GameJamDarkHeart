using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TMP_Text _dropdownText;

    public string spellChoice;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



    }

    public void ChangeLocationDropDown()
    {

        spellChoice = _dropdownText.text;
        Debug.Log(spellChoice);
    }

    public void OnButtonPress()
    {

        if(spellChoice == "Invoke your time reversal spell")
        {

            Debug.Log("Return to main menu");

        }

        else if(spellChoice == "Invoke your self-destruct spell")
        {

            Debug.Log("Close game");

        }

    }

}
