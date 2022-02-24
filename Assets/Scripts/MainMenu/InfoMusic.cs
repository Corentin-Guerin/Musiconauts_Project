using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InfoMusic : MonoBehaviour
{
    public bool setInfoMusique = false;
    private AudioMainMenu amm;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UnactiveInfoMusique();
    }

    public void UnactiveInfoMusique()
    {
        setInfoMusique = false;
    }

    public void AfficheInfo(bool a)
    {
        amm = FindObjectOfType<AudioMainMenu>();

        if (setInfoMusique == false) 
        {
            amm.SoundBoutonMenu();
            setInfoMusique = true;
            //Debug.LogWarning(informationMusique);
            gameObject.SetActive(a); 
        }
  
    }
}
