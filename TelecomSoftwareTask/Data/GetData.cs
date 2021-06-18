using Persons;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using TelecomSoftwareTask.Controller;

namespace TelecomSoftwareTask.Data
{
    /// <summary>
    /// Class for receiving of the data to programm
    /// </summary>
    public static class GetData
    {
        /// <summary>
        /// Mothod for reading of file
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<User>> GetIncommingsListOfUsers()
        {
            ObservableCollection<User> listOfUsers = new ObservableCollection<User>();
            Error error;

            try
            {
                //Path to the file
                var fileLocation = AppDomain.CurrentDomain.BaseDirectory;
                var path = System.IO.Path.Combine(fileLocation, @"Data\IncommingsData\PhoneBook_UTF8.txt");

                //Reading of the all strings and adding to the ObservableCollection
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        User user = new User();
                        user.UserName = await streamReader.ReadLineAsync();
                        listOfUsers.Add(user);
                    }
                }
            }
            catch (Exception)
            {
                error = new Error();
                error.DataError();
            }

            return listOfUsers;
        }
    }
}
