using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadBackground : MonoBehaviour
{
    private static DontDestroyOnLoadBackground instance;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
