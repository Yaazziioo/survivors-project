using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    [SerializeField] Player playerHealth; // Reference to the Player script
    [SerializeField] Image fillGreenImage;     // Health bar fill image
    [SerializeField] Image fillRedImage;

    void Start()
    {

    }

    void Update()
    {
        fillGreenImage.fillAmount = (float)playerHealth.Health / 10;
        fillRedImage.fillAmount = 1-((float)playerHealth.Health / 10);
    }
}
