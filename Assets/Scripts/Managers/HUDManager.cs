using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Image healthbar;
    public Image energybar;
    public Text healthText;
    public Text energyText;

    public void setPlayerHealth(float health, float maxHealth) {
        healthbar.fillAmount = health / maxHealth;
        healthText.text = Mathf.Round(health) + " / " + maxHealth;
    }

    public void setPlayerEnergy(float energy, float maxEnergy) {
        energybar.fillAmount = energy / maxEnergy;
        energyText.text = Mathf.Round(energy) + " / " + maxEnergy;
    }
}
