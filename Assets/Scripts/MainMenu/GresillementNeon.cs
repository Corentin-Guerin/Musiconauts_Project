using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GresillementNeon : MonoBehaviour
{
    public SpriteRenderer Neonaffiche;
    public Sprite NeonAllume;
    public Sprite NeonEteint;
    //public AudioMainMenu amm;

    private float delayCoupure;

    public void Start()
    {
       
        delayCoupure = 5;

    }
    public void Update()
    {
        if (delayCoupure > 0)
        {
            delayCoupure -= Time.deltaTime;
        }
        else
        {

            //amm.SoundBoutonMenu();
            Neonaffiche.sprite = NeonEteint;
            ExecuteAfterTime();
            Neonaffiche.sprite = NeonAllume;
            ExecuteAfterTime();
            Neonaffiche.sprite = NeonEteint;
            ExecuteAfterTime();
            Neonaffiche.sprite = NeonAllume;

            delayCoupure = Random.Range(7, 9);
        }

         IEnumerator ExecuteAfterTime()
            {
                yield return new WaitForSeconds(2);

            }





    }
}
