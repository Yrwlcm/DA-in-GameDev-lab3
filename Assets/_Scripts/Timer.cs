using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float seconds = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    seconds += 1 * Time.deltaTime;
        Debug.Log(seconds);
    }
}
