using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITCGKPLAB
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private int number = 0;
        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }
        public async Task DoWorker(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);
                number = number > 4 ? 0 : number;
                //logger.LogInformation($"Worker Printing number : { number = (number > 4 ?  0 : number)}");
                //await Task.Delay(1000 * 2);
                await Task.Delay(1000 * 2, cancellationToken);
            }
        }
    }
}
