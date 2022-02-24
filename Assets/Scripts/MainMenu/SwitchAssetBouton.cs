using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchAssetBouton : MonoBehaviour
{

    [SerializeField]
    
    public bool activeButtonTrans = false;
    public SpriteRenderer BoutonafficheTrans;
    public Sprite BoutonActiveTrans;
    public Sprite BoutonDesactiveTrans;

    public bool activeButtonMus = false;
    public SpriteRenderer BoutonafficheMus;
    public Sprite BoutonActiveMus;
    public Sprite BoutonDesactiveMus;
    
    public bool activeButtonETPA = false;
    public SpriteRenderer BoutonafficheETPA;
    public Sprite BoutonActiveETPA;
    public Sprite BoutonDesactiveETPA;




    public void ActiveButtonTrans()
    {
        if (activeButtonTrans == false)
        {
            activeButtonTrans = true;
            activeButtonMus = false;
            activeButtonETPA = false;

            BoutonafficheTrans.sprite = BoutonActiveTrans;

            BoutonafficheMus.sprite = BoutonDesactiveMus;
            BoutonafficheETPA.sprite = BoutonDesactiveETPA;
        }
    }
    public void ActiveButtonMus()
    {
        if (activeButtonMus == false)
        {
            activeButtonMus = true;
            
            activeButtonTrans = false;
            activeButtonETPA = false;
            BoutonafficheMus.sprite = BoutonActiveMus;

            BoutonafficheTrans.sprite = BoutonDesactiveTrans;
            BoutonafficheETPA.sprite = BoutonDesactiveETPA;
        }
    }
    public void ActiveButtonETPA()
    {
        if (activeButtonETPA == false)
        {
            activeButtonETPA = true;

            activeButtonTrans = false;
            activeButtonMus = false;

            BoutonafficheETPA.sprite = BoutonActiveETPA; 
            
            BoutonafficheTrans.sprite = BoutonDesactiveTrans;
            BoutonafficheMus.sprite = BoutonDesactiveMus;
        }
    }

}
