using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class UploadService
{
    public async Task<string> UploadFile(IFormFile file, string filename)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/drinkLineImages");

        RemoveFilesWithName(path, filename);

        string fileExtension = file.FileName.Substring(file.FileName.LastIndexOf("."));
        string filenameWithExtension = filename + fileExtension;
        string filePath = Path.Combine(path, filenameWithExtension);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return filenameWithExtension;
    }

    private void RemoveFilesWithName(string path, string filename)
    {
        string filePathWithoutExtension = Path.Combine(path, filename);

        IEnumerable<string> files = Directory
            .GetFiles(path)
            .Where(file => file.StartsWith(filePathWithoutExtension));

        foreach (var file in files)
        {
            File.Delete(file);
        }
    }
}
