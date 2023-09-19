using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectOrbs : MonoBehaviour
{
    public TextMeshProUGUI orbText;
 int Orb = 0;

private void OnTriggerEnter(Collider other)
{
    if(other.transform.tag == "Orb")
    {
        Orb++;
        orbText.text = "Orb: " + Orb.ToString();
        Destroy(other.gameObject);
    }
}
}
