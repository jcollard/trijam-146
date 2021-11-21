using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientController : MonoBehaviour
{

    private SpriteRenderer ToCopy;
    public SpriteRenderer Target;
    public Ingredient Type;

    public void Start()
    {
        this.ToCopy = this.GetComponent<SpriteRenderer>();
        if (this.ToCopy == null)
        {
            throw new System.Exception($"Couldn't initialize IngredientController. No SpriteRenderer found. {this}.");
        }
    }

    void OnMouseDown()
    {
        Target.sprite = ToCopy.sprite;
        PlayerController.GetInstance().CurrentIngredient = Type;
    }
}

public enum Ingredient
{
    None,
    BottomBun,
    Sauce,
    Patty,
    Cheese,
    Lettuce,
    Pickles,
    Tomatoe,
    TopBun
}