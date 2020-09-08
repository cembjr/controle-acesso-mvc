# Aplicação Web AspNet Core MVC - Controle Acesso

Aplicação MVC para controle de acesso consumindo uma api de identidade para login e registro de usuários. Banco de dados MySql rodando em container docker.

Implementado:
- Autenticação com Cookies no MVC consumindo uma API com JWT.
- Criação de Interface IUser para obtenção de informações via IHttpContextAccessor de usuário logado no aplicação
- Utilização de HttpClient e System.Text.Json para consumo da API de Identidade
- Tratamento de Erros de Request com criação de Middleware para interceptar exceptions de HttpRequest
- ViewComponent de Sumário para mostrar ao usuário ao Erros

Comando para subir container do banco de dados:
- docker run --name mysql -d -p 3306:3306 -e MYSQL_ROOT_PASSWORD=senhaRoot@ -e MYSQL_DATABASE=identidade mysql:latest
