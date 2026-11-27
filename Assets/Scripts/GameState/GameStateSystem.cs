using Unity.VisualScripting;
using UnityEngine;





public class GameStateSystem : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    public enum GameState
    {
        Playing, Paused, GameOver
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameState currentState = GameState.Paused;
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
                //pauseMenu.disable;
                break;
        }
    }
}
