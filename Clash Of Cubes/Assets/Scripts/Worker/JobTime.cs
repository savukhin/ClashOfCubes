using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class JobTime
{
    public int weeks;
    public int days;
    public int hours;
    public int minutes;
    public int seconds;
    public int milliseconds;
    
    public float ToFloat() {
        float result = milliseconds / 1000f;
        result += seconds;
        result += minutes * 60;
        result += hours * 60 * 60;
        result += days * 60 * 60 * 24;
        result += weeks * 60 * 60 * 24 * 7;
        return result;
    }

    public static JobTime FromFloat(float seconds) {
        float ms = seconds * 1000;
        JobTime time = new JobTime(); 
        time.days = (int)TimeSpan.FromMilliseconds(ms).TotalDays;
        time.hours = (int)TimeSpan.FromMilliseconds(ms).TotalHours % 24;
        time.minutes = (int)TimeSpan.FromMilliseconds(ms).TotalMinutes % 60;
        time.seconds = (int)TimeSpan.FromMilliseconds(ms).TotalSeconds % 60;
        time.milliseconds = (int)ms % 1000;
        time.weeks = time.days / 7;
        return time;
    }

    public override string ToString()
    {
        string result = "";
        result += "weeks: " + weeks;
        result += " days: " + days;
        result += " hours: " + hours;
        result += " minutes: " + minutes;
        result += " seconds: " + seconds;
        result += " millieseconds: " + milliseconds;
        return result;
    }

    public static JobTime operator- (JobTime jobTime1, JobTime jobTime2) {
        float time1 = jobTime1.ToFloat();
        float time2 = jobTime1.ToFloat();
        return JobTime.FromFloat(time1 - time2);
    }

    public static JobTime operator+ (JobTime jobTime1, float time2) {
        float time1 = jobTime1.ToFloat();
        return JobTime.FromFloat(time1 + time2);
    }
}
