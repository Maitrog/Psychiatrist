using UnityEngine;

[RequireComponent(typeof(PatientVictim))]
public abstract class PatientVictimBehaviour : MonoBehaviour
{
    public PatientVictim patientVictim { get; private set; }
    public float duration;

    private void Awake()
    {
        patientVictim = GetComponent<PatientVictim>();
        enabled = false;
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
