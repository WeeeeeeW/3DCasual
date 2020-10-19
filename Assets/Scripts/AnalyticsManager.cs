using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Test();
    }
    public void LogEvent(string eventName, int value)
    {
        Debug.Log("log_event");
        FirebaseAnalytics.LogEvent(eventName, "a", value);
        
    }
    public void Test()
    {
        LogEvent("Testing Analytics", 1);
    }
}

