using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCount : MonoBehaviour
{
 public TextMeshProUGUI counterText;
 int kills;

void Update()
{
    ShowKills();
}

private void ShowKills()
{
    counterText.text = kills.ToString();
}
 public void AddKill()
 {
    kills++;
 }
}
