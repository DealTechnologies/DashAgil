using DashAgil.Integrador.Infra.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DashAgil.Integrador.Api.Services
{
    public class SyncService : BackgroundService
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<SyncService> logger;

        /// <summary>
        /// The synchronizer service.
        /// </summary>
        private readonly AppSettings appSettings;

        ///// <summary>
        ///// The synchronize handler
        ///// </summary>
        //private readonly SyncHandler syncHandler;


        public SyncService(ILogger<SyncService> logger, IOptions<AppSettings> options)
        {
            this.logger = logger;
            this.appSettings = options.Value;
        }

        /// <summary>
        /// The project name.
        /// </summary>
        private static string ProjectName => Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// The start async.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"The '{ProjectName}' service has been started started at:", System.DateTimeOffset.Now);
            return base.StartAsync(cancellationToken);
        }

        /// <summary>
        /// The execute async.
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"Running '{ProjectName}' at: {DateTimeOffset.Now}");
                await Task.Delay(TimeSpan.FromMinutes(this.appSettings.RunEach), stoppingToken);
            }
        }

        /// <summary>
        /// The stop async.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"The '{ProjectName}' service has been stopped stopped at:", DateTimeOffset.Now);
            return base.StopAsync(cancellationToken);
        }
    }
}
