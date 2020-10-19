using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LuckyWheel : MonoBehaviour
{
    public static LuckyWheel instance { get; private set; }
    private bool isStarted;
    private float[] sectorsAngles;
    private float finalAngle;
    private float startAngle = 0;
    private float currentLerpRotationTime;
    public Button SpinButton;
    public GameObject Wheel; 			
    public Text StarsDeltaText; 		
    public Text CurrentStarsText; 		
    public int snipCost;			
    public int currentStarsQuantity;	
    public int preStarsQuantity;		

    private void Awake()
    {
        instance = this;
           
    }
    private void Start()
    {
        snipCost = 100;
        currentStarsQuantity = JSonData._instance.gameData.starQuantity;
        preStarsQuantity = currentStarsQuantity;
        CurrentStarsText.text = currentStarsQuantity.ToString();
    }
    void Update()
    {
        if (isStarted || currentStarsQuantity < snipCost)
        {
            SpinButton.interactable = false;
            SpinButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
        }
        else
        {
            SpinButton.interactable = true;
            SpinButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }

        if (!isStarted)
        {
            return;
        }          
        float maxLerpRotationTime = 4f;

        currentLerpRotationTime += Time.deltaTime;

        if (currentLerpRotationTime > maxLerpRotationTime || Wheel.transform.eulerAngles.z == finalAngle)
        {
            currentLerpRotationTime = maxLerpRotationTime;
           // Debug.Log("currentLerpRotationTime: " + currentLerpRotationTime);
            isStarted = false;
            startAngle = finalAngle % 360;

            GiveAwardByAngle();
           // Debug.Log("startangle: " + startAngle);
            StartCoroutine(HideStarsDelta());
        }
        float t = currentLerpRotationTime / maxLerpRotationTime;
        t = t * t * t * (t * (6f * t - 15f) + 10f);

        float angle = Mathf.Lerp(startAngle, finalAngle, t);
       // Debug.Log("angle: " + angle);
        Wheel.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    public void SpinnWheel()
    {   
        if (currentStarsQuantity >= snipCost)
        {
            AnalyticsManager.instance.LogEvent("PlayLuckyWheel",1);
            Time.timeScale = 1;
            currentLerpRotationTime = 0f;
            sectorsAngles = new float[] { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 360 };

            int fullWheels = 5;
            float randomFinalAngle = sectorsAngles[UnityEngine.Random.Range(0, sectorsAngles.Length)];

            finalAngle = -(fullWheels * 360 + randomFinalAngle);
            isStarted = true;

            preStarsQuantity = currentStarsQuantity;
            currentStarsQuantity -= snipCost;

            StarsDeltaText.text = "-" + snipCost;
            StarsDeltaText.gameObject.SetActive(true);
            StartCoroutine(HideStarsDelta());
            StartCoroutine(UpdateStarsQuantity());
        }
    }

    private void GiveAwardByAngle()
    {
        switch ((int)startAngle)
        {
            case 0:
                RewardStars(10);
                break;
            case -330:
                RewardStars(1000);
                break;
            case -300:
                RewardStars(200);
                break;
            case -270:
                RewardStars(100);
                break;
            case -240:
                RewardStars(0);
                break;
            case -210:
                RewardStars(50);
                break;
            case -180:
                RewardStars(100);
                break;
            case -150:
                RewardStars(0);
                break;
            case -120:
                RewardStars(100);
                break;
            case -90:
                RewardStars(50);
                break;
            case -60:
                RewardStars(10);
                break;
            case -30:
                RewardStars(0);
                break;
            default:
                RewardStars(10);
                break;
        }
    }
    private void RewardStars(int awardStars)
    {
        currentStarsQuantity += awardStars;
        Manager.instance.starQuantity = currentStarsQuantity;
        JSonData._instance.gameData.starQuantity = currentStarsQuantity;
        JSonData._instance.SaveData();
     
        StarsDeltaText.text = "+" + awardStars;
        StarsDeltaText.gameObject.SetActive(true);
        StartCoroutine(UpdateStarsQuantity());
    }

    private IEnumerator HideStarsDelta()
    {
        yield return new WaitForSeconds(1f);
        StarsDeltaText.gameObject.SetActive(false);
    }

    private IEnumerator UpdateStarsQuantity()
    {
        const float seconds = 0.5f;
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            CurrentStarsText.text = Mathf.Floor(Mathf.Lerp(preStarsQuantity, currentStarsQuantity, (elapsedTime / seconds))).ToString();
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        preStarsQuantity = currentStarsQuantity;
        CurrentStarsText.text = currentStarsQuantity.ToString();
    }
}
