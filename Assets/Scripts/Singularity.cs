using UnityEngine;

public class Singularity : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmplitude = 0.2f;

    private Vector3 m_BaseScale;

    void Start()
    {
        m_BaseScale = transform.localScale;
    }

    void Update()
    {
        float t = Mathf.Sin(Time.time * pulseSpeed) * 0.5f + 0.5f;
        float scaleOffset = t * pulseAmplitude;

        transform.localScale = m_BaseScale + Vector3.one * scaleOffset;
    }
}
