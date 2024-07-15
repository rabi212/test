using System.Threading;
using System.Threading.Tasks;

namespace ITCGKPLAB
{
    public interface IWorker
    {
        Task DoWorker(CancellationToken cancellationToken);
    }
}