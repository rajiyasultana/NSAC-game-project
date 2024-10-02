using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
    public GameObject Massage;
    public float delayTime = 5f;
    //public UnityEvent onTimePassed;
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    // Update is called once per frame
    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(delayTime);

        Massage.SetActive(true);
        //onTimePassed.Invoke();
    }
}
