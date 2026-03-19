using UnityEngine;

public class Enemy : Entity
{
    private bool playerDetected;
    private Transform target;

    [Header("Detection & Chase")]
    [SerializeField] private float detectionRange = 8f;
    [SerializeField] private float attackStopDistance = 1.2f;
    

    protected override void Awake()
    {
        base.Awake();
        // Automatically find the player by name
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj) target = playerObj.transform;
    }

    protected override void Update()
    {
        // Calling base.Update() if your Entity class has logic there, 
        // otherwise these individual calls are correct.
        HandleCollision();
        HandleAnimations();
        HandleFlip();
        HandleAttack();
    }

    private void FixedUpdate()
    {
        // Physics movement is best handled in FixedUpdate
        HandleMovement();
    }

    protected override void HandleAnimations()
    {
        // Use Mathf.Abs so the animation gets a positive value even when moving left
        anim.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
    }

    protected override void HandleAttack()
    {
        // Only attack if playerDetected (from the OverlapCircle in HandleCollision)
        if (playerDetected)
            anim.SetTrigger("attack");
    }

    protected override void HandleMovement()
    {
        if (target == null || !canMove)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        // Logic: If close enough to "see" but far enough that we need to walk closer
        if (distanceToPlayer < detectionRange && distanceToPlayer > attackStopDistance)
        {
            float directionX = target.position.x > transform.position.x ? 1 : -1;
            rb.linearVelocity = new Vector2(directionX * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // Stop moving if player is too far or close enough to attack
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    protected override void HandleCollision()
    {
        base.HandleCollision();
        if (attackPoint != null)
        {
            playerDetected = Physics2D.OverlapCircle(attackPoint.position, attackRadius, whatIsTarget);
        }
    }

    // This helps you see the ranges in the Scene view!
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}