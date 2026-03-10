using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
     public void CreditScene()
    {
        SceneManager.LoadSceneAsync("CreditScene");
    }
}
