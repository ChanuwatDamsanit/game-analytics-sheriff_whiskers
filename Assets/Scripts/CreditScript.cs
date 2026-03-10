using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public float rollSpeed = 40f;
    [SerializeField] private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, rollSpeed * Time.deltaTime);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
