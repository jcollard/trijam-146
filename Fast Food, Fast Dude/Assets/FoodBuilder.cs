using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBuilder : MonoBehaviour
{

    public float Speed = 10;
    public Transform WayPoint;
    public SpriteRenderer FoodSprite;
    public Transform Container;

    private readonly List<Ingredient> ingredients = new List<Ingredient>();

    public void OnMouseDown()
    {
        if ( PlayerController.GetInstance().CurrentIngredient == Ingredient.None)
        {
            return;
        }

        ingredients.Add(PlayerController.GetInstance().CurrentIngredient);
        PlayerController.GetInstance().CurrentIngredient = Ingredient.None;

        this.AddComponent(FoodSprite.sprite);

        FoodSprite.sprite = null;

    }

    public void AddComponent(Sprite sprite)
    {
        GameObject obj = new GameObject();
        obj.transform.parent = Container;
        obj.transform.localPosition = new Vector2(0,0);
        SpriteRenderer newRenderer = obj.AddComponent<SpriteRenderer>();
        newRenderer.sprite = sprite;
        

        
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 currPosition = transform.position;

        if (currPosition.x < WayPoint.position.x)
        {
            this.transform.Translate(new Vector2(Speed, 0)*Time.deltaTime);
        }

        if (currPosition.x > WayPoint.position.x)
        {
            this.transform.position = (Vector2)WayPoint.position;
        } 

    }
}
