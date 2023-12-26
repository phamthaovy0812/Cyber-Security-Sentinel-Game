using UnityEngine;

[RequireComponent(typeof(GhostPacman))]
public abstract class GhostPacmanBehavior : MonoBehaviour
{
    public GhostPacman ghostPacman { get; private set; }
    public float duration;

    private void Awake()
    {
        ghostPacman = GetComponent<GhostPacman>();
    }

    public void Enable()
    {
        Enable(duration);
    }

    public virtual void Enable(float duration)
    {
        enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        enabled = false;

        CancelInvoke();
    }

}
