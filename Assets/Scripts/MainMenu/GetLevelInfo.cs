using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevelInfo : MonoBehaviour
{
    public Level_SO lvl;

    [SerializeField]
    private TextMesh textNomMusique;
    [SerializeField]
    private TextMesh textArtisteMusique;

    [SerializeField]
    private SpriteRenderer imageAlbum;

    void Start()
    {
        textNomMusique.text = lvl.musicName;
        textArtisteMusique.text = lvl.albumName;
        imageAlbum.sprite = lvl.albumImage;


    }

}
