using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicInfoMusique : MonoBehaviour
{
   
   public InfoMusic im;
   [SerializeField]
   private List<GetLevelInfo> infoLevels;

    [SerializeField]
    private TextMesh nomGroupeDetail;
    private string nomDuGroupe;

    [SerializeField]
    private TextMesh styleMusiqueDetail;
    private string styleMusique;

    [SerializeField]
    private TextMesh originDetail;
    private string origin;

    [SerializeField]
    private TextMesh descriptionDetail;
    private string description;

    [SerializeField]
    private SpriteRenderer imageAlbum;

    public void GetSelectedTruc(int i)
    {
        if (im.setInfoMusique == false)
        { 
            nomDuGroupe = infoLevels[i].lvl.artistName;
            nomGroupeDetail.text = nomDuGroupe;

            styleMusique = infoLevels[i].lvl.genre;
            styleMusiqueDetail.text = styleMusique;

            origin = infoLevels[i].lvl.origine;
            originDetail.text = origin;

            description = infoLevels[i].lvl.description;
            descriptionDetail.text = description;

            imageAlbum.sprite = infoLevels[i].lvl.albumImage;

        }
       
    }

}
