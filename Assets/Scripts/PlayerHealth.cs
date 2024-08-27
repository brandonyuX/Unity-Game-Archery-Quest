using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public CanvasOverScrenn canvas;
    public float health;
    public float maxHealth = 10;
    [SerializeField] private Slider playerHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        playerHealthBar.value = 1;
    }
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TakeDamage(1);
        }
    }*/
    // Update is called once per frame

    public void TakeDamage(int damage)
    {
        health -= damage;
        playerHealthBar.value = health / maxHealth;
        //Debug.Log(playerHealthBar.value);
        if (health <= 0)
        {
            canvas.Setup();
            //Destroy(gameObject);
        } 
    }
}
