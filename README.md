# PokeAPI <img src="https://i.imgur.com/G5u3Z60.png" alt="Pokébola" width="28" height="28">

A PokeAPI é uma API Pokémon desenvolvida em .NET, utilizando o Entity Framework (EF) e Fluent API para mapeamento de entidades, seguindo o padrão arquitetural MVC (Model-View-Controller). O banco de dados utilizado é o SQLite, escolhido por sua leveza e facilidade de uso.

Este projeto foi desenvolvido exclusivamente para fins de estudo e aprendizado sobre a construção de APIs com .NET e manipulação de dados com Entity Framework. Estou ciente da existência da [PokéAPI](https://pokeapi.co/), que é uma excelente fonte de dados sobre Pokémon.

Atualmente, o banco de dados está populado com os 151 Pokémon da primeira geração, todas as regiões e os tipos existentes no universo Pokémon.

## Instalação e Execução
Siga os passos abaixo para configurar e executar o projeto localmente.

### Pré-requisitos
Antes de iniciar, certifique-se de ter os seguintes itens instalados:
<ul>
    .NET 8 ou superior
</ul>

### 1. Clone o repositório:
```bash
git clone https://github.com/rafaelwnk/PokeAPI.git
cd PokeAPI
```

### 2. Restaure as dependências:
```bash
dotnet restore
```

### 3. Execute o projeto:
```bash
dotnet run
```

## Utilização da API

Por padrão, a API está disponível em:

**http://localhost:5063**

Para explorar os endpoints disponíveis e testar as funcionalidades da API, acesse a documentação interativa via Swagger:

**http://localhost:5063/swagger**

## Exemplos de uso:

### 1. **Pókemon**

**Endpoint:**

`GET v1/pokemons/{id}`

**Descrição:**  
Retorna um pokémon com base no id.

**Exemplo de requisição:**
```bash
curl -X GET "http://localhost:5063/v1/pokemons/94"
```

**Exemplo de resposta:**
```bash
{
    "data": {
        "id": 94,
        "name": "Gengar",
        "types": [
            "Poison",
            "Ghost"
        ],
        "weaknesses": [
            "Ground",
            "Psychic",
            "Ghost",
            "Dark"
        ],
        "region": "Kanto",
        "hasMega": true
    },
    "errors": []
}
```

### 2. **Tipos**

**Endpoint:**

`GET v1/types/{name}`

**Descrição:**  
Retorna um tipo com base no nome.

**Exemplo de requisição:**
```bash
curl -X GET "http://localhost:5063/v1/types/Ghost"
```

**Exemplo de resposta:**
```bash
{
    "data": {
        "id": 14,
        "name": "Ghost"
    },
    "errors": []
}
```

### 2. **Regiões**

**Endpoint:**

`GET v1/regions`

**Descrição:**  
Retorna todas as regiões.

**Exemplo de requisição:**
```bash
curl -X GET "http://localhost:5063/v1/regions"
```

**Exemplo de resposta:**
```bash
{
    "data": [
        {
            "id": 1,
            "name": "Kanto"
        },
        {
            "id": 2,
            "name": "Johto"
        },
        {
            "id": 3,
            "name": "Hoenn"
        },
        {
            "id": 4,
            "name": "Sinnoh"
        },
        {
            "id": 5,
            "name": "Unova"
        },
        {
            "id": 6,
            "name": "Kalos"
        },
        {
            "id": 7,
            "name": "Alola"
        },
        {
            "id": 8,
            "name": "Galar"
        },
        {
            "id": 9,
            "name": "Paldea"
        }
    ],
    "errors": []
}
```

## Contribuições

Se você tiver alguma sugestão de melhoria, ideia nova ou perceber algo que pode ser ajustado, será muito bem-vinda. O objetivo aqui é aprender e evoluir, então toda contribuição faz diferença.

## Agradecimentos

A [PokéAPI](https://pokeapi.co/), pela inspiração e pelo excelente trabalho que tem feito na comunidade Pokémon.
