using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject[] background;
    int index;
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 4) index = 4;

        if(index < 0) index = 0;

        if(index == 0)
        {
            background[index].gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1;

        for(int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true) ;
        }

    }

    public void previous()
    {
        index -= 1;

        for(int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
    }
}
