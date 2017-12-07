using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Model))]
public class GameController : MonoBehaviour {

    private Model model;

    private void Awake()
    {
        model = gameObject.GetComponent<Model>();
    }


    public void GameOver()
    {
        Debug.Log("Player scored: " + Model.PlayerScore);
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
