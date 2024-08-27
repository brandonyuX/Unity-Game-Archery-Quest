using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent navAgent;
    //public Transform player;
    public LayerMask groundLayer, playerLayer;
    public float health, maxHealth = 5f;
    public float walkPointRange;
    public float timeBetweenAttacks;
    public float sightRange;
    public float attackRange;
    public int damage;
    public Animator animator;
    private GameObject spawner;
    private Vector3 walkPoint;
    private bool walkPointSet;
    private bool alreadyAttacked;
    private bool takeDamage;
    private Transform player;
    [SerializeField] FloatingHealthBar healthBar;
   
    private void Awake()
    {
        //animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        healthBar.UpdateHealthBar(health, maxHealth);
        
    }
    private void Update()
    {
        bool playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        bool playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
        else if (!playerInSightRange && takeDamage)
        {
            ChasePlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            navAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //animator.SetFloat("Velocity", 0.2f);

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        navAgent.SetDestination(player.position);
        //Debug.Log("Start to chase Player!!!!!!");
        animator.SetTrigger("isWalk");
        navAgent.isStopped = false; // Add this line
    }


    private void AttackPlayer()
    {
        navAgent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            transform.LookAt(player.position);
            alreadyAttacked = true;
            animator.SetTrigger("Attack_1");
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            Debug.DrawRay(transform.position,transform.forward*attackRange,Color.red);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, playerLayer))
            {
                if(hit.collider != null)
                {
                    Debug.Log("Hit Object:" + hit.collider.gameObject.name);
                    //Debug.Log("hitting player!!!!!!!!!");
                    PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damage);
                    }
                    else
                    {
                        Debug.Log("Hit object does not have a PlayerHealth object!");
                    }
                }
                else
                {
                    Debug.Log("Raycast hit, but collider is null");
                }
                
                
                /*
                    YOU CAN USE THIS TO GET THE PLAYER HUD AND CALL THE TAKE DAMAGE FUNCTION

                PlayerHUD playerHUD = hit.transform.GetComponent<PlayerHUD>();
                if (playerHUD != null)
                {
                   playerHUD.takeDamage(damage);
                }
                 */
            }
        }
    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
        //animator.SetBool("Attack", false);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        StartCoroutine(TakeDamageCoroutine());

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.01f);
            ScoreScript.scoreValue += 10;
        }
    }

    private IEnumerator TakeDamageCoroutine()
    {
        takeDamage = true;
        yield return new WaitForSeconds(2f);
        takeDamage = false;
    }

    private void DestroyEnemy()
    {
        StartCoroutine(DestroyEnemyCoroutine());
    }

    private IEnumerator DestroyEnemyCoroutine()
    {
        navAgent.isStopped = true;
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}