using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilimPuanı : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Roket")
        {
            FindObjectOfType<Oyuncu>().BilimPuanıEkle(1);
            FindObjectOfType<GameManager>().BilimPuanıGüncelle();
            Destroy(gameObject);
        }
    }
}
