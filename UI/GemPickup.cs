using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    public int value;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Play pickup animation and sound
            anim.SetTrigger("Pickup");
            SoundManager.instance.PlaySound(pickupSound);

            // Add the collected coins to the PersistentDataManager
            PersistentDataManagerGems.Instance.AddGems(value);

            //Deactivate();
        }
    }

    private void Deactivate()
    {
        // Deactivate the object immediately
        gameObject.SetActive(false);
    }
}