using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour 
{

    public Text display;
    public string message;
    Bag bag;

	// Use this for initialization
	void Start () 
    {
        bag = GameObject.Find("GameManager").GetComponent<Bag>();
        display = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        display.text = message + bag.pickUps;
	}
}
