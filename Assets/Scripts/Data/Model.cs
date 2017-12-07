using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    static Model instance;
    [SerializeField]
    int playerScore;

    private void Awake()
    {
        instance = this;
    }

    public int PlayerScore
    {
        get
        {
            return playerScore;
        }

        set
        {
            playerScore = value;
        }
    }

    public static Model Instance
    {
        get
        {
            return instance;
        }       
    }
}
