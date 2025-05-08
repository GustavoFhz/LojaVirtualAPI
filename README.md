# 🛒 LojaVirtual API

API RESTful desenvolvida em ASP.NET Core para gerenciamento de produtos, categorias e usuários de uma loja virtual. Suporta cadastro com upload de imagens, autenticação segura e organização por categorias.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper (opcional)
- Swagger (para documentação)
- JWT (autenticação - se aplicável)
- .NET 6 ou superior

---

## 🛠️ Endpoints Principais

### 📦 Produtos

- `GET /api/produto`  
  Lista todos os produtos.

- `GET /api/produto/{id}`  
  Retorna os dados de um produto específico.

- `POST /api/produto`  
  Cadastra um novo produto.  
  Corpo da requisição: `ProdutoDto`

- `PUT /api/produto`  
  Edita os dados de um produto.  
  Corpo da requisição: `ProdutoEdicaoDto`

- `POST /api/produto/upload-produtos`  
  Upload de imagem + dados do produto (form-data).

---

### 📁 Categorias

(Adicione aqui quando houver controller de categoria)

---

### 👤 Usuários

- `POST /api/usuario`  
  Cadastra um novo usuário com criptografia de senha.  
  Corpo da requisição: `UsuarioCriacaoDto`

---
🧪 Validações
A criação de produtos exige nome, descrição, preço e uma categoria existente.

O sistema impede o cadastro de produtos com nomes repetidos.

Validações são feitas via Data Annotations e regras personalizadas.

📷 Upload de Imagens
As imagens são salvas na pasta wwwroot/imagens. O caminho da imagem é armazenado no banco via campo ImagemUrl.

📌 Observações
Certifique-se de que as categorias existam antes de cadastrar produtos.

O projeto pode ser expandido com autenticação JWT, filtros de busca e paginação.



