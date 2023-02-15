using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform player;
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("player");
        if(player_go == null)
        {
            Debug.LogError("Couldn't find an object with tag 'player'!");
            return;
        }
        player = player_go.transform;
        offsetX = transform.position.x - player.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
    }
}
