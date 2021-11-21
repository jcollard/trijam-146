using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static readonly string TAG = "PlayerController";
    public Ingredient CurrentIngredient = Ingredient.None;

    public UnityEngine.UI.Text BurgersServedText;
    public UnityEngine.UI.Text UnhappyCustomersText;
    public Canvas GameOverScreen;
    public FoodBuilder FoodBuilder;

    private int _burgersServed;
    public int BurgersServed
    {
        get => _burgersServed;
        set
        {
            _burgersServed = value;
            BurgersServedText.text = $"Burgers Served: {_burgersServed}.";
        }
    }

    private int _burgersFailed;

    public int BurgersFailed
    {
        get => _burgersFailed;
        set
        {
            _burgersFailed = value;
            UnhappyCustomersText.text = $"Unhappy Customers: {_burgersFailed}";
        }

    }
    public int Score;
    private List<Ingredient> BurgerComponents = new List<Ingredient>();

    public void Start()
    {
        BurgerComponents.Add(Ingredient.Patty);
        BurgerComponents.Add(Ingredient.Cheese);
        BurgerComponents.Add(Ingredient.Lettuce);
        BurgerComponents.Add(Ingredient.Pickles);
        BurgerComponents.Add(Ingredient.Tomatoe);
        this.BurgersServed = 0;
        this.BurgersFailed = 0;
    }

    public static PlayerController GetInstance()
    {
        return GameObject.FindGameObjectWithTag(PlayerController.TAG).GetComponent<PlayerController>();
    }

    public bool CheckBurger(List<Ingredient> ToCheck)
    {
        if (ToCheck.Count != (BurgerComponents.Count + 2))
        {
            return false;
        }

        if (ToCheck[0] != Ingredient.BottomBun)
        {
            return false;
        }

        if (ToCheck[ToCheck.Count - 1] != Ingredient.TopBun)
        {
            return false;
        }

        foreach (Ingredient i in BurgerComponents)
        {
            if (!ToCheck.Contains(i))
            {
                return false;
            }
        }

        return true;
    }

    public void GameOver()
    {
        this.GameOverScreen.gameObject.SetActive(true);
    }

    public void Restart()
    {
        this.BurgersServed = 0;
        this.BurgersFailed = 0;
        this.Score = 0;
        this.GameOverScreen.gameObject.SetActive(false);
        this.FoodBuilder.Restart();
        SoundBoard.INSTANCE.GameOver.Stop();
        SoundBoard.INSTANCE.Theme.Play();
        
    }
}
