using UnityEngine;


public class DirectionController : MonoBehaviour
{
    [SerializeField] private float directionChangeThreshold = 0.15f;
    enum Directions
    {
        center, left, right
    }
    Directions direction = Directions.center;
    Directions lastSentDirection = Directions.center;
    void FixedUpdate()
    {
        if(Input.acceleration.x > directionChangeThreshold)
        {
            direction = Directions.right;
        }
        else if(Input.acceleration.x < -directionChangeThreshold)
        {
            direction = Directions.left;
        }
        else
        {
            direction=Directions.center;
        }
        if(lastSentDirection != direction)
        {
            lastSentDirection = direction;
            RequestManager.Instance.SendRequest(direction.ToString());
        }
    }

}
