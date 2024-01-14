using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
   private int melons = 0;

    [SerializeField] private Text melonsText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioClip soundCollect;
    [SerializeField] private AudioClip soundGate;

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("crystal"))
        {
            Destroy(collision.gameObject);
            collectionSoundEffect.PlayOneShot(soundCollect);
            door.SetActive(false);
            doorOpen.SetActive(true);
            Invoke("gateOpen", 1f);
        }
       
    }
    void gateOpen()
    {
        collectionSoundEffect.PlayOneShot(soundGate);
    }
}
