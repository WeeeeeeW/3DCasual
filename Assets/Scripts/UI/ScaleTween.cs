using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{

    public void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.25f).setIgnoreTimeScale(true);
    }

    public void OnClose(string command)
    {
        switch(command)
        {
            case "Resume":
                LeanTween.scale(gameObject, new Vector3(0, 0, 0), .1f).setIgnoreTimeScale(true).setOnComplete(Resume);
                break;
            case "Restart":
                LeanTween.scale(gameObject, new Vector3(0, 0, 0), .1f).setIgnoreTimeScale(true).setOnComplete(Restart);
                break;
            case "Play":
                LeanTween.scale(gameObject, new Vector3(0, 0, 0), .1f).setIgnoreTimeScale(true).setOnComplete(Play);
                break;
        }
    }

    void Resume()
    {
        AnalyticsManager.instance.LogEvent("ResumeGame", 1);
        Manager.instance.Resume();
    }
    void Restart()
    {
        AnalyticsManager.instance.LogEvent("RestatGame", 1);
        Manager.instance.Restart();
    }
    void Play()
    {
        AnalyticsManager.instance.LogEvent("StatGame", 1);
        Manager.instance.Play();
    }
}
