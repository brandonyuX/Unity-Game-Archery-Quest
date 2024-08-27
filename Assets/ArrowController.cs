using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource targetSound;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 initialVelocity)
    {
        rb.velocity = initialVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        { 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1.0f);
                rb.isKinematic = true;
            }
            transform.parent = collision.gameObject.transform;

        }
        if (collision.gameObject.CompareTag("Target"))
        {
            rb.isKinematic = true;
            targetSound = collision.gameObject.GetComponent<AudioSource>();
            targetSound.Play();
            transform.parent = collision.gameObject.transform;

        }
    }
   
}
