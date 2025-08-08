using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider healthSlider;
    public Slider energySlider;
    public Text energyText;

    public void SetHUD(Unit unit)
    {
        healthSlider.maxValue = unit.maxHealth;
        healthSlider.value = unit.currHealth;

        if (energySlider != null)
        {
            energySlider.maxValue = unit.maxEnergy;
            energySlider.value = unit.currEnergy;

            energyText.text = unit.currEnergy.ToString() + "/" + unit.maxEnergy.ToString();
        }
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void SetEnergy(int energy)
    {
        if (energySlider != null)
        {
            energySlider.value = energy;

        }
    }
}
