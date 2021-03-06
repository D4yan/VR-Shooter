using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public GameObject Player;
    // Select Healthbar Image
    public Image hpBar;

    // Changes the healthbar according to amount
    public void updateHealth(float amount)
    {
        hpBar.fillAmount = amount / 100f;
    }

    private void Update()
    {
        this.updateHealth(Player.GetComponent<SC_DamageReceiver>().playerHP);
    }

}
