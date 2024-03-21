using UnityEngine;

public class HomingBehavior : MonoBehaviour
{
    private Transform target;
    private float speed;
    private GameObject owner;
    private float rotationSpeed;

    public void Initialize(Transform target, GameObject owner, float speed, float rotationSpeed)
    {
        this.target = target;
        this.owner = owner;
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != owner && !gameObject.CompareTag("Monster"))
        {
            Destroy(gameObject); // Destroy the missile on contact with anything other than the owner and other monsters
        }
    }
}