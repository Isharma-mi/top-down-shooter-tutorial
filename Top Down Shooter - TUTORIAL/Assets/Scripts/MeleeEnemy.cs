using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeEnemy : MonoBehaviour
{

    #region Variables
    [SerializeField] float moveSpeed = 3.5f;

    private GameObject player;

    public HealthBar healthBar;

    [SerializeField] int maxHealth = 60;
    [SerializeField] int currentHealth;

    private Rigidbody2D enemyRb;

    private Vector2 moveDir;
    #endregion Variables

    // Get rb component and find player
    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.transform.position = transform.position;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player exists -> Calculates which direction to move and angle
        if (player)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemyRb.rotation = rotationAngle;
            moveDir = direction;
            
        }
    }

    private void FixedUpdate()
    {
        if (player)
        {
            enemyRb.velocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Take damage when hit by bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealth(currentHealth);
    }
}
