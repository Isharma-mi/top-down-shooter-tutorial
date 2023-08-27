using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    #region Variables
    [SerializeField] float moveSpeed = 3.5f;

    private GameObject player;

    private Rigidbody2D enemyRb;

    private Vector2 moveDir;
    #endregion Variables

    // Get rb component and find player
    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
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
}
