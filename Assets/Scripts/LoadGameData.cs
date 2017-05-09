using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LoadGameData : MonoBehaviour {

    public TextAsset gameData;
    public GameObject StorePrefab;
    public GameObject StorePanel;
    public void Start()
    {
        Invoke("LoadData", 0.1f);
    }

    public void LoadData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(gameData.text);
        XmlNodeList storeList = xmlDoc.GetElementsByTagName("store");

        foreach (XmlNode storeInfo in storeList)
        {

            GameObject newStore = Instantiate(StorePrefab);
            
            newStore.name = storeInfo["name"].InnerText;
                Debug.Log(newStore.name);
            Store storeComponent = newStore.GetComponent<Store>();
            storeComponent.name = storeList[0].InnerText;
            

            /*
            foreach (XmlNode storeTag in storeInfo)
            {
                //storeComponent.name = storeTag["name"].InnerText;
                
                //newStore.name = XmlNode  .InnerText;
                //newStore. = storeTag.InnerText;
                Debug.Log(storeTag.Name);
                Debug.Log(storeTag.InnerText);
            }
            */
        }
    
    }

}
