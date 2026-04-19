using UnityEngine;

public class ForceVector : MonoBehaviour
{
    public Vector2 forceDirection;
    public float forceMagnitude = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.currentState != GameState.Simulation)
            return;

        if (other.TryGetComponent<Rigidbody2D>(out var body))
            body.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Impulse);
    }
}
