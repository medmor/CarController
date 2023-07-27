using UnityEngine;

[CreateAssetMenu(fileName = "ControllerDefinition", menuName = "ScriptableObjects/ControllerDefinition", order = 1)]
public class Runcontroller2SO : ScriptableObject
{
    public enum Directions { forward, backward }

    public Directions Direction;

    public float Speed;
    public bool SirenOn = false;

    public void ToggleDirection()
    {
        if(Direction == Directions.forward)
        {
            Direction = Directions.backward;
        }
        else if(Direction == Directions.backward)
        {
            Direction = Directions.forward;
        }
    }
}

