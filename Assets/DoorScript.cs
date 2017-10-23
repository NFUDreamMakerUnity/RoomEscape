using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    bool isTrigger = false;
	[SerializeField]
    GameObject Door;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isTrigger)
		{
            Door.SetActive(false);
        }
		else
		{
			Door.SetActive(true);
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Key")
		{
            isTrigger = true;
        }
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "Key")
		{
            isTrigger = false;
        }
	}
}
