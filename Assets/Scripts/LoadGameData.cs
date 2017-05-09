using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LoadGameData : MonoBehaviour {

    public TextAsset gameData;
    public void Start()
    {
        Invoke("LoadData", 0.5f);
    }

    public void LoadData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(gameData.text);
        XmlNodeList storeList = xmlDoc.GetElementsByTagName("store");

        foreach (XmlNode storeInfo in storeList)
        {
            //Debug.Log(storeInfo.Name);
            //Debug.Log(storeInfo.InnerText);

            foreach (XmlNode storeTagName in storeInfo)
            {
                Debug.Log(storeTagName.Name);
                Debug.Log(storeTagName.InnerText);
            }
        }
    
    }

}
