using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public TimeSpan currentTime;
    public float time;
    public int days;

    public Light sun;
    public Transform sunTransform;

    public float intensity;
    public Color fogDay = Color.grey;
    public Color fogNight = Color.black;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeTime();
    }

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;

        // Restarts the day after 24 hours have passed
        if (time > 86400)
        {
            days += 1;
            time = 0;
        }

        currentTime = TimeSpan.FromSeconds(time);
        string[] tempTime = currentTime.ToString().Split(':');

        Debug.Log(tempTime[0] + ":" + tempTime[1]);

        sunTransform.rotation = Quaternion.Euler(new Vector2((time - 21600) / (86400 * 360), 0));

        if (time < 43200)
        {
            intensity = 1 - ((43200 - time) / 43200);
        }
        else
        {

            intensity = 1 - (((43200 - time) / 43200) * (-1));
        }

        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);

        sun.intensity = intensity;
    }
}
