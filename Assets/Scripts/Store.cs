﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    // Public variables - Define Gameplay //
    public float baseStoreCost;
    public float baseStoreProfit;
    public float storeTimer;
    public int   storeCount;
    public bool  managerUnlocked;
    public float storeCostMultiplier;

    //Duplicadas en UIStore
    
    public Text storeCountText;
    //public Slider progressSlider;
    public Text buyButtonText;
    public Button buyButton;
    

    public Image fillColor;
    private float nextStoreCost;

    public float currentTimer = 0;
    public bool  startTimer;


    // Use this for initialization
    void Start () {

        startTimer = false;
        storeCountText.text = storeCount.ToString();
        nextStoreCost = baseStoreCost;

        fillColor.color = Color.clear;

    }

    // Update is called once per frame
    void Update () {

        if (startTimer)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= storeTimer)
            {
                if (!managerUnlocked)
                {
                    startTimer = false;
                    fillColor.color = Color.clear;
                }
                currentTimer = 0;
                GameManager.instance.AddToBalance(baseStoreProfit * storeCount);
            }
        }
        CheckStoreBuy();
		
	}

    // Own Methods...
    public void CheckStoreBuy()
    {
        if (GameManager.instance.CanBuy(nextStoreCost))
            buyButton.interactable = true;
        else
            buyButton.interactable = false;
    }

    public void BuyStoreOnClick()
    {
        if (!GameManager.instance.CanBuy(nextStoreCost))
        {
            return;
        }
        storeCount++;
        storeCountText.text = storeCount.ToString();
        GameManager.instance.AddToBalance(-nextStoreCost);
        nextStoreCost = (baseStoreCost * Mathf.Pow(storeCostMultiplier, storeCount));
        buyButtonText.text = "¡Compra! " + nextStoreCost.ToString("##.## €");
        //Debug.Log(nextStoreCost);
    }

    public void StoreOnClick()
    {
        if (!startTimer && storeCount > 0)
        {
            startTimer = true;
            fillColor.color = Color.green;
        }
    }
}
