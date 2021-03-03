using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeLimit : MonoBehaviour
{
    TMP_Text timeStatus;
    Image timeBox;
    public float setTime;
    void Start()
    {
        timeStatus = GameObject.Find("Timer").GetComponentInChildren<TMP_Text>();
        timeBox = GameObject.Find("Timer Box").GetComponentInChildren<Image>();
        StartCoroutine(reloadTimer(setTime));
    }

    IEnumerator reloadTimer(float counter)
    {
        while (counter > 0)
        {
            counter -= Time.deltaTime;
            int min = Mathf.FloorToInt(counter / 60);
            int sec = Mathf.RoundToInt(counter % 60);

            string strMin = StringConverter(min);
            string strSec = StringConverter(sec);

            if (counter <= 10)
            {
                timeBox.color = new Color32(250, 145, 22, 250);
                if (counter <= 5)
                {
                    timeBox.color = new Color32(172, 26, 26, 250);
                }
            }

            timeStatus.text = strMin + " : " + strSec;
            yield return null;
        }

        if (counter <= 0)
            timeStatus.text = " Time's Up!";
    }

    string StringConverter(int time)
    {
        if (time / 10 == 0)
        {
            return "0" + time.ToString();
        }

        else return time.ToString();
    }
}
