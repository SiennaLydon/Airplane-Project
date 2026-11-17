using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] List<GameObject> checkPoints;

    [SerializeField] Vector3 vectorPoint;

    public int points = 0;
    
    [SerializeField] float dead;

    void Update()
    {
        if (player.transform.position.y < dead)
        {
            Debug.Log("<color=red>||You have fallen off the map, press R to respawn at the last checkpoint.||<color=grey>");
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.transform.position = vectorPoint;
            }
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       vectorPoint = player.transform.position;
       Destroy(other.gameObject);
       points++;
    }
}
