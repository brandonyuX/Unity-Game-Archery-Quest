using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnTriggerAddScore : MonoBehaviour
{
    public int score = 1;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            GameManager.Score += score;
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
