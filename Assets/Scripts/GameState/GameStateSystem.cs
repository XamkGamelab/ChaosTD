using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;





public class GameStateSystem : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    public enum GameState
    {
        Playing, Paused, GameOver
    }

    public void Start()
    {
        SwitchState(GameState.Playing);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameState currentState = GameState.Paused;

    public GameState gameState()
    { return currentState; }
    public void SwitchState(GameState state)
    {
        if (currentState == state) return;
        currentState = state;
        HandleStateChange();
    }
    

    // Update is called once per frame
    private void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.Playing:
                pauseMenu.TogglePauseMenu(false);
                break;
            case GameState.Paused:
                pauseMenu.TogglePauseMenu(true);
                break;
            case GameState.GameOver:
                SceneManager.LoadSceneAsync(0);
                break;
            default: 
                break;
        }
    }
}
