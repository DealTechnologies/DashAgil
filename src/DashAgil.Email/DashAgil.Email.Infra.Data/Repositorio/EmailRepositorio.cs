using Dapper;
using DashAgil.Email.Entidades.DTO;
using DashAgil.Email.Repositorio;
using DashAgil.Entidades;
using DashAgil.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Email.Infra.Data.Repositorio
{
    public class EmailRepositorio : IEmailRepositorio
    {
        private readonly DataContext context;

        public EmailRepositorio(DataContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Emails>> ListarAsync() =>
            await context.Connection.QueryAsync<Emails>("SELECT * FROM EMAILS");

        public async Task<Emails> ObterAsync(Guid id) =>
            await context.Connection.QueryFirstOrDefaultAsync<Emails>("SELECT * FROM EMAILS WHERE Id = @Id", new { id });

        public async Task<EmailStatusDTO> ObterCountAsync()
        {
            var emailStatus = new EmailStatusDTO();
            var result = await context.Connection.QueryAsync<dynamic>("select Status, Count(0) as count from Emails group by Status");

            result.ToList().ForEach(o =>
            {
                emailStatus.Aberto += o.Status == (int)StatusEmail.Open ? o.count : 0;
                emailStatus.Clicado += o.Status == (int)StatusEmail.Click ? o.count : 0;
                emailStatus.Criado += o.Status == (int)StatusEmail.Created ? o.count : 0;
                emailStatus.Entregue += o.Status == (int)StatusEmail.Delivery ? o.count : 0;
                emailStatus.Enviado += o.Status == (int)StatusEmail.Send ? o.count : 0;
                emailStatus.Lixo += o.Status == (int)StatusEmail.Bounce ? o.count : 0;
                emailStatus.Rejeitado += o.Status == (int)StatusEmail.Complaint ? o.count : 0;
            });

            return emailStatus;
        }

        public async Task AdicionarAsync(Emails emails)
        {
            await context.Connection.ExecuteAsync(@"INSERT INTO EMAILS VALUES (
                @Id,
                @Assunto,
                @Conteudo,
                @Anexos,
                @Remetente,
                @Destinatario,
                @DataCriacao,
                @DataEnvio,
                @Entregues,
                @Lixo,
                @Rejeitados,
                @Abertos,
                @Status
            )", emails);
        }

        public async Task AtualizarAsync(Emails emails)
        {
            await context.Connection.ExecuteAsync(@"UPDATE EMAILS SET                
                    Assunto = @Assunto,
                    Conteudo = @Conteudo,
                    Anexos = @Anexos,
                    Remetente = @Remetente,
                    Destinatario = @Destinatario,
                    DataCriacao = @DataCriacao,
                    DataEnvio = @DataEnvio,
                    Entregues = @Entregues,
                    Lixo = @Lixo,
                    Rejeitados = @Rejeitados,
                    Abertos = @Abertos,
                    Status = @Status
                WHERE
                    Id = @Id    
            ", emails);
        }
    }
}
