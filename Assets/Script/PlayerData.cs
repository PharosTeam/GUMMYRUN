using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool[] stage;
    public int totalStar;
    public int[] star;
    public bool music, sfx, control;

    public PlayerData (Data player)
    {
        stage = new bool[15];
        star = new int[15];
        for (int i = 0; i < player.star.Length - 1; i++)
        {
            star[i] = player.star[i];
            stage[i] = player.stage[i];
            totalStar += player.star[i];
        }
        music = player.music;
        sfx = player.sfx;
        control = player.control;
    }
}