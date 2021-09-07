using WebApplication.Models;

namespace WebApplication.Blob
{
    public interface IBlobHandler
    {
        void SaveToContainer(NoticiaModel model);
    }
}
