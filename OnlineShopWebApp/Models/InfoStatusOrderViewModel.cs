using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class InfoStatusOrderViewModel
    {
        public Statuses StatusOrder { get; set; }
        public DateTime Data { get; set; }
        public enum Statuses
        {
            Created=1,
            InProcessing=2,
            Delivering=3,
            OnPost=4,
            Done=5,
            Canceled=6
        }
        public InfoStatusOrderViewModel(DateTime dateTime)
        {
            StatusOrder = Statuses.Created;
            Data = dateTime;
        }
        public string GetStatus(Statuses StatusOrder)
        {
            switch (StatusOrder)
            {
                case Statuses.Created:
                    return "Создан";
                case Statuses.InProcessing:
                    return "В работе";
                case Statuses.Delivering:
                    return "В пути";
                case Statuses.OnPost:
                    return "Готов к выдаче";
                case Statuses.Done:
                    return "Выполнен";
                case Statuses.Canceled:
                    return "Отменен";
                default:
                    return "Ошибка";
            }
        }
        public static List<string> GetAllStatuses()
        {
            var result = new List<string>() { "Создан", "В работе", "В пути", "Готов к выдаче", "Выполнен", "Отменен" };
            return result;
        }
    }
}