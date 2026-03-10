using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] TextMeshProUGUI currentCoin;
    [SerializeField] TextMeshProUGUI winTotalCoins;
    [SerializeField] TextMeshProUGUI loseTotalCoins;
    [SerializeField] TextMeshProUGUI currentHp;

    [SerializeField] GameObject gameOverScene;
    [SerializeField] GameObject gameWinScene;


    private void Awake()
    {
        gameOverScene.SetActive(false);
        gameWinScene.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        currentCoin.text = "Coin Collected: " + playerMovement.coinCount.ToString() + "/20";
        winTotalCoins.text = "Coin Collected: " + playerMovement.coinCount.ToString();
        loseTotalCoins.text = "Coin Collected: " + playerMovement.coinCount.ToString();
        currentHp.text = "HP: " + playerMovement.playerHp.ToString();
    }

    public void GameOver()
    {
        gameOverScene.SetActive(true);
    }

    public void GameWin()
    {
        gameWinScene.SetActive(true);
    }

    public void Restart()
    {
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
