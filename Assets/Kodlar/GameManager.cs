using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Değişkenler
    public TMP_Text gerisayım;
    public TMP_Text başla;
    public TMP_Text bilimPTx;

    public GameObject bidon;
    public GameObject bilimP;

    int saniye = 4;

    public Roket roket;
    public UI uı;
    public Oyuncu oyuncu;

    public bool baslaB = false;
    int yukseklikSınır = 100;
    int bilimS;

    #endregion

    #region Start/Update
    private void Start()
    {
        Time.timeScale = 1;

        uı.ads.loop = false;

        gerisayım.gameObject.SetActive(false);
        başla.gameObject.SetActive(false);

        bilimS = PlayerPrefs.GetInt("bilimSınır");
        BilimPuanıGüncelle();
    }
    #endregion

    #region Metotlar
    public void Fırlat()
    {
        baslaB = true;
        InvokeRepeating("GeriSayım",0, 1f);
        InvokeRepeating("Spawner", 0, 10f);
        gerisayım.gameObject.SetActive(true);
    }
    public void Spawner()
    {
        if (roket.yukseklikDeger > yukseklikSınır)
        {
            float i = Random.Range(-2f, 2f); 

            Instantiate(bidon, new Vector3(i, yukseklikSınır + 100, 0), Quaternion.identity);
            Debug.Log("Yakıt bidonu spawn edildi. " + yukseklikSınır + 150 + "Metre");
            yukseklikSınır += 200;
            bilimS += 10;
        }

        float a = Random.Range(-1f, 1f);

        Instantiate(bilimP, new Vector3(a, (float)(roket.yukseklikDeger + (yukseklikSınır / 10)) + bilimS, 0), Quaternion.identity);

        bilimS += 2;

        Debug.Log("Bilim puanı spawn edildi. " + (float)(roket.yukseklikDeger + (yukseklikSınır / 10)) + bilimS + "Metre");
       
        PlayerPrefs.SetInt("bilimSınır", bilimS);
    }
    void GeriSayım()
    {
        saniye--;

        if (saniye > 0)
        {
            gerisayım.text = saniye.ToString();
            uı.ads.clip = uı.audioClips[0];
            uı.ads.Play();
        }

        if (saniye == 0)
        {
            gerisayım.gameObject.SetActive(false);
            başla.gameObject.SetActive(true);
            uı.ads.clip = uı.audioClips[1];
            uı.ads.Play();
        }

        if(saniye < 0)
        {
            uı.ads.Stop();
            başla.gameObject.SetActive(false);
            roket.Ateşlendi();
            CancelInvoke("GeriSayım");
        }
    }
    public void BilimPuanıGüncelle()
    {
        bilimPTx.text = oyuncu.bilimPuanları.ToString();
    }
    #endregion
}
