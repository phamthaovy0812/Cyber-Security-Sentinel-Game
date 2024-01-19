using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float Delay;
    private float Counter;

    // Start is called before the first frame update
    void Start()
    {
        Counter = Delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Counter > 0) Counter -= Time.deltaTime;
        else Destroy(gameObject);
    }
}
