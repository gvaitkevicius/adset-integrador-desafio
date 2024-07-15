<img src="https://github.com/adset-innov/adset-integrador-desafio/blob/main/adset-integrador.png">

# Desafio para candidatos (AdSet Integrador)

## Solicitação:

- Criar funcionalidade para incluir, consultar, excluir e alterar cadastro de carros e na tela de consulta dos veículos possibilitar a seleção por veículo de apenas um pacote para cada portal iCarros e WebMotors, os pacotes serão (Bronze, Diamante, Platinum ou Básico), conforme layout.
- O cadastro deverá possuir os campos (Marca, Modelo, Ano, Placa, Km, Cor, Preço, lista de opcionais para atribuir ao veículo ex.: (Ar Condicionado, Alarme, Airbag, Freio ABS)).
- Deverá ser possível incluir até 15 fotos para o veículo.
- Apenas a km, opcionais e fotos não devem ser obrigatórios.
- O layout codificado deverá ser exatamente o mesmo do arquivo disponível (adset-layout.ai).
- Nos filtros de dropdown deverão ter as seguintes opções por cada drop (<b>Ano Min</b> = 2000, 2001, 2002.. até 2024 | <b>Ano Max</b> = 2000, 2001, 2002.. até 2024 | <b>Preço</b> = 10mil a 50mil, 50mil a 90mil, +90mil | <b>Fotos</b> = Com Fotos, Sem Fotos | <b>Cor</b> = Listar as cores com os valores em distinct dos veículos inseridos).

Após terminar seu teste submeta um pull request e aguarde seu feedback.

## Instruções:
- Criar Projeto do tipo Class Library para separar a camada de Dados.
- Criar Projeto do tipo ASP.NET Web Application com Template MVC/Razor (Front-End)
- A tela de estoque / consulta deverá ser desenvolvida conforme o layout (https://github.com/adset-innov/adset-integrador-desafio/blob/main/adset-layout.ai) criado no programa Adobe Illustrator.
- Na camada de dados deixe a estrutura completa do Migration para o Entity Framework Code-First pronta para apenas executarmos e gerar o banco e tabelas.
- Caso você julgar necessário, utilize Design patterns e nos informe quais utilizou e porque.

## Pré-requisitos:
- HTML5, CSS, JavaScript, Bootstrap, POO, C#, .NET 4.0+, WebApi, C#, ASP NET, SQL, LINQ, Entity Framework, Code First, Design Responsivo, WebServices *(SOAP)*, APIs Restfull e Windows Services

### IDE:
 - Visual Studio 2013+
 
### Servidor de Banco:
 - Microsoft SQL Server 2012+

## Notas:
* Lembre-se de fazer um fork deste repositório! Apenas cloná-lo vai te impedir de criar o pull request e dificultar a entrega;

## Tecnologias: 
- ASP NET CORE MVC
- .NET 8.0
- Visual Studio 22

## Funções e Libs Implementadas
- Funcionalidade para incluir, consultar, excluir e cadastro de carros.
- Filtro de consulta conforme solicitado.
- Estrutura de dados separada em um projeto Class Library.
- API RESTful (CarApiController) para demonstrar o uso de APIs.
- Exemplo de WebService SOAP (não utilizado na aplicação, mas presente para demonstração).
- Entity Framework e Code First
- No create do veiculo foi utilizado LINQ
- HTML E CSS, junto com JS e boostrap
  
  
 
 Utilização do padrão de projeto IRepository.

Motivo do IRepository:
Separação das preocupações, permitindo que a lógica de acesso a dados fique isolada da lógica de negócios.

## Funções Pendentes
- Seleção por veículo de apenas um pacote para cada portal iCarros e WebMotors

- Salvar Foto - Como faria: Armazenaria as imagens como BLOB no banco de dados. Na aplicação web, as imagens seriam convertidas de BLOBs para base64 para exibição.
  
- Editar Veículo - Implementação: Utilizaria a mesma tela de criação para a edição, passando o ID do veículo a ser editado. No momento de salvar, realizaria um update no registro existente.

- Layout - Não consegui uma solução ideal para converter diretamente o arquivo .ai para HTML. Portanto, recriei o layout no olhômetro, porem priorizando as funcionalidades principais e não fazendo por completo.

