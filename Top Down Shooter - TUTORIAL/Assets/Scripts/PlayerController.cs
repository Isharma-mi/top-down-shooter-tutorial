using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] float moveSpeed = 5.0f;

    public HealthBar playerHealthBar;

    public int maxHealth = 100;
    public int currentHealth;

    private Rigidbody2D playerRb;

    private Vector2 mousePosition;
    private Vector2 moveDirection;

    public Weapon weapon;
    #endregion Variables

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Start()
    {   
        playerHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // Get input without smoothing
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Gets direction player wants to move in
        moveDirection = new Vector2(moveX, moveY).normalized;
        // Gets positon of mouse in world from the Main Camera's view 
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Shoot weapon when left click
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
    }

    private void FixedUpdate()
    {
        // Moves player
        playerRb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // Gets direction for player to look towards mouse
        Vector2 aimDirection = mousePosition - playerRb.position;

        // Rotates player to where mouse is pointed
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        playerRb.rotation = aimAngle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Melee Enemy"))
        {
            TakeDamage(20);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.UpdateHealth(currentHealth);
    }
}
