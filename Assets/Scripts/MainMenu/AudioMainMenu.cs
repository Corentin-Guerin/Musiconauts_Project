using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMainMenu : MonoBehaviour
{
    public AudioSource fondMenu;
    public AudioSource boutonMenu;
    //public AudioSource startNeon;



    public void SoundBoutonMenu()
    {
        boutonMenu.Play();
    }
    /*
    public void StartNeon()
    {
        startNeon.Play();
    }*/

    public void MusicFondMenu()
    {
        fondMenu.Play();
    }

}
