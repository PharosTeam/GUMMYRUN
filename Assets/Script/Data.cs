using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public bool[] stage;
    public int totalStar, totalJeruk;
    public int[] star;
    public bool music, sfx, control, tutor1;
    
    public void saveData()
    {
        SaveLocal.saveData(this);
    }

    public void loadData()
    {
        PlayerData save = SaveLocal.loadData();

        stage = new bool[15];
        star = new int[15];
        totalStar = 0;

        for (int i = 0; i < save.star.Length - 1; i++)
        {
            star[i] = save.star[i];
            stage[i] = save.stage[i];            
        }
        totalStar = save.totalStar;

        music = save.music;
        sfx = save.sfx;
        control = save.control;
        tutor1 = save.tutor1;
        totalJeruk = save.totalJeruk;
    }
}
