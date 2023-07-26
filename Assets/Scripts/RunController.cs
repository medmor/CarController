using UnityEngine;
using UnityEngine.UI;

public class RunController : MonoBehaviour
{
    enum Directions { forward, backward }
    [SerializeField] Directions direction;
    [SerializeField] private Image speedIndicator = default;
    [SerializeField] private float speedDiffrenceThreshold = 10;
    [SerializeField] private float speedIncrement = 5;
    [SerializeField] private float minSpeed = 50;

    private float speed = 0;
    private float lastSpeed = 0;
    private bool isPressed = false;

    void Update()
    {
        if (isPressed)
        {
            if (speed < minSpeed)
            {
                speed = minSpeed;
            }
            speed += speedIncrement * Time.deltaTime;
            if (speed > 100)
            {
                speed = 100;
            }
            UpdateSpeedIndicator();
            if (Mathf.Abs(speed - lastSpeed) > speedDiffrenceThreshold)
            {
                lastSpeed = speed;
                RequestManager.Instance.SendRequest(direction + "/" + (int)speed);
            }

        }
        else if (speed > 0)
        {
            speed = 0;
            lastSpeed = 0;
            UpdateSpeedIndicator();
            RequestManager.Instance.SendRequest("stop"); UpdateSpeedIndicator();
        }

    }
    public void OnPointerDown()
    {
        isPressed = true;
    }
    public void OnPointerUp()
    {
        isPressed = false;
    }
    private void UpdateSpeedIndicator()
    {
        speedIndicator.fillAmount = speed * .01f;
    }
}

