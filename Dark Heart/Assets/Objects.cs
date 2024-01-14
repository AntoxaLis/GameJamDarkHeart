using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objects : MonoBehaviour
{

    public Text crystal;
    public int count = 3;
    void Start()
    {
        crystal.text = "Crystal: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) // une fonction publique pour l'utiliser dans un autre script
    {
        count -= count;
        crystal.text = "Crystal: " + count.ToString();
    }
}
