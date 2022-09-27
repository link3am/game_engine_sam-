using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static score instance;

    int scoreValue;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }

    }

    public void changescore(int getValue)
    {
        scoreValue += getValue;
        Debug.Log(scoreValue);
    }
}
