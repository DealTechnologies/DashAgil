create view dbo.v_estoria_status_dexpara
AS
    select 'Remanescente' as status_novo, 1 as status_novo_num, 'Em Backlog' as status, 1 as status_num union
    select 'Remanescente' as status_novo, 1 as status_novo_num, 'Priorizado' as status, 2 as status_num union
    select 'Remanescente' as status_novo, 1 as status_novo_num, 'Analise de Viabilidade' as status, 3 as status_num union
    select 'Remanescente' as status_novo, 1 as status_novo_num, 'Especificacao' as status, 4 as status_num union
    select 'Remanescente' as status_novo, 1 as status_novo_num, 'Backlog Desenvolvimento' as status, 5 as status_num union
 
    select 'Em andamento' as status_novo, 2 as status_novo_num, 'Em Desenvolvimento' as status, 6 as status_num union
 
    select 'Desenvolvimento Concluído' as status_novo, 3 as status_novo_num, 'Em GC' as status, 7 as status_num union
    select 'Desenvolvimento Concluído' as status_novo, 3 as status_novo_num, 'Pacote Liberado' as status, 8 as status_num union
    
    select 'Homologação' as status_novo, 4 as status_novo_num, 'Em Homologação' as status, 9 as status_num union
 
    select 'Homologado' as status_novo, 5 as status_novo_num, 'Fila de Produção' as status, 10 as status_num union
 
    select 'Concluído' as status_novo, 6 as status_novo_num, 'Concluído' as status, 11 as status_num union
    select 'Concluído' as status_novo, 6 as status_novo_num, 'Promover na Main' as status, 12 as status_num