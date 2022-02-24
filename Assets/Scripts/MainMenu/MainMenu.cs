using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> toutesLesMusiques;
    private AudioClip ancienneMusique;

    private float timer;
    private float tempsMusique;

    private void Start()
    {
        LancerMusique();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= tempsMusique)
        {
            timer = 0;
            audioSource.Stop();
            LancerMusique();
        }
        
    }

    private AudioClip RandomMusic()
    {
        AudioClip musiqueRandom = toutesLesMusiques[Random.Range(0, toutesLesMusiques.Count)];

        return musiqueRandom;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT !!");
        Application.Quit();
    }

    private void ChoixMusique()
    {
        AudioClip randomChoisie = RandomMusic();
        if(randomChoisie == ancienneMusique)
        {
            ChoixMusique();
            return;
        }
        else
        {
            ancienneMusique = randomChoisie;
            tempsMusique = ancienneMusique.length;
            audioSource.clip = ancienneMusique;
            audioSource.Play();
        }
    }

    public void LancerMusique()
    {
        ChoixMusique();

    }
}
