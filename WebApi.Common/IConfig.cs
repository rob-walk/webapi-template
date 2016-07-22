
namespace WebApi.Common
{
    public interface IConfig
    {
        string Environment { get; }
        string Version { get; }
    }
}