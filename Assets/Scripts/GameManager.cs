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

    [SerializeField] Projectile2D projectile2D;


    private void Awake()
    {
        // This finds the scripts automatically if they are in your scene!
        if (playerMovement == null) playerMovement = FindFirstObjectByType<PlayerMovement>();
        if (projectile2D == null) projectile2D = FindFirstObjectByType<Projectile2D>();

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

        // Get the data from your other scripts
        int totalShots = projectile2D.GetShotCount();
        int totalCoins = playerMovement.coinCount;

        // Call the updated function with only 2 parameters
        if (AnalyticManager.instance != null)
        {
            AnalyticManager.instance.SendLevelCompleteEvent(totalShots, totalCoins);
        }
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
