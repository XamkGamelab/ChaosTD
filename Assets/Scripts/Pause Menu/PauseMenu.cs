using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ToggleMainMenu(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
