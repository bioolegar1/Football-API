# Manual Status Code

| Code | Status                | Method | Description                          |
|------|-----------------------|--------|--------------------------------------|
| 200  | OK                    | GET    | 🟢 Recurso encontrado                |
| 201  | Created               | POST   | 🟢 Recurso criado                    |
| 204  | No Content            | DELETE | 🟢 Recurso deletado                  |
| 400  | Bad Request           | -      | 🟠 Erro do cliente (Dados inválidos) |
| 404  | Not Found             | -      | 🟠 Recurso não encontrado            |
| 405  | Method Not Allowed    | -      | 🟠 Método não permitido              |
| 409  | Conflict              | -      | 🟠 Conflito                          |
| 500  | Internal Server Error | -      | 🔴 Erro interno do servidor          |