using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject arrow;
    public Transform muzzle;
    public float arrowSpeed = 30f;
    public float shootingRate = 0.5f;
    
    private AudioSource shootSound;
    private float nextFireTime = 0f;

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }
    void Shoot()
    {
        Vector3 shootingDirection = muzzle.transform.forward;

        GameObject arrowObject = Instantiate(arrow, muzzle.position, Quaternion.LookRotation(shootingDirection));
        ArrowController arrowController = arrowObject.GetComponent<ArrowController>();

        if (arrowController != null)
        {
            arrowController.Launch(shootingDirection * arrowSpeed);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {

            Shoot();
            shootSound.Play();
            nextFireTime = Time.time + shootingRate;
            

        }

    }

}
