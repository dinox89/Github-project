using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedGems : MonoBehaviour
{
    Text text;
    int points = 0;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = points.ToString();
	}
    public void AddPoints(int _points)
    {
        points += _points;
    }
}
