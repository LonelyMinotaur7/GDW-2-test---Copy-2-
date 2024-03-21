using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SwordProjectile : MonoBehaviour
{
    public float projAngle;
    public bool collided = false;
    [SerializeField] private float launchVel = 10f;
    
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LaunchSword()
    {
        transform.rotation = Quaternion.Euler(0, 0, (projAngle+270));
        //rb.velocity = (transform.forward * launchVel);
        
        float velx = launchVel * Mathf.Cos(projAngle*Mathf.Deg2Rad);
        float vely = launchVel * Mathf.Sin(projAngle*Mathf.Deg2Rad);
        rb.velocity = new Vector2(velx, vely);
        
        
        print(projAngle);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
            collided = true;
            
        
    }
}
