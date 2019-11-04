using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField]
    Text points;
    [SerializeField]
    GameObject Player; // Makes a refference to the player which stores the script which stores the score
    BirdMovement birdMovementScript; // Makes a reffernece to the BirdMovement script
    private void Start()
    {
        birdMovementScript = Player.GetComponent<BirdMovement>(); // Gets the script componenet from the player gameobject
        points = GetComponent<Text>(); // Gets the text component
    }
    void Update()
    {
        points.text = birdMovementScript.score.ToString(); // Gets the public score variable from the BirdMovement Script and pastes it onto the text within points
    }
}
