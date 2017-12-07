using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModelAccess : MonoBehaviour {
    protected static Model model;

    public static Model Model
    {        
        set
        {
            model = value;
        }
    }
}
