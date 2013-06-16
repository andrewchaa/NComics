namespace NComics.Domain.Ports
{
    public interface IPageReader
    {
        string[] GetFilesFrom(string directory);
    }
}