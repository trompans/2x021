using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameData : MonoBehaviour {

    public TextAsset gameData;
    public GameObject StorePrefab;
    public GameObject StorePanel;

    public void Start()
    {
        LoadData();
        //Para cargar un método con retraso :P...
        //Invoke("LoadData", 0.1f);
    }

    public void LoadData()
    {

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(gameData.text);

        // Añadimos el valor de textoBalanceActual a la variable currentBalance...
        XmlNodeList nodoBalanceActual = xmlDoc.GetElementsByTagName("textoBalanceActual");
        GameManager.instance.AddToBalance(float.Parse(nodoBalanceActual[0].InnerText));


        XmlNodeList storeList = xmlDoc.GetElementsByTagName("store");

        foreach (XmlNode storeInfo in storeList)
        {
            // Por cada nodo Xml(XmlNode) en storeList instanciamos
            //un nuevo GameObject(newStore)...
            GameObject newStore = Instantiate(StorePrefab);

            // Lo colocamos dentro del canvas panel StorePanel...
            newStore.transform.SetParent(StorePanel.transform);
            
            // Poner el nombre del store a storeNameText...
            newStore.GetComponentInChildren<Text>().text = storeInfo.SelectSingleNode("name").InnerText;

            // Poner el nombre del store a al objeto store...
            Store storeComponent = newStore.GetComponent<Store>();
            storeComponent.name = storeInfo.SelectSingleNode("name").InnerText;

            // Añadimos la imagen del store al botón...
            storeComponent.transform.Find("ImageButtonClick").GetComponent<Image>().sprite = Resources.Load<Sprite>(storeInfo.SelectSingleNode("name").InnerText);

            // Añadimos el resto de variables...
            storeComponent.baseStoreCost = float.Parse(storeInfo.SelectSingleNode("baseStoreCost").InnerText);
            storeComponent.baseStoreProfit = float.Parse(storeInfo.SelectSingleNode("baseStoreProfit").InnerText);
            storeComponent.storeTimer = float.Parse(storeInfo.SelectSingleNode("storeTimer").InnerText);
            storeComponent.storeCostMultiplier = float.Parse(storeInfo.SelectSingleNode("storeCostMultiplier").InnerText);

        }
    
    }

}
