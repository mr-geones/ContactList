using Business.Interfaces;
using Business.Models;
using Business.Repositories;

namespace Business.Tests.Repositories
{
    public class ContactRepository_Tests
    {
        private readonly string _testFilePath = "test_contacts.json";

        private IFileService CreateFileService()
        {
            return new FileService(_testFilePath);
        }

        [Fact]
        public void SaveContactListToFile_ShouldReturnTrue_WhenContactsAreSaved()
        {
            // Arrange
            var fileService = CreateFileService();
            var repository = new ContactRepository(fileService);
            var contacts = new List<Contact>
            {
                new Contact 
                { 
                    Id = "1", 
                    Forename = "John", 
                    Surname = "Doe", 
                    Email = "john.doe@example.com", 
                    Phone = "123123123", 
                    Address = "Easy Street 1",
                    PostalCode = "12345",
                    City = "Springfield"
                }
            };

            // Act
            var result = repository.SaveContactListToFile(contacts);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetContactsFromFile_ShouldReturnContacts_WhenFileHasContent()
        {
            // Arrange
            var fileService = CreateFileService();
            var repository = new ContactRepository(fileService);
            var contacts = new List<Contact>
            {
                new Contact { Id = "1", Forename = "John", Surname = "Doe", Email = "john.doe@example.com" }
            };
            repository.SaveContactListToFile(contacts);

            // Act
            var result = repository.GetContactsFromFile();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("John", result[0].Forename);
        }
    }

    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public bool SaveContentToFile(string content)
        {
            try
            {
                File.WriteAllText(_filePath, content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetContentFromFile()
        {
            try
            {
                return File.ReadAllText(_filePath);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
