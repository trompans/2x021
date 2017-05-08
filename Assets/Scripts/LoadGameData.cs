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
        XmlNodeList storeList = 
    }

}
