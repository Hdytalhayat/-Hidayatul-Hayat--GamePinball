using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsUIController : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
