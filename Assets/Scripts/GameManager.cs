using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public float currentBalance;
 


    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddToBalance(float cantidad)
    {
        currentBalance += cantidad;
        UIManager.instance.UpdateUI();
    }

    public bool CanBuy(float cantidadaGastar)
    {
        if (cantidadaGastar > currentBalance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
