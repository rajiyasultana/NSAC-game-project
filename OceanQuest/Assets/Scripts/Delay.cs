using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public GameObject Massage;
    public float delayTime = 3f;
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    // Update is called once per frame
    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(delayTime);

        Massage.SetActive(true);
    }
}
