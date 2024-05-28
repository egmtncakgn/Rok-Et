using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roket : MonoBehaviour
{
    #region Değişkenler
    public GameObject nozzle;

    public GameObject yükseklikTx,
                      yükseklikSTx,
                      yakıtGösterge;

    public Slider yakıtBar;
    public UI uı;
    public AudioSource motorSesi;
    public Rigidbody rb;

    public float motorGücü = 9.9f;

    public float maxYakıt, kalanYakıt, motorTüketimi = 0f;

    public bool ateslendi = false;
    bool levelBasladı;

    public float acı;

    public double yukseklikDeger;
    #endregion

    #region Start/Update
    private void Start()
    {
        nozzle.SetActive(false);
        yükseklikTx.SetActive(false);
        yükseklikSTx.SetActive(false);

        levelBasladı = false;

        kalanYakıt = maxYakıt;
        yakıtBar.maxValue = maxYakıt;
        yakıtBar.value = maxYakıt;

        yakıtGösterge.GetComponent<TMP_Text>().text = Math.Round(kalanYakıt, 1) + "/" + maxYakıt + " Litre";
    }
    private void FixedUpdate()
    {
        if (ateslendi)
        {
            rb.AddForce(Vector3.up * motorGücü);
            HareketEt();
        }
        yukseklikDeger = Math.Round(transform.position.y, 1);

        if(yukseklikDeger > 1000)
            yükseklikSTx.GetComponent<TMP_Text>().text = (yukseklikDeger / 1000).ToString() + " KM";
        else
            yükseklikSTx.GetComponent<TMP_Text>().text = yukseklikDeger.ToString() + " MT";

        if (!ateslendi && levelBasladı && rb.velocity.y < 0.1f)
            YakıtBitti();
    }

    #endregion

    #region Metodlar
    public void Ateşlendi()
    {
        nozzle.SetActive(true);
        motorSesi.loop = true;
        motorSesi.Play();
        ateslendi = true;

        levelBasladı = true;

        yükseklikTx.SetActive(true);
        yükseklikSTx.SetActive(true);

        InvokeRepeating("YakıtHesapla", 0f, 0.3f);
    }
    public void YakıtHesapla()
    {
        if(kalanYakıt > 0)
            kalanYakıt -= motorTüketimi;

        yakıtGösterge.GetComponent<TMP_Text>().text = Math.Round(kalanYakıt, 1) + "/" + maxYakıt + " Litre";
        yakıtBar.value = kalanYakıt;

        if (kalanYakıt <= 0)
        {
            kalanYakıt = 0;
            ateslendi = false;
            nozzle.SetActive(false);
            motorSesi.Stop();
        }
    }
    public void YakıtBitti()
    {
        Time.timeScale = 0;
        uı.YakıtBitti();
    }
    public void HareketEt()
    {
        acı = Input.acceleration.x;

        transform.Translate(acı * Time.deltaTime * 5, 0, 0);


        if (transform.position.x <= -2.5f)
            transform.position =new Vector3(-2.5f, transform.position.y, transform.position.z);

        if(transform.position.x >= 2.5f)
            transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
    }
    #endregion
}
