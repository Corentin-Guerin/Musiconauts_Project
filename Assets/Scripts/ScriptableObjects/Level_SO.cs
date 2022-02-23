using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelTemplate", menuName = "Level", order = 0)]
public class Level_SO : ScriptableObject
{
    public int levelNumber;
    public AudioClip music;
    [TextArea(1, 3)]
    public string artistName, musicName, albumName, genre, origine;
    public List<Color> mainColors;
    public int difficultyMin, difficultyMax;
    public float enjaillementDecrement;
    public Sprite albumImage, sceneSprite, artistsSprite;

    [TextArea(10, 25)]
    public string description;
}