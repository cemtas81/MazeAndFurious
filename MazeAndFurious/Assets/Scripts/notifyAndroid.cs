/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.SimpleAndroidNotifications;

public class notifyAndroid : MonoBehaviour
{
    private string title = "Maze Runner";

    private string content = "Hadi Simdi Teste Basla";

    private void Start()
    {
#if UNITY_IOS
        UnityEngine.iOS.NotificationServices.RegisterForNotifications(UnityEngine.iOS.NotificationType.Alert | UnityEngine.iOS.NotificationType.Badge | UnityEngine.iOS.NotificationType.Sound);
#endif
    }

    private void OnApplicationPause(bool pause)
    {
#if UNITY_ANDROID
        NotificationManager.CancelAll();

        if (pause)
        {
            DateTime timeToNotify = DateTime.Now.AddMinutes(1440);
            TimeSpan time = timeToNotify - DateTime.Now;
            NotificationManager.SendWithAppIcon(time, title, content, Color.black, NotificationIcon.Bell);
        }

#elif UNITY_IOS
        UnityEngine.iOS.NotificationServices.ClearLocalNotifications();
        UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();

        if(pause)
        {
            DateTime dateTonotify = DateTime.Now.AddMinutes(1440);

            UnityEngine.iOS.LocalNotification notif = new UnityEngine.iOS.LocalNotification();
            notif.fireDate = dateTonotify;
            notif.alertTitle = title;
            notif.alertBody = content;

            notif.repeatInterval = UnityEngine.iOS.CalendarUnit.Day;

            UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);
        }
#endif
    }
}
*/