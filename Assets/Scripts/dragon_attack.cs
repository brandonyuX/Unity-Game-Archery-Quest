using UnityEngine;
using System.Collections;

public class dragon_attack : MonoBehaviour
{
    public int maxHealth = 3;

    private Animator anim;
    private int currentHealth;
    private bool isDead = false;

    // Use this for initialization
    void Awake()
    {
        // Set up references.
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = true;
            if (anim != null)
            {
                anim.SetTrigger("Dead");
                Destroy(gameObject, 5f);
            }
        }
    }
}
    
