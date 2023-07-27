using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunController2 : MonoBehaviour
{
    [SerializeField] Runcontroller2SO runcontroller2SO;
    [SerializeField] List<Image> geersImages;
    [SerializeField] Image accelerationPedal;
    [SerializeField] TextMeshProUGUI directionText;

    [SerializeField] List<Sprite> accelerationPedals;

    [SerializeField] Image sirenBack;
    [SerializeField] Image sirenFor;
    [SerializeField] Sprite sirenOn;
    [SerializeField] Sprite sirenOff;

    public void OnPedalDown()
    {
        RequestManager.Instance.SendRequest(runcontroller2SO.Direction.ToString());
        accelerationPedal.sprite = accelerationPedals[1];
    }
    public void OnPedalUp()
    {
        RequestManager.Instance.SendRequest("stop");
        accelerationPedal.sprite = accelerationPedals[0];
    }

    public void OnGeerClick(int index)
    {
        var speed = index * 10 + 60;
        RequestManager.Instance.SendRequest("speed/" + speed);
        foreach (var image in geersImages)
        {
            image.color = Color.white;
        }
        geersImages[index].color = Color.green;
    }

    public void OnDirectionChangeClick()
    {
        runcontroller2SO.ToggleDirection();
        if (runcontroller2SO.Direction == Runcontroller2SO.Directions.backward)
        {
            directionText.text = "F";
        }
        else
        {
            directionText.text = "B";
        }
    }

    public void OnSirenToggle()
    {
        RequestManager.Instance.SendRequest("siren");
        if (runcontroller2SO.SirenOn)
        {
            runcontroller2SO.SirenOn = false;
            sirenBack.color = Color.green;
            sirenFor.sprite = sirenOn;
        }
        else
        {
            runcontroller2SO.SirenOn = true;
            sirenBack.color = Color.red;
            sirenFor.sprite = sirenOff;
        }
    }

}

