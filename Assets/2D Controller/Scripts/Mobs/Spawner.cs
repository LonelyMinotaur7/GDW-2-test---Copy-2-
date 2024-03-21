using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int rand;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spawn Checker"))
        {
            rand = Random.Range(0, 100);
            Debug.Log(rand);
            switch (rand)
            {
                case 0-33:
                    Debug.Log("1");
                    break;
                case 34-66:
                    Debug.Log("2");
                    break;
                default:
                    Debug.Log("3");
                    break;
            }
        }
    }
}
