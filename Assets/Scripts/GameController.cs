using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Model))]
public class GameController : MonoBehaviour {

    public ShowPanels showPanels;

   

    static GameController instance;

    private void Awake()
    {
        instance = this;
        
    }

    public void GameOver()
    {
        //Debug.Log("Player scored: " + Model.Instance.PlayerScore);        
        showPanels.ShowGameOverPanel();
    }

    // Getter and Setter
    public static GameController Instance
    {
        get
        {
            return instance;
        }       
    }

    internal void ResetModel()
    {
        Destroy(Model.Instance);
        gameObject.AddComponent<Model>();
    }
}
