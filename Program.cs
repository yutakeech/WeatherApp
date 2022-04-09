using System;
using WeatherApp.Classes;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Загружаю пользовательский API
            UserApiManager.ReadUserApiToLocalStorage();
            
            DataRepo.ReadListOfCitymonitoring();

            // Печатаю меню
            MainMenu.PrintMainMenu();
        }
    }
}
