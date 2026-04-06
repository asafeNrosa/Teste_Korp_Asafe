Documentação Técnica do Projeto: Microserviços e Frontend
1. Ciclos de Vida do Angular (Lifecycle Hooks)
No desenvolvimento do frontend, foram utilizados os seguintes hooks para gerenciar o estado e o comportamento dos componentes:
ngOnInit(): Implementado em todos os componentes principais (Notas, Produtos) para inicializar a busca de dados. É o ponto de entrada para disparar as chamadas aos Services assim que o componente é renderizado.
ChangeDetectorRef.detectChanges(): Utilizado pontualmente para garantir a sincronização da interface do usuário em cenários de processamento assíncrono complexos, onde o mecanismo padrão de detecção de mudanças do Angular pode não capturar atualizações imediatas vinda dos microserviços.
2. Uso da Biblioteca RxJS
O RxJS foi fundamental para a comunicação assíncrona entre o Angular e as APIs.
Observables: Utilizados como o tipo de retorno padrão dos serviços HTTP, permitindo o tratamento de fluxos de dados de forma reativa.
.subscribe(): Utilizado nos componentes para "escutar" a resposta das APIs, tratando tanto o sucesso (armazenamento dos dados nas variáveis locais) quanto o erro.
Manipulação de Blobs: Uso de operadores para tratar fluxos de arquivos binários, especificamente para o download e visualização dos relatórios PDF gerados pela ImpressaoApi.
3. Bibliotecas e Dependências (Frontend e Backend)
Além do core dos frameworks, foram integradas as seguintes bibliotecas:
Frontend (Angular):
HttpClientModule: Para realizar as requisições REST ao API Gateway.
RouterModule: Para a navegação SPA (Single Page Application).
FormsModule: Para o binding bidirecional de dados ([(ngModel)]) em formulários e modais.
Backend (C# / .NET):
AutoMapper: Para converter de forma automática e segura as Entidades do banco de dados em DTOs (Data Transfer Objects).
QuestPDF: Biblioteca de alto desempenho utilizada para a diagramação e geração dos documentos fiscais em PDF.
System.Text.Json: Para a serialização de objetos em formato JSON nas trocas de mensagens entre as APIs.
4. Componentes Visuais
A interface foi construída com foco em responsividade e usabilidade:
Bootstrap 5: Utilizado para o sistema de grid, tipografia e componentes estruturais (Cards, Tabelas).
Modais do Bootstrap: Implementados para fluxos de criação e edição, evitando trocas de página desnecessárias.
Bootstrap Icons (BI): Utilizados para representar ações de forma visual (lixeira para exclusão, impressora para relatórios).
5. Frameworks e Gerenciamento no Backend
C#: Utilizou-se o ASP.NET Core Web API para a construção de microserviços escaláveis.
Entity Framework Core (EF Core): Atuou como o ORM (Object-Relational Mapper) para abstrair a camada de dados.
Golang: Não aplicado neste escopo (projeto focado em C#).
6. Tratamento de Erros e Exceções
O backend adota uma estratégia de "Fail-Fast" e respostas padronizadas:
Try-Catch & Logging: Blocos de captura em nível de Controller com registro de logs via ILogger para rastreabilidade de falhas.
Global Response Pattern: Uso de um objeto ErrorResponse para garantir que o frontend receba sempre o mesmo formato de erro.
HTTP Status Codes:
400 BadRequest: Erros de validação ou regras de negócio.
404 NotFound: Recursos não localizados.
500 Internal Server Error: Erros críticos de infraestrutura ou exceções não tratadas.
7. Uso de LINQ (C#)
O LINQ (Language Integrated Query) foi utilizado extensivamente no EF Core para manipulação de dados:
Consultas e Filtros: Uso de Where, FirstOrDefaultAsync e ToList para buscar registros específicos.
Carregamento de Relacionamentos: Uso do método .Include() (Eager Loading) para trazer dados relacionados, como os produtos vinculados a uma nota fiscal.
Validações: Uso de .Any() para verificar a existência de registros antes de processar operações de negócio.

