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


    [SerializeField] Vector3 CP2;
    [SerializeField] Vector3 CP3;
    [SerializeField] Vector3 CP4;
    [SerializeField] Vector3 CP5;
    [SerializeField] Vector3 CP6;
    [SerializeField] Vector3 CP7;

    public int pointsDone = 0;

    public GameObject point;




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

        //couyd add another if statement to make dead zone for x and z axis
    }




    private void OnTriggerExit(Collider other)

    {
       if (pointsDone == 2)
       { 
        vectorPoint = point.transform.position;

        points++;
        pointsDone++;

        point.transform.position = CP4;
       }

        else if (pointsDone == 1)
       { 
        vectorPoint = point.transform.position;

        points++;
        pointsDone++;

        point.transform.position = CP3;
        
       }

        

        else if (pointsDone == 0)
       { 
        vectorPoint = point.transform.position;

        points++;
        pointsDone++;

        point.transform.position = CP2;
        
       }
        
       }



       

    
       
     }
