using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour {

    public Text storeCountText;
    public Slider progressSlider;
    public Text buyButtonText;
    public Button buyButton;
    
    public Store store;

    private void Awake()
    {
        store = transform.GetComponent<Store>();
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        progressSlider.value = store.currentTimer / store.storeTimer;

    }
}
