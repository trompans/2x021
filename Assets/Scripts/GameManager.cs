using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public delegate void UpdateBalance();
    public static event UpdateBalance OnUpdateBalance;

    public static GameManager instance;
    float currentBalance;
 


    // Use this for initialization
    void Start () {

        currentBalance = 10f;

        if (OnUpdateBalance != null)
        {
            OnUpdateBalance();
        }
    }

    // Update is called once per frame
    void Update () {

        //UpdateUI();

    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddToBalance(float cantidad)
    {
        currentBalance += cantidad;
        if (OnUpdateBalance != null)
        {
            OnUpdateBalance();
        }
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

	public float GetCurrentBalance(){
		return currentBalance;
	}

}
