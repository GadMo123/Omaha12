using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    GameObject[] playerCards = new GameObject[12];
    GameObject[] emptySpots = new GameObject[12];
    Deck deck;

    void Start()
    {
        deck = new Deck();
        //ImagesToMatsUtils.BuildMaterialsFromImages(deck);  //TODO - remove. call this only once to create materials from card images for each new skin everything have to be in the right folder for it to work
        playerCards = GameObject.FindGameObjectsWithTag("PlayerCards");
        emptySpots = GameObject.FindGameObjectsWithTag("EmptySpot");
        DealCards();    
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DealCards()
    {

        foreach (GameObject gameObject in playerCards)
        {
            Card card = deck.GetNextCard();
            Material mat = Resources.Load("Materials/cards/" + card.toString(), typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = mat;
        }
    }
}
