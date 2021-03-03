﻿using System.Collections;
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
    int fireStart = 0;
    FireSpawner fireSpawner;
    void Start()
    {
        GameObject civilians = GameObject.Find("Civilians");
        GameObject fire = GameObject.Find("Fire Spawner");
        civCount = GameObject.Find("Civ Count").GetComponentInChildren<TMP_Text>();
        fireCount = GameObject.Find("Fire Count").GetComponentInChildren<TMP_Text>();
    
        civStart = civilians.transform.childCount;

        foreach (Transform child in fire.transform){
            if(child.gameObject.activeSelf){
                fireStart++;
            }
        }
    }

    void Update()
    {
        civCount.text = civUpdate.ToString() + " / " + civStart.ToString();
        fireCount.text = fireUpdate.ToString() + " / " + fireStart.ToString();

        if(civUpdate == civStart && fireUpdate == fireStart){
            // level complete
        }
    
    }

}
