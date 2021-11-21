using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static readonly string TAG = "PlayerController";

    public static PlayerController GetInstance()
    {
        return GameObject.FindGameObjectWithTag(PlayerController.TAG).GetComponent<PlayerController>();
    }
    public Ingredient CurrentIngredient = Ingredient.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
