using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float interval = 0.25f;
    private System.Action tickCallback;
    private float startTime;
    private bool started;

    public void StartTimer(System.Action tickCallback)
    {
        started = true;
        startTime = Time.time;
        this.tickCallback = tickCallback;
    }

    public void StopTimer()
    {
        started = false;
        tickCallback = null;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (started)
        {
            if (Time.time - startTime >= interval)
            {
                startTime = Time.time;
                tickCallback();
            }
        }
    }
}
