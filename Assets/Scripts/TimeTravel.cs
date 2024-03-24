using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    private int Switch = 0;
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Travel();

        }
 
    }

    public void Travel()
    {
        if (Switch == 0)
        {

            player.transform.position += new Vector3(0, 200, 0);
            
            Switch = 1;
        }
        else
        {
            player.transform.position += new Vector3(0, -200, 0);
            
            
            Switch = 0;
        }
    }

    }

