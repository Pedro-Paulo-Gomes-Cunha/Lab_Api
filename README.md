# Lab_Api
O objetivo deste desafio é criar uma aplicação backend (API) que forneça operações CRUD (Create, Read, Update, Delete) para gerenciar informações sobre escolas.

# Requisitos
Abaixo estão descritas as funcionalidades que você deve adicionar à sua aplicação.

1. Implemente as operações básicas de CRUD para manipular os dados das escolas. Isso inclui:
       - Create (Criar): Permitir a criação de uma nova escola com os seguintes campos obrigatórios: nome, email, número de salas e província
       - Read (Ler): Recuperar informações sobre uma escola específica e listar todas as escolas existentes.
       - Update (Atualizar): Permitir a atualização dos dados de uma escola existente.
       - Delete (Excluir): Permitir a exclusão de uma escola existente.
2. A província deve ser preenchida através de um JSON enviado no formato da requisição. Seu aplicativo deve ser capaz de filtrar as províncias disponíveis com base nos dados fornecidos no JSON.
3. Utilize o Swagger para documentar sua API. Isso inclui descrever os endpoints disponíveis, os parâmetros necessários, os tipos de resposta esperados, etc.
4. Upload de Excel e Carregamento de Dados na Base de Dados: Seu aplicativo deve permitir que os usuários façam upload de um arquivo Excel contendo informações sobre as escolas e, em seguida, carregue esses dados na base de dados. Para isso, siga as especificações abaixo:
5. Estrutura do Excel: O arquivo Excel deve seguir uma estrutura específica, com colunas para cada campo de dados da escola (nome, email, número de salas, província).
6. Preenchimento do Excel: Antes do upload, o usuário deve preencher o Excel com os dados das escolas.
7. Upload do Excel: O aplicativo deve permitir que o usuário faça o upload do arquivo Excel. Carregamento dos Dados: Após o upload, o aplicativo deve ler os dados do Excel e inseri-los na base de dados, criando uma nova entrada para cada escola no arquivo Excel.

# Ferramentas
1. C# (Asp.net)
2. SqlServer (Banco de dados)

# Link da Api

