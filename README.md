# Teste 

# Descritivo da Solução
 Um comerciante precisa controlar o seu fluxo de caixa diário com os lançamentos (débitos e créditos), também precisa de um relatório que disponibilize o saldo diário consolidado.
 
===============================================
# Como fazer para rodar o software:
- Primeiro, precisara instalar o .NET8.0
- Apos ter o .NET8/0 vc precisara ter um banco de dados SqlServer na maquina - eu usei via docker, caso tenha o docker instalado o comando sera:
- docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Suf68421!" -p 1433:1433 -d mcr.microsoft.com/mssql/server
- Com esse comando vc podera rodar o Sql Server via docker ja com as configuracoes adequadas para a connection string configurada... 
- Caso tenha um Sql Server local, vc precisara alterar a connection string dentro do AppSettings.json 
- com isso feito, a aplicacao estara pronta para executar.

===============================================

# Explicações

- O sistema foi criado em .NET 8.0 e está usando um padrão de Clean Architecture onde eu tenho a Api|(Presentation), Services(Camada de aplicação), Infra(Infrastructure) e Domain
- Eu usei uma abordagem simples de criar meus services para manipular cada requisição
- No momento de criar uma transação seja crédito(entrada de valor) ou débito(saída de valor) a gente manda um evento de criação ou update de um relatório diários
- Eu usei um Mediatr para fazer envio do Evento, dependendo da complexidade da necessidade poderíamos fazer com um Worker especializado para isso e enviar uma mensagem via messageria 
- Na minha aplicação as interfaces de repositório e entidade de domínio ficam na camada de Domain
- a parte de acesso ao banco de dados fica na camada de infraestrutura (que são as implementações dos repositórios) e também meus mapeamentos do DB
- na parte dos services a gente tem o flow das regras de negócios, seja criação.. eventos.. buscar, nessa camada poderíamos ter usado CQRS, mas a complexidade não necessitava.
- Criei na camada de API um middleware para tratativa de erros internos
