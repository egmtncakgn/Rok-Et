using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    public int bilimPuanları;

    private void Awake()
    {
        İlkKurulum();

        bilimPuanları = PlayerPrefs.GetInt("bilimPuanları");
    }

    void İlkKurulum()
    {
        if (!PlayerPrefs.HasKey("bilimPuanları"))
            PlayerPrefs.SetInt("bilimPuanları", 0);

        if (!PlayerPrefs.HasKey("bilimSınır"))
            PlayerPrefs.SetInt("bilimSınır", 5);
    }

    public void BilimPuanıEkle(int a)
    {
        PlayerPrefs.SetInt("bilimPuanları", bilimPuanları + a);
        bilimPuanları = PlayerPrefs.GetInt("bilimPuanları");
    }
    public bool BilimPuanıEksilt(int a)
    {
        if (bilimPuanları > a)
            PlayerPrefs.SetInt("bilimPuanları", bilimPuanları - a);
        else
            return false;

        bilimPuanları = PlayerPrefs.GetInt("bilimPuanları");

        return true;
    }
}
