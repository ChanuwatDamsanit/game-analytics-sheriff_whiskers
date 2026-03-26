using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Collections.Generic;

public class AnalyticManager : MonoBehaviour
{
    public static AnalyticManager instance;

    // Variable to store the time when the level starts
    private float levelStartTime;

    private async void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    // 1. Call this when a level begins (e.g., in Start() of a LevelManager)
    public void StartLevelTimer()
    {
        levelStartTime = Time.time;
    }

    // 2. Call this when the player hits the finish line or goal
    // Inside AnalyticManager.cs
    public void SendLevelCompleteEvent(int bulletsFired, int coinsCollected)
    {
        // 1. คำนวณส่วนต่างเวลา (เป็น float เพื่อให้มีทศนิยม)
        float rawTime = Time.time - levelStartTime;

        // 2. ปัดเศษให้เหลือ 2 ตำแหน่ง
        // สูตรคือ (ค่า * 100) -> ปัดเศษ -> หารด้วย 100.0f
        float roundedTime = Mathf.Round(rawTime * 100f) / 100f;

        CustomEvent levelEvent = new CustomEvent("SheriffAnalytic")
    {
        { "shootCount", bulletsFired },
        { "coinCount", coinsCollected },
        { "timeToCompleteLevel", roundedTime } // ส่งเป็น float ที่มีทศนิยม 2 ตำแหน่ง
    };

        AnalyticsService.Instance.RecordEvent(levelEvent);
        Debug.Log($"[Analytics] | Time: {roundedTime}s | Shots: {bulletsFired} | Coins: {coinsCollected}");
    }
}