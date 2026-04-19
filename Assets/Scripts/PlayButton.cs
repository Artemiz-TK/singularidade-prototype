using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnClickPlay()
    {
        GameManager.Instance.StartSimulation();
    }
}
