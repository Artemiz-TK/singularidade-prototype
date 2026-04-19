using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetState(GameState.Planning);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        Time.timeScale = (newState == GameState.Simulation) ? 1f : 0f;
    }

    public void StartSimulation()
    {
        SetState(GameState.Simulation);
    }

    public void EndGame(bool success)
    {
        SetState(GameState.Result);

        if (success)
        {
            Debug.Log("Sucesso");
        }
    }
}
