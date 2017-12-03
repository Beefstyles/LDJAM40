using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PauseMenuController : MonoBehaviour {

    public Slider powerSlider, brakesSlider, handlingSlider;
    public int MaxSliderValue = 10;

	void Start ()
    {
        powerSlider.value = MaxSliderValue / 3;
        brakesSlider.value = MaxSliderValue / 3;
        handlingSlider.value = MaxSliderValue / 3;

    }
	
	void Update ()
    {
        //StartCoroutine("DelaySlider");
    }

    IEnumerator DelaySlider()
    {
        yield return new WaitForSeconds(0.5F);
        powerSlider.value = MaxSliderValue - brakesSlider.value - handlingSlider.value;
        
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
    }
}
