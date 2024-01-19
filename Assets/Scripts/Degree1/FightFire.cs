using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFire : MonoBehaviour
{
    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRenderer;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        activeSpriteRenderer = spriteRenderer;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
