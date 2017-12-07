using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Model))]
public class GameController : MonoBehaviour {

    public ShowPanels showPanels;

    private Model model;

    private void Awake()
    {
        model = gameObject.GetComponent<Model>();
        UIModelAccess.Model = model;
    }


    public void GameOver()
    {
        Debug.Log("Player scored: " + Model.PlayerScore);
        showPanels.ShowGameOverPanel();
    }

    // Getter and Setter

    public Model Model
    {
        get
        {
            return model;
        }        
    }
}
