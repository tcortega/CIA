# CIA

---
## Conteúdo
- [Descrição](#descrição)
- [Princípios SOLID](#princípios-solid)
- [Vídeo Demonstrativo](#vídeo-demonstrativo)
- [Diagramas de Classe](#diagramas-de-classe)
	- [Projeto CIA](#projeto-cia)
	- [Projeto CIA.Core](#projeto-ciacore)


## Descrição

- Aplicação desenvolvida para o trabalho do primeiro bimestre da disciplina de Programação Orientada a Objetos.

- Trata-se de uma aplicação para controle de vendas e estoque de uma rede de lojas, onde o usuário poderá gerenciar as lojas cadastradas, bem como suas vendas e seus estoques. O usuário irá interagir com a aplicação por meio de uma interface de linha de comando, onde serão dispostos vários menus, são eles:

	1 - Menu de Lojas (responsável pelo gerenciamento das lojas)

	2 - Menu de Produtos (responsável pelo gerenciamento dos produtos)

	3 - Menu de Estoque (responsável pelo gerenciamento do estoque)

	4 - Menu de Consumidores (responsável pelo gerenciamento de consumidores)

## Princípios SOLID

- Neste projeto, foram aplicados os seguintes paradigmas SOLID:

	1 - Principio de Responsabilidade única 
		- As classes criadas foram pensadas para executar apenas suas funcionalidades principais, exemplo, a classes que contém o nome sufixo "Menu" são responsáveis pelas interações com o usuário, já as que tem "Service" pela intermediações entre as ações do usuário e o banco de dados, já as que tem "Entity" são reposaveis pela base de dados. O Préfixo determina a área que está sendo utilizada, exemplo: O prefixo "Store" diz respeito a funções das lojas, já o "Product" aos produtos e assim por diante.

	2 - Open-Closed Principle 
		- Está presente nos repositórios, pois os reposítórios de cada entidade são criados a partir de uma base, a qual permanecerá sem modificações, essas que serão feitas especificamente nos repositórios criados a partir dela. Esses repositórios, podem ser encontrados no CIA.Core, na pasta "Repositories".

	3 - Interface Segregation Principle
		 - As interfaces criadas possuem apenas os métodos que realmente serão utilizados pelas classes que irão implementa-las. Elas estão localizadas no CIA.Core, responsáveis pelo armazenamento de dados do projeto.

## Vídeo Demonstrativo
#### Clique [aqui](https://www.youtube.com/watch?v=ePRO7zeJXug) para acessar o vídeo.

## Diagramas de Classe

### Projeto CIA
![CIA Class Diagram](../media/Images/CIA.png?raw=true)


### Projeto CIA.Core
![CIA.Core Class Diagram](../media/Images/CIA.Core.png?raw=true)
