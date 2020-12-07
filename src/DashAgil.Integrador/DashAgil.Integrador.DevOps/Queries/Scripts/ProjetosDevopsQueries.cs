namespace DashAgil.Integrador.DevOps.Queries
{
    public static class ProjetosDevopsQueries
    {
        public const string Insert = @" 
									   IF(SELECT 1 FROM DashAgil.dbo.ProjetosDevops  T0
									   			where t0.ProjetoId = @ProjetoId  ) > 0
									   BEGIN
									   		UPDATE DashAgil.dbo.ProjetosDevops SET Nome = @Nome, 
									   				   Descricao = @Descricao,  
									   				   DataUltimaAtualizacao = @DataUltimaAtualizacao 
									   		where ProjetoId = @ProjetoId  and DataUltimaAtualizacao <> @DataUltimaAtualizacao
									   END 
									   ELSE BEGIN
									   
									   		INSERT  DashAgil.dbo.ProjetosDevops
									   		VALUES  (@Id, @Nome, @Descricao, @ProjetoId, @DataUltimaAtualizacao, @DataCadastro)
									   
									   END  ";
    }
}
