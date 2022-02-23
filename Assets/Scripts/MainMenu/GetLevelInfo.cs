using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevelInfo : MonoBehaviour
{
    public Level_SO lvl;

    [SerializeField]
    private TextMesh textNomMusique;
    [SerializeField]
    private TextMesh textStyleMusique;

    [SerializeField]
    private SpriteRenderer imageAlbum;

    void Start()
    {
        textNomMusique.text = lvl.musicName;
        textStyleMusique.text = lvl.genre;
        imageAlbum.sprite = lvl.albumImage;


    }

}
