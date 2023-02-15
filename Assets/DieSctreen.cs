using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSctreen : MonoBehaviour
{
    static bool sawOnce = false;
    BirdMovement birdDie;

    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("player");
        birdDie = player_go.GetComponent<BirdMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (birdDie.dead == true )
        {
            
            GetComponent<SpriteRenderer>().enabled = true;
            sawOnce = true;
        }
        if(sawOnce == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            sawOnce = false;
        }
    }
}
