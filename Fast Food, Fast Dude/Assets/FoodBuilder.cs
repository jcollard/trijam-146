using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBuilder : MonoBehaviour
{

    public float Speed = 10;
    public float DefaultSpeed = 1;
    public Transform WayPoint;
    public SpriteRenderer FoodSprite;
    public Transform Container;
    public Transform StartPosition;
    private float restartAt = -1;
    public float RestartDelay = 1;
    public int MaxFails = 5;
    private bool IsGameOver {
        get => PlayerController.GetInstance().BurgersFailed >= MaxFails;
    }

    private readonly List<Ingredient> ingredients = new List<Ingredient>();

    public void OnMouseDown()
    {
        if (PlayerController.GetInstance().CurrentIngredient == Ingredient.None || IsGameOver)
        {
            return;
        }

        ingredients.Add(PlayerController.GetInstance().CurrentIngredient);
        PlayerController.GetInstance().CurrentIngredient = Ingredient.None;

        this.AddComponent(FoodSprite.sprite);
        SoundBoard.INSTANCE.Splat.Play();

        FoodSprite.sprite = null;

    }

    public void AddComponent(Sprite sprite)
    {
        GameObject obj = new GameObject();
        obj.transform.parent = Container;
        obj.transform.localPosition = new Vector2(0, 0);
        SpriteRenderer newRenderer = obj.AddComponent<SpriteRenderer>();
        newRenderer.sprite = sprite;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 currPosition = transform.position;

        if (currPosition.x < WayPoint.position.x)
        {
            this.transform.Translate(new Vector2(Speed, 0) * Time.deltaTime);
        }

        if (currPosition.x >= WayPoint.position.x)
        {
            this.transform.position = (Vector2)WayPoint.position;
            if (this.restartAt < 0)
            {
                this.restartAt = Time.time + RestartDelay;
            }
            DoCheck();
        }
        
    }

    public void DoCheck()
    {
        if (PlayerController.GetInstance().CheckBurger(ingredients))
        {
            Success();
            Speed += 0.25f;
            RestartConveyor();
            return;
        }

        if (this.restartAt > Time.time || this.restartAt < 0)
        {
            return;
        }
        
        Failure();
        RestartConveyor();

    }

    private void Success()
    {
        PlayerController controller = PlayerController.GetInstance();
        controller.BurgersServed++;
        controller.Score += controller.BurgersServed;
        SoundBoard.INSTANCE.BurgerSuccess.Play();
    }

    private void Failure()
    {
        PlayerController controller = PlayerController.GetInstance();
        controller.BurgersFailed++;
        SoundBoard.INSTANCE.BurgerFailed.Play();
        if (controller.BurgersFailed >= MaxFails)
        {
            controller.GameOver();
            this.Speed = 0;
            SoundBoard.INSTANCE.Theme.Stop();
            SoundBoard.INSTANCE.GameOver.Play();            
        }
    }


    private void RestartConveyor()
    {
        this.transform.position = StartPosition.position;
        this.restartAt = -1;
        Collard.UnityUtils.DestroyChildren(Container);
        ingredients.Clear();
    }

    public void Restart()
    {
        this.Speed = DefaultSpeed;
    }
}
