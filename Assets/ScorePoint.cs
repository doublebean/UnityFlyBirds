using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "player")
        {
            Score.AddPoint();
            //gameObject.SetActive(false);
        }
    }
}