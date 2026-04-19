using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float force = 20f;
    public float radius = 5f;

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentState != GameState.Simulation)
            return;

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var obj in objects)
        {
            if (obj.TryGetComponent<Rigidbody2D>(out var body))
            {
                Vector2 direction = transform.position - obj.transform.position;
                float distance = direction.magnitude;

                float strength = force / distance;

                body.AddForce(direction.normalized * strength);
            }
        }
    }
}
