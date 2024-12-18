using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Image day;
    public Image night;
    public Image titleDay;
    public Image titlenight;
    public Image subTitleDay;
    public Image subTitleNight;
    //private DateTime time;

    void Update()
    {
        // Get the current time
        DateTime currentTime = DateTime.Now;
        TimeSpan currentTimeOfDay = currentTime.TimeOfDay;

        // Define the start and end times for night
        TimeSpan nightStart = new TimeSpan(18, 0, 0); // 6 PM
        TimeSpan nightEnd = new TimeSpan(6, 0, 0); // 6 AM

        // Check if the current time is within the night period
        bool isNight = currentTimeOfDay >= nightStart || currentTimeOfDay < nightEnd;

        // Output the result
        if (isNight == false)
        {
            day.gameObject.SetActive(true);
            titleDay.gameObject.SetActive(true);
            subTitleDay.gameObject.SetActive(true);
            night.gameObject.SetActive(false);
            titlenight.gameObject.SetActive(false);
            subTitleNight.gameObject.SetActive(false);
        }    
        if (isNight == true)
        {
            day.gameObject.SetActive(false);
            titleDay.gameObject.SetActive(false);
            subTitleDay.gameObject .SetActive(false);
            night.gameObject.SetActive(true);
            titlenight.gameObject.SetActive(true);
            subTitleNight.gameObject.SetActive(true);
        }
        //Debug.Log("Is it night? " + isNight);
    }
    public void level1()
    {
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        SceneManager.LoadScene(2);
    }
    public void level3()
    {
        SceneManager.LoadScene(3);
    }
    public void level4()
    {
        SceneManager.LoadScene(4);
    }
}
