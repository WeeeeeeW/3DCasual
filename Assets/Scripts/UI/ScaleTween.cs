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
        }
    }

    void Resume()
    {
        Manager.instance.Resume();
    }
    void Restart()
    {
        Manager.instance.Restart();
    }
}
