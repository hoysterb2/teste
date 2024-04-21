# Teste 

# Descritivo da Solução
 Um comerciante precisa controlar o seu fluxo de caixa diário com os lançamentos (débitos e créditos), também precisa de um relatório que disponibilize o saldo diário consolidado.
 
# Requisitos de negócio
- Serviço que faça o controle de lançamentos
- Serviço do consolidado diário

# Requisitos técnicos obrigatórios
- Desenho da solução
- Pode ser feito na linguagem que você domina - ok
- Testes - xunit
- Boas praticas são bem vindas (Design Patterns, Padrões de Arquitetura, SOLID e etc)
- Readme com instruções claras de como a aplicação funciona, e como rodar localmente
- Hospedar em repositório publico (GitHub)

*Caso os requisitos técnicos obrigatórios não sejam minimamente atendidos, o teste será descartado.*

# Requisitos não funcionais
O serviço de controle de lançamento não deve ficar indisponível se o sistema de consolidado diário cair.

Em dias de picos, o serviço de consolidado diário recebe 500 requisições por segundos, com no máximo 5% de perda de requisições.

===============================================
# Como fazer para rodar o software:
- Primeiro, precisara instalar o .NET8.0
- Apos ter o .NET8/0 vc precisara ter um banco de dados SqlServer na maquina - eu usei via docker, caso tenha o docker instalado o comando sera:
- docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Suf68421!" -p 1433:1433 -d mcr.microsoft.com/mssql/server
- Com esse comando vc podera rodar o Sql Server via docker ja com as configuracoes adequadas para a connection string configurada... 
- Caso tenha um Sql Server local, vc precisara alterar a connection string dentro do AppSettings.json 
- com isso feito, a aplicacao estara pronta para executar.