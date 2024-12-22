using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Repositories;

public class ContactRepository(IFileService fileService) : IContactRepository
{
    private readonly IFileService _fileService = fileService;

    public bool SaveContactListToFile(List<Contact> list)
    {
        try
        {
            var json = JsonSerializer.Serialize(list);
            var result = _fileService.SaveContentToFile(json);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public List<Contact> GetContactsFromFile()
    {
        try
        {
            var json = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(json))
            {
                return JsonSerializer.Deserialize<List<Contact>>(json)!;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return [];
    }
}
