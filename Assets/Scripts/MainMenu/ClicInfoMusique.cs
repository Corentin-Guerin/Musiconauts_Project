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
    private TextMesh nomMusiqueDetail;
    private string nomMusique;

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

            nomMusique = infoLevels[i].lvl.genre;
            nomMusiqueDetail.text = nomMusique;

            origin = infoLevels[i].lvl.albumName;
            originDetail.text = origin;

            description = infoLevels[i].lvl.description;
            descriptionDetail.text = description;

            imageAlbum.sprite = infoLevels[i].lvl.albumImage;

        }
       
    }

}
