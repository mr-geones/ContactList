using Business.Interfaces;
using Business.Services;

namespace Business.Tests.Services;

public class FileService_Tests
{
    private readonly IFileService _fileService;

    public FileService_Tests()
    {
        _fileService = new FileService("Tests", "test_contacts.json");
    }

    [Fact]
    public void SaveContentToFile_ShouldReturnTrueAndCreateFile()
    {
        // Arrange
        var content = "Test content";

        // Act
        var result = _fileService.SaveContentToFile(content);

        // Assert
        Assert.True(result);
    }
}
