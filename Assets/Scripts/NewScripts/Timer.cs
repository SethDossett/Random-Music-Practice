using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GeneralEventSO getNewNote;
    [SerializeField] GeneralEventSO tick;
    [SerializeField] GeneralEventSO startCountDown;
    [SerializeField] GeneralEventSO count;
    [SerializeField] GeneralEventSO startRandomizer;
    float timer = 0;
    [Range(0.15f, 3f)] public float timeTillNextTick = 1f;
    [SerializeField] Slider _slider;
    bool isCountDown;
    int currentTick;

    private void Start()
    {
        startCountDown.RaiseEvent();
        isCountDown = true;
    }
    private void Update()
    {
        timeTillNextTick = _slider.value;
        if (isCountDown)
        {
            timer += Time.deltaTime;

            if (timer >= timeTillNextTick)
            {
                timer = 0;
                CountDown();
            }
        }
        else
        {
            timer += Time.deltaTime;


            if (timer >= timeTillNextTick)
            {
                timer = 0;
                Tick();
            }
        }
        
    }
    void CountDown()
    {
        count.RaiseEvent();
        currentTick++;

        if (currentTick >= 4)
        {
            currentTick = 0;
            startRandomizer.RaiseEvent();
            isCountDown = false;
        }
    }
    void Tick()
    {
        tick.RaiseEvent();
        currentTick++;

        if (currentTick >= 4)
        {
            currentTick = 0;
            getNewNote.RaiseEvent();
        }
    }

    

}
