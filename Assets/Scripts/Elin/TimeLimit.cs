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
    GameObject popUpFailed = null;
    PlayerMovement player;
    void Start()
    {
        timeStatus = GameObject.Find("Timer").GetComponentInChildren<TMP_Text>();
        timeBox = GameObject.Find("Timer Box").GetComponentInChildren<Image>();
        StartCoroutine(reloadTimer(setTime));
        popUpFailed = GameObject.Find("PopUpFailed");
        popUpFailed.SetActive(false);
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
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
                timeBox.color = new Color32(250, 145, 22, 200);
                if (counter <= 5)
                {
                    timeBox.color = new Color32(172, 26, 26, 200);
                }
            }

            timeStatus.text = strMin + " : " + strSec;
            yield return null;
        }

        if (counter <= 0)
        {
            timeStatus.text = " Time's Up!";
            player.enabled = false;
            popUpFailed.SetActive(true);
        }
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
