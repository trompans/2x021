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
        XmlNodeList storeList = xmlDoc.GetElementsByTagName("store");

        foreach (XmlNode storeInfo in storeList)
        {

            GameObject newStore = Instantiate(StorePrefab);
            newStore.transform.SetParent(StorePanel.transform);
            
            //Poner el nombre del store a storeNameText...
            newStore.GetComponentInChildren<Text>().text = storeInfo.SelectSingleNode("name").InnerText;

            //Poner el nombre del store a al objeto store...
            Store storeComponent = newStore.GetComponent<Store>();
            storeComponent.name = storeInfo.SelectSingleNode("name").InnerText;

            storeComponent.baseStoreCost = float.Parse(storeInfo.SelectSingleNode("baseStoreCost").InnerText);
            storeComponent.baseStoreProfit = float.Parse(storeInfo.SelectSingleNode("baseStoreProfit").InnerText);
            storeComponent.storeTimer = float.Parse(storeInfo.SelectSingleNode("storeTimer").InnerText);
            storeComponent.storeCostMultiplier = float.Parse(storeInfo.SelectSingleNode("storeCostMultiplier").InnerText);



            

            /*
            foreach (XmlNode storeTag in storeInfo)
            {
                storeComponent.name = storeTag["name"].InnerText;
                
                //newStore.name = XmlNode  .InnerText;
                //newStore. = storeTag.InnerText;
                Debug.Log(storeTag.Name);
                Debug.Log(storeTag.InnerText);
            }
            */
        }
    
    }

}
