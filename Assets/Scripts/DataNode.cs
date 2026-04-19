using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DataNode : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;

    public float maxSpeed = 10f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentState != GameState.Simulation)
            return;

        LimitSpeed();
    }

    void LimitSpeed()
    {
        if (m_Rigidbody2D.linearVelocity.magnitude > maxSpeed)
        {
            m_Rigidbody2D.linearVelocity = m_Rigidbody2D.linearVelocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.EndGame(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Singularity"))
        {
            GameManager.Instance.EndGame(true);
        }
    }
}
