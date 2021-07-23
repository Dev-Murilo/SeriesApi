# SeriesApi​ :cinema: #  

***SeriesApi*** é uma api simples para guardar e consumir informações sobre séries utilizando C# e MongoDB. 

* **GET**: StatusCode - 200

  Rota: https://localhost:<*Porta*>/Series

  ## Retorno ## 

  ```json
  {
      "id": "Object.Id",
      "genero":"string",
      "titulo":"string",
      "descricao":"string",
      "anoLancamento": "int",
      "autor":"string"
  }
  ```

  

* **POST**: StatusCode - 201

  Rota: https://localhost:<*Porta*>/Series/Insert

* **PUT**: StatusCode - 202

  Rota: https://localhost:<*Porta*>/Series/Update/Id

* **DELETE**: StatusCode - 202

  Rota: https://localhost:<*Porta*>/Series/Delete/Id

## Retorno ## 

```json
{
    "id": "Object.Id",
    "Gênero":"string",
    "Título":"string",
    "Descrição":"string",
    "Ano de lançamento": "int",
    "Autor":"string"
}
```



Detalhe que a somente o metodo **GET** da *Api* possui um retorno mais "cru" do modelo de dados



