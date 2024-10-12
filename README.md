# Sistema de Gerenciamento de Fornecedores e Vendedores

![.NET](https://img.shields.io/badge/.NET-6.0-purple) ![FluentValidation](https://img.shields.io/badge/FluentValidation-10.3.6-blue) ![FIAP](https://img.shields.io/badge/FIAP-Advanced%20Business%20Development-success)

## 📝 Descrição

Este projeto faz parte do **Checkpoint 2** da disciplina **Advanced Business Development With .NET** da FIAP, ministrada pelo professor **Humberto Oliveira**. O sistema tem como objetivo gerenciar as informações de **Fornecedores** e **Vendedores**, implementando conceitos de **Injeção de Dependência**, **Validações com FluentValidation**, e operações **CRUD** para persistência dos dados.

---

## 🚀 Funcionalidades

### 🔹 Gerenciamento de Fornecedores
- Cadastrar, editar, listar, visualizar e deletar fornecedores.
- Validações com **FluentValidation** (CNPJ, Email, Telefone).

### 🔹 Gerenciamento de Vendedores
- Cadastrar, editar, listar, visualizar e deletar vendedores.
- Validações com **FluentValidation** (Comissão Percentual, Meta Mensal).

---

## ✅ Validações Implementadas

### Fornecedor:
- **Nome:** deve ter no mínimo 5 caracteres.
- **CNPJ:** não pode ser vazio e deve conter 14 números.
- **Telefone:** obrigatório, no formato `(XX) XXXXX-XXXX`.
- **Email:** deve estar no formato `email@email.com`.

### Vendedor:
- **Nome:** deve ter no mínimo 5 caracteres.
- **Email:** deve estar no formato `email@email.com`.
- **Telefone:** obrigatório, no formato `(XX) XXXXX-XXXX`.
- **Comissão Percentual:** entre 0 e 100.
- **Meta Mensal:** valor deve ser maior que zero.

---

## 🛠️ Requisitos

1. **Visual Studio 2022**: Abra o projeto no Visual Studio 2022.
2. **Pacotes NuGet**: Instale as dependências necessárias usando o NuGet Package Manager.
3. **String de Conexão**: Configure a string de conexão no arquivo `appsettings.json`.
4. **Migrations**: Atualize o banco de dados com o comando:

   ```bash
   Update-Database
   
## 📖 Como Executar

1. Configure a string de conexão no arquivo appsettings.json.
2. Execute as migrations para preparar o banco de dados.
3. Compile e rode o projeto no Visual Studio 2022.
4. Acesse o Swagger UI para interagir com a API:

  ```bash
https://localhost:{port}/swagger/index.html
```
5. Utilize os endpoints disponíveis para gerenciar Fornecedores e Vendedores.
