using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InfoMusic : MonoBehaviour
{
    public bool setInfoMusique = false;
    public GameObject informationMusique;

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
        if (setInfoMusique == false) 
        {
            setInfoMusique = true;
            Debug.LogWarning(informationMusique);
            informationMusique.SetActive(a); 
        }
  
    }
}
