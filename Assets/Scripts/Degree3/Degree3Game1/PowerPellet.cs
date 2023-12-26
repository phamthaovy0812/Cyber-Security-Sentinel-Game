using UnityEngine;

public class PowerPellet : Pellet
{
    public float duration = 8f;

    protected override void Eat()
    {
        HaveStar.Instance.CallQuestion();
        GameManagerDegree3game1.Instance.PowerPelletEaten(this);
    }

}
