using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

using static System.Console;

namespace WeatherApp.Classes
{
    /// <summary>
    /// Класс описывает возможность чтения и записи пользовательского API
    /// </summary>
    public static class UserApiManager
    {
        /// <summary>
        /// Список хранит APIKey
        /// </summary>
        /// <typeparam name="UserApi"></typeparam>
        /// <returns></returns>
        public static ObservableCollection<UserApi> userApiList = new ObservableCollection<UserApi>();
        
        /// <summary>
        /// Метод реализует возможность записи пользользовательского
        /// APIKey на диск
        /// </summary>
        /// <param name="formalUserApi"></param>
        public static void WriteUserApiToLocalStorage(string formalUserApi)
        {
            UserApi userApiProp = new UserApi
            {
                UserApiProperty = formalUserApi
            };

            userApiList.Add(userApiProp);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<UserApi>));

            using (StreamWriter sw = new StreamWriter("UserApi.xml"))
            {
                xmlSerializer.Serialize(sw, userApiList);
            }
        }

        /// <summary>
        /// Метод реализует возможность восстановления списка APIKey в памяти
        /// </summary>
        public static void ReadUserApiToLocalStorage()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<UserApi>));

            try
            {
                using (StreamReader sr = new StreamReader("UserApi.xml"))
                {
                    userApiList = xmlSerializer.Deserialize(sr) as ObservableCollection<UserApi>;
                }
            }

            catch(Exception ex)
            {
                Write("API ключ не найден. \n" +
                      "Добавьте его через пункт меню 1 для пользования прилодением. \n");
            }
        }
     }
}