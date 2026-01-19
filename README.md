# Developer Evaluation Project

Este repositório armazena o projeto de avaliação da Ambev de uma REST API feita com ASP .NET e faz o uso de Clean Architecture, com o código organizado em camadas, cada qual com sua responsabilidade, garantindo o isolamento do domínio e fazendo o uso de padrões como Mediator e CQRS para a comunicação dos objetos do sistema com baixo acoplamento.

# Configurando e rodando o projeto

1) Abra uma linha de comando e clone o repositório rodando **git clone** https://github.com/lpjfalcao/dotnet-ambev-api.git
2) Navegue até a pasta raiz do projeto e rode o comando **docker-compose up -d --build** para rodar a aplicação e levantar os serviços nos containeres do Docker
3) Acesse a api via interface do swagger acessando no navegador http://localhost:5000/swagger/

# Modelo Conceitual do Domínio
<img width="1080" height="727" alt="domain_sales" src="https://github.com/user-attachments/assets/c158a0df-617c-4a10-9599-6fd649435a70" />
