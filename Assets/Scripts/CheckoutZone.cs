﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutZone : MonoBehaviour {
    Player_Manager player;
    public AudioClip victory;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Checking out...");
            //Stop animations
            player.animate = false;
            //Send data to GUI
            GameObject.FindObjectOfType<UIManager>().CheckoutUI((int)player.totalValue, player.itemsCollected);

            Destroy(FindObjectOfType<DeathVoid>().gameObject);

            //Find music play
            AudioSource[] sources = GameObject.FindObjectsOfType<AudioSource>();
            foreach(AudioSource sour in sources)
            {
                if(sour.loop == true) //If its the looping track (the music source)
                {
                    //Stop music and play victory tune once
                    sour.loop = false;
                    sour.clip = victory;
                    sour.Play();
                    break;
                }
            }
        }
    }
}
