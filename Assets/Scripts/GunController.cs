using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GunController : MonoBehaviour
{
    public GameObject[] balls;
    public static int points;

    public Button RedButton;
    public Button YellowButton;
    public Button BlueButton;

    public GameObject GameOverPanel;
    public GameObject InGamePanel;
    public TextMeshProUGUI PointsTextInGame;
    public TextMeshProUGUI PointsTextGameOver;

    public static string hiphooraytext = "";
    public GameObject HipHipHooray;
    
    
    public float MoveSpeed;
    public float RotationSpeed;
    public Transform BulletSpawnLocation;

    private bool isPaused = false;
    public static bool changed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            // If the game is paused, skip the rest of the Update function
            return;
        }
        /*gun movement*/
        float vertical = Input.GetAxis("Vertical");
        float time = Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        float rotation = RotationSpeed * time * horizontal;
        transform.Rotate(0, rotation, 0);

        HipHipHooray.GetComponent<TextMeshProUGUI>().text = hiphooraytext;
        if(changed)
        {
            changed = false;
            LeanTween.scale(HipHipHooray, new Vector3(1.5f, 1.5f, 1.5f), 0.5f)
        .setEase(LeanTweenType.easeOutElastic)
        .setOnComplete(() =>
        {
            // After scaling up, scale down and disappear quickly
            LeanTween.scale(HipHipHooray, Vector3.zero, 0.5f)
                .setEase(LeanTweenType.easeInElastic)
                .setOnComplete(() =>
                {
                    // Set the text to an empty string when the shrinking is complete
                    HipHipHooray.GetComponent<TextMeshProUGUI>().text = "";
                });
        });


        }




        PointsTextInGame.text = points.ToString(); 

        /*bullet movement*/
        float distance = MoveSpeed * time * vertical;
        transform.Translate(0, 0, distance);

        /*gameover*/
        if (points >15) /*change to 15*/
        {
            Debug.Log("gameover");
            PointsTextGameOver.text = points.ToString();
            PauseScene();
            InGamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
            points = 0;
            hiphooraytext = "";
        }

        /*set condition of one ball each time*/
        if (GameObject.Find("Yellow Ball(Clone)"))
        {
            YellowButton.interactable = false;
        }else
        {
            YellowButton.interactable = true;
        }

        if (GameObject.Find("Blue Ball(Clone)"))
        {
            BlueButton.interactable = false;
        }else
        {
            BlueButton.interactable = true;
        }

        if (GameObject.Find("Red Ball(Clone)"))
        {
            RedButton.interactable = false;
        }else
        {
            RedButton.interactable = true;
        }

    }
    public void SelectObject(int index)
    {
        /*Instantiate(balls[index], new Vector3(-47.7000008f, 10.6000004f, 46f), Quaternion.identity);*/
        Instantiate(balls[index], BulletSpawnLocation.transform.position, BulletSpawnLocation.transform.rotation);
        
    }
    void PauseScene()
    {
        isPaused = true;
        Time.timeScale = 0f; // Set time scale to 0 to pause
    }
}
