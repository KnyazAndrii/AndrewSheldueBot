using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace AndrewSheldueBot
{
    class Program
    {
        public static string TodaySheldue;
        public static string TomorrowSheldue;
        public static string up_Monday = "Верхній понеділок:\n08:30 - Фізкультура(П)\n10:00 - Хмарні обч.та техн.блокчейну(П)\n11:30 - Економетрика(Лб)";
        public static string up_Tuesday = "Верхній вівторок:\n08:30 - Фін. мод. в бізнесі(Лб)\n10:00 - Право(П)\n11:30 - Системи моніторингу(Лб)\n13:00 - Право(Л)";
        public static string up_Wednesday = "Верхня середа:\n10:00 - Технол. проект та адмін. БД і СД(Л)\n13:00 - Бух. облік(П)";
        public static string up_Thursday = "Верхній четвер:\nПар нема!\nДіставай пиво!!!!!";
        public static string up_Friday = "Верхня п'ятниця:\n13:00 - Іноземна мова(П)\n14:30 - Економетрика(П)";
        public static string bot_Monday = "Нижній понеділок:\n08:30 - Фізкультура(П)\n11:30 - Системи моніторингу(П)";
        public static string bot_Tuesday = "Нижній вівторок:\n08:30 - Економетрика(Л)\n10:00 - Бух. облік(Л)\n11:30 - Економетрика(Лб)\n13:00 - Системи моніторингу(Л)";
        public static string bot_Wednesday = "Нижня середа:\n08:30 - Хмарні обч. та техн. блокчейну(Лб)\n10:00 - Фін. мод. в бізнесі(Л)\n11:30 - Хмарні обч. та техн. блокчейну(Л)";
        public static string bot_Thursday = "Нижній четвер:\n08:30 - Технол. проект та адмін. БД і СД(Лб)\n10:00 - Технол. проект та адмін. БД і СД(П)\n11:30 - Право(П)";
        public static string bot_Friday = "Нижня п'ятниця:\n10:00 - Фін. мод. в бізнесі(П)\n11:30 - Бух. облік(П)\n13:00 - Іноземна мова(П)";
        private static string token { get; set; } = "5164753090:AAEhu5uwONDFtANIqwGzEbWVEMuh9_5cDyc";
        private static TelegramBotClient client;
        public static int typeOfWeek = 1;
        static void Main(string[] args)
        {
            if(DateTime.Now.DayOfWeek.ToString() == "Sunday")
            {
                typeOfWeek += 1;
            }
            if (typeOfWeek % 2 == 1)
            {
                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Monday":
                        TodaySheldue = up_Monday;
                        TomorrowSheldue = up_Tuesday;
                        break;
                    case "Tuesday":
                        TodaySheldue = up_Tuesday;
                        TomorrowSheldue = up_Wednesday;
                        break;
                    case "Wednesday":
                        TodaySheldue = up_Wednesday;
                        TomorrowSheldue = up_Thursday;
                        break;
                    case "Thursday":
                        TodaySheldue = up_Thursday;
                        TomorrowSheldue = up_Friday;
                        break;
                    case "Friday":
                        TodaySheldue = up_Friday;
                        TomorrowSheldue = "Завтра вихідний!";
                        break;
                    case "Saturday":
                        TodaySheldue = "Сьогодні вихідний!";
                        TomorrowSheldue = "Завтра вихідний!";
                        break;
                    case "Sunday":
                        TodaySheldue = "Сьогодні вихідний!";
                        TomorrowSheldue = bot_Monday;
                        break;
                }
            }
            else
            {
                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Monday":
                        TodaySheldue = bot_Monday;
                        TomorrowSheldue = bot_Tuesday;
                        break;
                    case "Tuesday":
                        TodaySheldue = bot_Tuesday;
                        TomorrowSheldue = bot_Wednesday;
                        break;
                    case "Wednesday":
                        TodaySheldue = bot_Wednesday;
                        TomorrowSheldue = bot_Thursday;
                        break;
                    case "Thursday":
                        TodaySheldue = bot_Thursday;
                        TomorrowSheldue = bot_Friday;
                        break;
                    case "Friday":
                        TodaySheldue = bot_Friday;
                        TomorrowSheldue = "Завтра вихідний!";
                        break;
                    case "Saturday":
                        TodaySheldue = "Сьогодні вихідний!";
                        TomorrowSheldue = "Завтра вихідний!";
                        break;
                    case "Sunday":
                        TodaySheldue = "Сьогодні вихідний!";
                        TomorrowSheldue = up_Monday;
                        break;
                }
            }
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
            
        }
        
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        { 
            var msg = e.Message;
            if (msg.Text != null)
            {
                switch (msg.Text)
                {
                    case "Розклад на сьогодні":
                        await client.SendTextMessageAsync(msg.Chat.Id, TodaySheldue);
                        break;
                    case "Розклад на завтра":
                        await client.SendTextMessageAsync(msg.Chat.Id, TomorrowSheldue);
                        break;
                    case "Верхній тиждень":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Понеділок:\n08:30 - Фізкультура(П)\n10:00 - Хмарні обч. та техн. блокчейну(П)\n11:30 - Економетрика(Лб)\n\nВівторок:\n08:30 - Фін. мод. в бізнесі(Лб)\n10:00 - Право(П)\n11:30 - Системи моніторингу(Лб)\n13:00 - Право(Л)\n\nСереда:\n10:00 - Технол. проект та адмін. БД і СД(Л)\n13:00 - Бух. облік(П)\n\nЧетвер:\nПар нема!\nДіставай пиво!!!!!\n\nП'ятниця:\n13:00 - Іноземна мова(П)\n14:30 - Економетрика(П)", replyMarkup: GetButtons());
                        break;
                    case "Нижній тиждень":
                        await client.SendTextMessageAsync(msg.Chat.Id, "Понеділок:\n08:30 - Фізкультура(П)\n11:30 - Системи моніторингу(П)\n\nВівторок:\n08:30 - Економетрика(Л)\n10:00 - Бух. облік(Л)\n11:30 - Економетрика(Лб)\n13:00 - Системи моніторингу(Л)\n\nСереда:\n08:30 - Хмарні обч. та техн. блокчейну(Лб)\n10:00 - Фін. мод. в бізнесі(Л)\n11:30 - Хмарні обч. та техн. блокчейну(Л)\n\nЧетвер:\n08:30 - Технол. проект та адмін. БД і СД(Лб)\n10:00 - Технол. проект та адмін. БД і СД(П)\n11:30 - Право(П)\n\nП'ятниця:\n10:00 - Фін. мод. в бізнесі(П)\n11:30 - Бух. облік(П)\n13:00 - Іноземна мова(П)", replyMarkup: GetButtons());
                        break;
                }
            }

        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Розклад на сьогодні"}, new KeyboardButton { Text = "Розклад на завтра"} },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Верхній тиждень"}, new KeyboardButton { Text = "Нижній тиждень"} }
                }
            };
        }
        
    }
}
