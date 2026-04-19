using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject attractorPrefab;
    public GameObject vectorPrefab;

    private Vector2 m_DragStart;
    private bool m_IsDragging;

    void Update()
    {
        if (GameManager.Instance.currentState != GameState.Input)
            return;

        HandleAttractor();
        HandleVector();
    }

    void HandleAttractor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(attractorPrefab, pos, Quaternion.identity);
        }
    }

    void HandleVector()
    {
        if (Input.GetMouseButtonDown(1))
        {
            m_DragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_IsDragging = true;
        }

        if (Input.GetMouseButtonUp(1) && m_IsDragging)
        {
            Vector2 end = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = end - m_DragStart;

            GameObject vector = Instantiate(vectorPrefab, m_DragStart, Quaternion.identity);
            vector.GetComponent<ForceVector>().forceDirection = direction;

            m_IsDragging = false;
        }
    }
}
