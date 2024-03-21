using UnityEngine;

public class MagmaBrute : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float maintainDistance = 5f; // The distance the monster tries to maintain from the player
    public float distanceTolerance = 0.5f; // Tolerance range around the maintain distance

    public GameObject lavaPoolPrefab;
    public float eruptionForce = 5f;
    public float despawnTime = 5f; // Time in seconds before the lava pool despawns
    public float attackCooldown = 10f; // Time in seconds between attacks
    private float attackTimer;

    private void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Move towards or away from the player to maintain the desired distance, or stop if within the tolerance range
        if (distanceToPlayer > maintainDistance + distanceTolerance)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else if (distanceToPlayer < maintainDistance - distanceTolerance)
        {
            // Move away from the player
            Vector3 direction = (transform.position - player.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        // If the monster is within the tolerance range of the maintain distance, it stops moving

        // Handle attack cooldown and perform the Lava Pool Attack when ready
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            LavaPoolAttack();
            attackTimer = attackCooldown; // Reset the attack cooldown timer
        }
    }

    public void LavaPoolAttack()
    {
        GameObject lavaPool = Instantiate(lavaPoolPrefab, player.position, Quaternion.identity);
        Destroy(lavaPool, despawnTime); // Automatically despawn the lava pool after a set time

        // Apply force to nearby objects
        Collider2D[] colliders = Physics2D.OverlapCircleAll(lavaPool.transform.position, eruptionForce);
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = rb.transform.position - lavaPool.transform.position;
                rb.AddForce(direction.normalized * eruptionForce, ForceMode2D.Impulse);
            }
        }
    }
}
