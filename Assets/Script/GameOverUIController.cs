
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button mainMenuButton;
    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
