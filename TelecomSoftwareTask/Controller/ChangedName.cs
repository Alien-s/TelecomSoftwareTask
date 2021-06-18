using Persons;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TelecomSoftwareTask.Model;

namespace TelecomSoftwareTask.Controller
{
    /// <summary>
    /// Class for generation of all variants of changed names
    /// </summary>
    public class ChangedName
    {
        ObservableCollection<Name> listOfChangedNames = new ObservableCollection<Name>();

        //Declaration od dictionary for changes
        Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "AE", '\u00c4'.ToString() },
                { "OE", '\u00d6'.ToString() },
                { "UE", '\u00dc'.ToString() },
                { "SS", '\u00df'.ToString() }
            };


        /// <summary>
        /// THis method generate whole changed names
        /// </summary>
        /// <param name="usersList"></param> List from GetData
        public ObservableCollection<Name> ChangeWhole(ObservableCollection<User> usersList)
        {
            foreach (var item in usersList)
            {
                Name name = new Name();
                StringBuilder stringBuilder = new StringBuilder(item.UserName);

                name.IncommingName = item.UserName;

                //Add IncommingName to collection of the changed names
                SaveToCollection(name.ParticalChangedName, stringBuilder.ToString());

                //Make a whole changings
                foreach (var str in dict)
                {
                    stringBuilder.Replace(str.Key, str.Value);
                }

                //Assign of WholeChangedName and write to the collection of the changed names
                if (item.UserName != stringBuilder.ToString())
                {
                    name.WholeChangedName = stringBuilder.ToString();
                    SaveToCollection(name.ParticalChangedName, stringBuilder.ToString());
                }

                listOfChangedNames.Add(name);
            }

            return listOfChangedNames;
        }


        /// <summary>
        /// This method generate all possible variants
        /// </summary>
        public ObservableCollection<Name> ChangeParticle(ObservableCollection<Name> listOfCangedNames)
        {
            foreach (var item in listOfCangedNames)
            {
                GetAllEntriesWithSpecialSymbols(item.IncommingName, item.ParticalChangedName);
                GetAllOtherVariansWithSpecialSymbols(item.IncommingName, item.ParticalChangedName);
                GetAllMixSpecialSymbols(item.IncommingName, item.WholeChangedName, item.ParticalChangedName);
            }

            return listOfCangedNames;
        }


        /// <summary>
        /// This method change all changeable letters at Name for each letter
        /// </summary>
        /// <param name="particalChangedName"></param>Collection of names for each person
        private void GetAllEntriesWithSpecialSymbols(string incommingName, ObservableCollection<string> particalChangedName)
        {
            StringBuilder stringForCollection = new StringBuilder(incommingName);

            foreach (var str in dict)
            {
                // Change all curents letters to special symbols
                stringForCollection.Replace(str.Key, str.Value);
                SaveToCollection(particalChangedName, stringForCollection.ToString());

                //Return Incomming Name for next letter
                stringForCollection.Replace(str.Value, str.Key);
            }
        }


        /// <summary>
        /// This method generate all variants with each changeable letter
        /// </summary>
        /// <param name="particalChangedName"></param>Collection of names for each person
        private void GetAllOtherVariansWithSpecialSymbols(string incommingName, ObservableCollection<string> particalChangedName)
        {
            StringBuilder stringForCollection = new StringBuilder(incommingName);
            StringBuilder stringForConstructing = new StringBuilder(incommingName);

            foreach (var str in dict)
            {
                //Define index for method GetAllMixSpecialSymbols
                if (stringForCollection.ToString().IndexOf(str.Value) >= 0) continue;

                //Define index of the first enty
                int index = stringForCollection.ToString().IndexOf(str.Key);

                // Define variants
                if (index >= 0)
                {
                    while (index >= 0)
                    {
                        //Change a first enty to special symbol
                        stringForCollection.Remove(index, 2).Insert(index, str.Value);

                        //Write Variant to List of Names
                        SaveToCollection(particalChangedName, stringForCollection.ToString());

                        //Inversion
                        stringForCollection.Replace(str.Value, "**").Replace(str.Key, str.Value).Replace("**", str.Key);
                        SaveToCollection(particalChangedName, stringForCollection.ToString());

                        stringForCollection.Replace(str.Value, str.Key);

                        //Define a next Index
                        stringForConstructing.Remove(index, 2).Insert(index, "**");
                        index = stringForConstructing.ToString().IndexOf(str.Key);
                    }
                }
            }
        }


        /// <summary>
        /// This method generate variants between changeables letters
        /// </summary>
        /// <param name="particalChangedName"></param>Collection of names for each person
        private void GetAllMixSpecialSymbols(string incommingName, string wholeChangedName, ObservableCollection<string> particalChangedName)
        {
            //Temporary list for work with variants
            List<string> tempList = new List<string>(particalChangedName);

            foreach (var item in tempList)
            {
                if (item == incommingName || item == wholeChangedName) continue;
                GetAllOtherVariansWithSpecialSymbols(item, particalChangedName);
            }
        }


        /// <summary>
        /// Save a new variant to the name collection
        /// </summary>
        /// <param name="particalChangedName"></param>Collection of names for each person
        private void SaveToCollection(ObservableCollection<string> particalChangedName, string stringForCollection)
        {
            //Write Variant to List of Names
            if (!particalChangedName.Any(p => p.Contains(stringForCollection)))
            {
                particalChangedName.Add(stringForCollection);
            }
        }
    }
}
