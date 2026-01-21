# Developer Evaluation Project

Este repositório armazena o projeto de avaliação da Ambev de uma REST API feita com ASP .NET e faz o uso de Clean Architecture, com o código organizado em camadas, cada qual com sua responsabilidade, garantindo o isolamento do domínio e fazendo o uso de padrões como Mediator e CQRS para a comunicação dos objetos do sistema com baixo acoplamento.

# Modelo Conceitual do Domínio
<img width="1080" height="727" alt="domain_sales" src="https://github.com/user-attachments/assets/c158a0df-617c-4a10-9599-6fd649435a70" />

# Configurando e rodando o projeto

1) Abra uma linha de comando e clone o repositório rodando **git clone** https://github.com/lpjfalcao/dotnet-ambev-api.git
2) Navegue até a pasta raiz do projeto e rode o comando **docker-compose up -d --build** para rodar a aplicação e levantar os serviços nos containeres do Docker
3) Acesse a api via interface do swagger acessando no navegador http://localhost:5000/swagger/

# Configurando o banco de dados

1) No arquivo **appsettings.json** descomente a string de conexão que aponta para localhost:5001 (que é a porta que será mapeada para dentro do container)
2) Abra o console de gerenciador de pacotes do nuget
3) Selecione o projeto ORM
4) Rode o comando update-database

**Obs.: para o comando funcionar você precisa ter instalado os pacotes Microsoft.EntityFrameworkCore.Design e Microsoft.EntityFrameworkCore.Tools**

# Endpoints disponíveis
Foram adicionados os seguintes endpoints como parte do CRUD de vendas:

- Listar pedidos - GET /api/orders
- Listar um pedido específico - endpoint: GET /api/orders/id
- Cadastrar um pedido: POST /api/orders
- Atualizar um pedido - endpoint: PUT /api/orders/id
- Remover um pedido - DELETE /api/orders/id
