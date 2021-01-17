using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Integrador.Infra.Data.Queries
{
    public class DemandasQueries
    {
        public const string Insert = @"INSERT INTO [DashAgil].[dbo].[Demandas]
													([Id]
													,[ExternalId]
													,[SprintId]
													,[ProjetoId]
													,[SquadId]
													,[Tipo]
													,[DemandaPaiId]
													,[Descricao]
													,[Responsavel]
													,[DataInicio]
													,[DataModificacao]
													,[DataFim]
													,[Pontos]
													,[Tags]
													,[Prioridade]
													,[HorasEstimadas]
													,[HorasRestantes]
													,[HorasUtilizadas]
													,[Risco]
													,[Comentario]
													,[Status])
								VALUES(@Id
									  ,@ExternalId
									  ,@SprintId
									  ,@ProjetoId
									  ,@SquadId
									  ,@Tipo
									  ,@DemandaPaiId
									  ,@Descricao
									  ,@Responsavel
									  ,@DataInicio
									  ,@DataModificacao
									  ,@DataFim
									  ,@Pontos
									  ,@Tags
									  ,@Prioridade
									  ,@HorasEstimadas
									  ,@HorasRestantes
									  ,@HorasUtilizadas
									  ,@Risco
									  ,@Comentario
									  ,@Status);  SELECT SCOPE_IDENTITY() ";

		public const string Update = @"UPDATE DashAgil.dbo.Demandas SET ExternalId = @ExternalId , 
															     SprintId = @SprintId ,
															     ProjetoId = @ProjetoId , 
															     SquadId = @SquadId , 
															     Tipo = @Tipo ,
																 DemandaPaiId = @DemandaPaiId , 
																 Responsavel = @Responsavel , 
																 DataInicio = @DataInicio, 
																 DataModificacao = @DataModificacao , DataFim = @DataFim,
																 Pontos = @Pontos , Tags = @Tags , Prioridade = @Prioridade, 
																 HorasEstimadas = @HorasEstimadas , 
																 HorasRestantes = @HorasRestantes, 
																 HorasUtilizadas = @HorasUtilizadas ,
																 Risco = @Risco , Comentario = @Comentario , 
																 Status = @Status , Descricao = @Descricao  
								WHERE Id = @Id	";

		public const string Select = @"select * from DashAgil.dbo.Demandas";


		public const string SelectById = @"Select * from DashAgil.dbo.Demandas where Id = @Id ";

		public const string Delete = @"delete from DashAgil.dbo.Demandas where Id = @Id ";

	}
}
