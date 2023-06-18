using Microsoft.AspNetCore.Http;

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
        var id = Guid.NewGuid();

        var path = Path.Combine(FilesDirectory,
            $"{id}.{_counter}.{formFile.FileName}");

        _counter++;

        await using var stream = new FileStream(path, FileMode.Create);

        await formFile.CopyToAsync(stream);

        var file = new Domain.File()
            { Id = id, Path = path, FileType = fileType, UserId = userId, SelfId = selfId, FileName = formFile.FileName};
        return file;
    }
}