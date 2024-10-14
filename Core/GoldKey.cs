using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioClip LevelCompletedSound;
    [SerializeField] private GameObject LevelCompletedScreen; // Reference to the GameOver UI GameObject
    [SerializeField] private GameObject player; // Reference to the Player GameObject

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        LevelCompletedScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            anim.SetTrigger("Pickup");
            LevelCompletedScreen.SetActive(true);
            SoundManager.instance.PlaySound(LevelCompletedSound);
            player.SetActive(false); // Deactivate the player
        }
    }

    private void Deactivate()
    {
        // Deactivate the object immediately
        gameObject.SetActive(false);
    }
}