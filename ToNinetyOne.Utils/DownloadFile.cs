using Microsoft.AspNetCore.Http;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Utils;

public static class DownloadFile
{
    public static readonly string FilesDirectory = Path.Combine("UploadedFiles");

    private static int _counter = 0;

    public static async Task<Domain.File> Download(IFormFile formFile)
    {
        return await Download(formFile, Guid.Empty, Guid.Empty, null);
    }

    public static async Task<Domain.File> Download(IFormFile formFile, Guid userId, Guid selfId, string? fileType)
    {
        var path = Path.Combine(FilesDirectory,
            $"{DateTime.Now.Ticks}.{_counter}.{formFile.FileName}");

        _counter++;

        await using var stream = new FileStream(path, FileMode.Create);
        await formFile.CopyToAsync(stream);
        var file = new Domain.File()
            { Id = Guid.NewGuid(), Path = path, FileType = fileType, UserId = userId, SelfId = selfId };
        return file;
    }
}