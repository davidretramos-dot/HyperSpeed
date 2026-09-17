# HyperSpeed

Descrição
--------
Aplicação web Razor Pages construída sobre .NET 10. Fornece uma base para desenvolvimento de páginas Razor com convenções de projeto, segurança básica e práticas recomendadas para views.

Tecnologias
-----------
- .NET 10
- Razor Pages
- C#
- Visual Studio 2026 (recomendado)

Pré-requisitos
--------------
- .NET 10 SDK instalado
- Visual Studio 2026 ou VS Code com extensões C#
- Git

Clonar repositório
------------------
git clone https://github.com/davidretramos-dot/HyperSpeed.git

Como compilar e executar (CLI)
-----------------------------
1. Abra o terminal na raiz do repositório.
2. Restaurar pacotes:
   dotnet restore HyperSpeed.slnx
3. Compilar:
   dotnet build HyperSpeed.slnx
4. Executar (apontar para o projeto Razor Pages):
   dotnet run --project <Caminho/Para/Projeto.RazorPages.csproj>

Executar no Visual Studio
-------------------------
- Abra HyperSpeed.slnx no Visual Studio 2026.
- Defina o projeto Razor Pages como projeto de inicialização.
- Build (Ctrl+Shift+B) e Start (F5).

Estrutura do repositório (resumo)
---------------------------------
- / - solução HyperSpeed.slnx
- /[ProjetoRazorPages] - projeto Razor Pages (Pages/, wwwroot/, etc.)
- /README.md, /.gitignore, /LICENSE (se aplicável)

Diretrizes de desenvolvimento (views Razor)
------------------------------------------
- Preferir tag-helpers (asp-for) em inputs e labels.
- Incluir token antifalsificação em formulários que alteram estado (ex.: @Html.AntiForgeryToken() ou tag-helper equivalente).
- Usar spans de validação (asp-validation-for) para mensagens de erro.
- Evitar duplicação de formulários/HTML; reutilizar partials e components quando possível.

Testes
------
- Se houver projeto de testes: dotnet test

Contribuição
------------
- Fork → branch de feature → pull request.
- Mantenha o estilo consistente com as convenções C# do projeto.
- Documente alterações significativas no README ou CHANGELOG.

Contato
------
Repositório: https://github.com/davidretramos-dot/HyperSpeed

Licença
------
Verifique o arquivo LICENSE no repositório ou adicione conforme política do projeto.
