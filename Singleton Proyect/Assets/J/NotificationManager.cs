using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance { get; private set; }

    AndroidNotificationChannel notifChannel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif",
            Name = "Recordatorios Notificaciones",
            Description = "Canal de recordatorios",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);

        DisplayNotif("Queres jugar?", "No jugas hace 1 Hora", DateTime.Now.AddHours(1));
    }

    public int DisplayNotif(string title, string text, DateTime fireTime)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.SmallIcon = "icon_reminder";
        notification.LargeIcon = "icon_reminder";
        notification.FireTime = fireTime;

        return AndroidNotificationCenter.SendNotification(notification, notifChannel.Id);
    }

    public void CancelNotif(int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }
}