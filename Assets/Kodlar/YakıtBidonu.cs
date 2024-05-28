using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakıtBidonu : MonoBehaviour
{
    public float yakıtM = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Roket")
        {
            other.GetComponent<Roket>().kalanYakıt += yakıtM;
            Destroy(gameObject);
        }
    }
}
