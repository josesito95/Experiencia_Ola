using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button comenzar;
    public Button acercaDe;
    public Button creditos;
    public Button salir;

    void Start()
    {
        comenzar.onClick.AddListener(StartGame);
        acercaDe.onClick.AddListener(ShowAbout);
        creditos.onClick.AddListener(ShowCredits);
        salir.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Cambia "GameScene" por el nombre de tu escena principal
    }

    void ShowAbout()
    {
        SceneManager.LoadScene("AboutScene"); // Escena de información sobre OLA
    }

    void ShowCredits()
    {
        SceneManager.LoadScene("CreditsScene"); // Escena de créditos
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
