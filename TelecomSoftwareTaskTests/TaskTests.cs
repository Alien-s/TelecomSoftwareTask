using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persons;
using System.Collections.ObjectModel;
using TelecomSoftwareTask.Controller;
using TelecomSoftwareTask.Model;

namespace TelecomSoftwareTaskTests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void ChangeWholeNameTestWithChangings()
        {
            //Arrange
            ObservableCollection<User> users = new ObservableCollection<User> { new User { UserName = "AEOEUESS" } };

            ObservableCollection<Name> expected = new ObservableCollection<Name> { new Name { IncommingName = "AEOEUESS", WholeChangedName = "ÄÖÜß", ParticalChangedName = { "AEOEUESS", "ÄÖÜß" } } };

            ChangedName changedName = new ChangedName();

            //Act
            ObservableCollection<Name> actual = changedName.ChangeWhole(users);

            //Assert
            expected.Equals(actual);
        }


        [TestMethod]
        public void ChangeWholeNameTestWithoutChangings()
        {
            //Arrange
            ObservableCollection<User> users = new ObservableCollection<User> { new User { UserName = "BERGER" } };

            ObservableCollection<Name> expected = new ObservableCollection<Name> { new Name { IncommingName = "BERGER", ParticalChangedName = { "BERGER" } } };

            ChangedName changedName = new ChangedName();

            //Act
            ObservableCollection<Name> actual = changedName.ChangeWhole(users);

            //Assert
            expected.Equals(actual);
        }


        [TestMethod]
        public void ChangeParticleNameTestWithChangings()
        {
            //Arrange
            ObservableCollection<Name> listOfCangedNames = new ObservableCollection<Name> { new Name { IncommingName = "AEOEUESS", WholeChangedName = "ÄÖÜß", ParticalChangedName = { "AEOEUESS", "ÄÖÜß" } } };

            ObservableCollection<Name> expected = new ObservableCollection<Name> { new Name { IncommingName = "AEOEUESS", WholeChangedName = "ÄÖÜß", ParticalChangedName = { "AEOEUESS", "ÄÖÜß", "ÄOEUESS", "AEÖUESS", "AEOEÜSS", "AEOEUEß", "ÄÖUESS", "ÄOEÜSS", "ÄOEUEß", "AEÖÜSS", "AEÖUEß", "AEOEÜß" } } };

            ChangedName changedName = new ChangedName();

            //Act
            ObservableCollection<Name> actual = changedName.ChangeParticle(listOfCangedNames);

            //Assert
            expected.Equals(actual);
        }


        [TestMethod]
        public void ChangeParticleNameTestWithoutChangings()
        {
            //Arrange
            ObservableCollection<Name> listOfCangedNames = new ObservableCollection<Name> { new Name { IncommingName = "BERGER", ParticalChangedName = { "BERGER" } } };

            ObservableCollection<Name> expected = new ObservableCollection<Name> { new Name { IncommingName = "BERGER", ParticalChangedName = { "BERGER" } } };

            ChangedName changedName = new ChangedName();

            //Act
            ObservableCollection<Name> actual = changedName.ChangeParticle(listOfCangedNames);

            //Assert
            expected.Equals(actual);
        }
    }
}
