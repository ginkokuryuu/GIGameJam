using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndicatorsController : MonoBehaviour
{
    TMP_Text civCount;
    TMP_Text fireCount;
    public int civUpdate = 0;
    public int fireUpdate = 0;
    int civStart;
    public int fireStart;

    GameObject popUpClear;
    PlayerMovement player;


    void Start()
    {
        GameObject civilians = GameObject.Find("Civilians");
        GameObject fire = GameObject.Find("Fire Spawner");
        popUpClear = GameObject.Find("PopUpClear");
        popUpClear.SetActive(false);
        civCount = GameObject.Find("Civ Count").GetComponentInChildren<TMP_Text>();
        fireCount = GameObject.Find("Fire Count").GetComponentInChildren<TMP_Text>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        civStart = civilians.transform.childCount;
        Debug.Log(civStart + " " + fireStart);
    }

    void Update()
    {
        civCount.text = civUpdate.ToString() + " / " + civStart.ToString();
        fireCount.text = fireUpdate.ToString() + " / " + fireStart.ToString();

        if(civUpdate == civStart && fireUpdate == fireStart){
            // level complete
            player.enabled = false;
            popUpClear.SetActive(true);
        }
    
    }

}
