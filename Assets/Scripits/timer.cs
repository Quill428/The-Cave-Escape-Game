using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class Timer: MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI TimerText;
    public float timer;

    private void Start()
    {
        RestartTimer();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        TimerText.text = Mathf.FloorToInt(timer).ToString() + "s";

    }
    public void RestartTimer()
    {
        timer = 0;
    }


}
