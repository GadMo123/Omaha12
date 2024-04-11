using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    GameObject[] playerCards = new GameObject[12];
    Deck deck;

    void Start()
    {
        deck = new Deck();
        //Utils.BuildMaterialsFromImages(deck);   call this only once to create materials from card images for each new skin everything have to be in the right folder for it to work
        playerCards = GameObject.FindGameObjectsWithTag("EmptySpot");
        foreach (GameObject gameObject in playerCards) //Todo
        {
            Card card = deck.GetNextCard();

            // Material mat = new Material(Shader.Fin("Standard"));
            //mat.


            Material mat = Resources.Load("Materials/Ah", typeof(Material)) as Material;
            gameObject.GetComponent<Renderer>().material = mat;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
