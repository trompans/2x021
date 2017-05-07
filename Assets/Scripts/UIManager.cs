using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;
    public Text currentBalanceText;

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

    public void UpdateUI()
    {
		currentBalanceText.text = GameManager.instance.GetCurrentBalance().ToString("C", System.Globalization.CultureInfo.GetCultureInfo("es-es"));

        //Distintas formas de dar formato a ToString... "https://msdn.microsoft.com/es-es/library/dwhawy9k(v=vs.110).aspx"
        //currentBalanceText.text = currentBalance.ToString("C", System.Globalization.CultureInfo.CurrentCulture);
        //Otra forma...
        //currentBalanceText.text = currentBalance.ToString("##.## €");

    }
}
