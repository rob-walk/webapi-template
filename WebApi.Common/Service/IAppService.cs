using log4net;

namespace WebApi.Common.Service
{
    public interface IAppService
    {
        IConfig Configuration { get; }
        ILog Log { get; }
    }
}
