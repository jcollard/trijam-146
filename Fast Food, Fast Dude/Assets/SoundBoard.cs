using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour
{
    public AudioSource BurgerFailed;
    public AudioSource BurgerSuccess;
    public AudioSource Splat;
    public AudioSource GameOver;
    public AudioSource Theme;

    public static SoundBoard INSTANCE;

    public void Start()
    {
        INSTANCE = this;
    }

}
