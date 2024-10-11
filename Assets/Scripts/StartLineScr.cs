using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLineScr : MonoBehaviour
{
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.StartTimer();
        }
    }
}
