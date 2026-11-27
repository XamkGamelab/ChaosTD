using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void TogglePauseMenu(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()

    {
        
    }
}
