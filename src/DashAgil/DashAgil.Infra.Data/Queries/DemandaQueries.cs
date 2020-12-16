﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DashAgil.Infra.Data.Queries
{
    public class DemandaQueries
    {
        public const string GetAll =
            @"SELECT d.Id, d.ExternalId, d.SquadId, d.Tipo, d.DataInicio, d.DataModificacao, d.DataFim, d.Pontos, d.Status, d.Descricao, v.status_novo_num as StatusDeXPara
                            FROM Demandas d 
                                INNER JOIN v_estoria_status_dexpara v on d.status = v.status_num
                                INNER JOIN Projetos p on d.ProjetoId = p.Id
                                INNER JOIN Organizacoes o on p.OrganizacaoId = o.Id
                            WHERE o.ClienteId = @ClienteId 
                                and d.Tipo = @Tipo
                                and (@SquadId = 0 OR d.SquadId = @SquadId)
                            ORDER BY d.ExternalId";

        public const string GetDemandas =
            @"DECLARE @TMP_DEMANDAS TABLE (
                    Id UNIQUEIDENTIFIER, 
                    SquadId bigint, 
                    Tipo int, 
                    DataInicio DATETIME,
                    DataModificacao datetime, 
                    DataFim datetime, 
                    Pontos int, 
                    Status int, 
                    Descricao varchar(200), 
                    StatusDeXPara int,
                    IdSquad bigint,
                    Nome varchar(200)
                )

            INSERT INTO @TMP_DEMANDAS
            SELECT d.Id, d.SquadId, d.Tipo, d.DataInicio, d.DataModificacao, d.DataFim, d.Pontos, d.Status, d.Descricao, v.status_novo_num as StatusDeXPara,
                                s.Id, s.Nome   
            FROM Demandas d 
                INNER JOIN Squads s on d.SquadId = s.Id
                INNER JOIN v_estoria_status_dexpara v on d.status = v.status_num
                INNER JOIN Projetos p on d.ProjetoId = p.Id
                INNER JOIN Organizacoes o on p.OrganizacaoId = o.Id
            WHERE o.ClienteId = @ClienteId 
                and d.Tipo = @Tipo

            INSERT INTO @TMP_DEMANDAS(Status, StatusDeXPara)
            SELECT DISTINCT 0 as Status, v.status_novo_num as StatusDeXPara
            FROM v_estoria_status_dexpara v
            WHERE NOT EXISTS(SELECT TOP 1 1 FROM @TMP_DEMANDAS tmp WHERE tmp.StatusDeXPara = v.status_novo_num)

            SELECT * FROM @TMP_DEMANDAS";

        public const string GetFeaturesEstorias =
            @"SELECT features.id as FeatureId, features.descricao as FeatureDescricao, 
                                 estorias.Id, estorias.SquadId, estorias.Tipo, estorias.DataInicio, estorias.DataModificacao, estorias.DataFim, 
                                 estorias.Pontos, estorias.Status, v.status_novo_num as StatusDeXPara, estorias.Descricao
                          FROM Demandas features
                               INNER JOIN Demandas estorias on features.Id = estorias.DemandaPaiId and estorias.Tipo = @TipoEstoria
                               INNER JOIN v_estoria_status_dexpara v on estorias.status = v.status_num
                               INNER JOIN Projetos p on features.ProjetoId = p.Id
                               INNER JOIN Organizacoes o on p.OrganizacaoId = o.Id 
                          WHERE o.ClienteId = @ClienteId
                                and features.Tipo = @TipoFeature
                                and features.SquadId = @SquadId";

        public const string GetEstoriasHistorico =
            @"SELECT d.Id, d.SquadId, d.Tipo, d.Status, d.Descricao, d.Pontos,
                                 s.Nome as SprintNome, s.DataInicio as SprintDataInicio, s.DataFim as SprintDataFim,
                                 dh.Id as IdHistorico, dh.DataModificacao, v.status_novo_num as StatusDeXPara
                          FROM Demandas d
                               INNER JOIN Sprints s on d.SprintId = s.Id
                               INNER JOIN Projetos p on d.ProjetoId = p.Id
                               INNER JOIN Organizacoes o on p.OrganizacaoId = o.Id 
                               LEFT JOIN DemandaHistorico dh on d.Id = dh.Id
                               LEFT JOIN v_estoria_status_dexpara v on dH.status = v.status_num
                          WHERE o.ClienteId = @ClienteId
                                and d.Tipo = @TipoDemanda
                                and d.SquadId = @SquadId
                                and d.SprintId = @SprintId";
    }
}