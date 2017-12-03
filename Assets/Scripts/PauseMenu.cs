using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Slider powerSlider, brakesSlider, handlingSlider;
    public int MaxSliderValue = 10;

    public GameObject PauseMenuObjects;


    GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        powerSlider.value = MaxSliderValue / 3;
        brakesSlider.value = MaxSliderValue / 3;
        handlingSlider.value = MaxSliderValue / 3;
        

        gameController.PowerMultiplication = powerSlider.value;
        gameController.BrakesMultiplication = brakesSlider.value;
        gameController.HandlingMultiplication = handlingSlider.value;
    }

    void Update()
    {
        //StartCoroutine("DelaySlider");
    }

    public void UpdateOtherSliders(string sliderName)
    {
        switch (sliderName)
        {
            case ("PowerSlider"):
                brakesSlider.value = MaxSliderValue - powerSlider.value - handlingSlider.value;
                handlingSlider.value = MaxSliderValue - powerSlider.value - brakesSlider.value;
                break;
            case ("BrakesSlider"):
                powerSlider.value = MaxSliderValue - brakesSlider.value - handlingSlider.value;
                handlingSlider.value = MaxSliderValue - brakesSlider.value - powerSlider.value;
                break;
            case ("HandlingSlider"):
                brakesSlider.value = MaxSliderValue - handlingSlider.value - powerSlider.value;
                powerSlider.value = MaxSliderValue - handlingSlider.value - brakesSlider.value;
                break;

        }

        gameController.PowerMultiplication = powerSlider.value;
        gameController.BrakesMultiplication = brakesSlider.value;
        gameController.HandlingMultiplication = handlingSlider.value;
    }

    public void TogglePauseMenu()
    {
        if (PauseMenuObjects.activeSelf)
        {
            PauseMenuObjects.SetActive(false);
        }
        else
        {
            PauseMenuObjects.SetActive(true);
        }
    }

    public void RestartLap()
    {
        gameController.StartLap();
    }
}
