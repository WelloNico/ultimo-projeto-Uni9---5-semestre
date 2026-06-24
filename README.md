#  Compraí — Listas de Compras Compartilhadas

Sistema web para gerenciamento colaborativo de listas de compras, desenvolvido como projeto de conclusão do 5º semestre na Uni9.

##  Sobre o Projeto

A organização de compras em ambientes compartilhados, como residências familiares, moradias estudantis e escritórios, frequentemente apresenta desafios relacionados à comunicação, controle e planejamento dos itens necessários.

O **Compraí** resolve esse problema permitindo que múltiplos usuários colaborem em uma lista de compras de forma estruturada, facilitando a inserção, visualização e gerenciamento dos itens.

##  Funcionalidades

- Criar e gerenciar listas de compras personalizadas
- Adicionar itens com nome, marca, quantidade e preço estimado
- Colaboração entre múltiplos usuários na mesma lista
- Login individual para cada participante
- Visualização do total estimado da compra e contribuição por usuário
- Identificação de quem adicionou cada item *(proposta de melhoria)*
- Alerta de duplicidade de itens *(proposta de melhoria)*
- Teto de orçamento por compra *(proposta de melhoria)*
- Leitura de código de barras via câmera *(proposta de melhoria)*

##  Tecnologias

Esse projeto foi desenvolvido utilizando .NET MVC (versão 9.0) e Bootstrap como framework, MySQL como banco de dados e algumas poucas funcionalidades em JavaScript. Tudo isso através do ambiente de desenvolvimento Visual Studio.

Dentro do Visual studio, será necessario baixar as extensões:
- Microsoft.EntityFrameworkCore.Design:
- Pomelo.EntityFrameworkCore.MySql
- BCrypt.Net-Next

  Atente-se ao baixar as extensões pois elas devem ser compativeis com a versão 9.0 do .NET

##  Como rodar o projeto

1. Depois de clonar o repositorio abaixo:
```bash
   git clone https://github.com/WelloNico/ultimo-projeto-Uni9---5-semestre.git
```

2. Abra a pasta do projeto e localize o arquivo RecriarBD.sql (Database\RecriarDBsql). Ele permitirá que você recrie o o banco de dados no MySQL.
3. Abra o projeto no Visual Studio 2022
4. Execute com `F5` ou `Ctrl + F5`
5. Em seu primeiro acesso, cadastre-se para acessar.
6. Você será levado até a página inicial.
7. Navegue para a página que cria uma nova lista clicando no segundo icone do menu.
8. Adicione quantos itens desejar e depois salve a lista, salvando-os um a um.
9. De volta a tela inicial, fique a vontade para clicar no icone de adição e inserir um novo item ou clicar na lixeira e excluir a lista criada.


##  Público-alvo

Grupos que realizam compras coletivas — famílias, repúblicas estudantis, equipes de trabalho ou mesmo grupos que estejam planejando festas ou viagens.
