<h1 align="center">MarombaStore</h1>

<p>
    Projeto de um e-commerce de suplementos alimentares, usando .NET 8.0.
    Neste projeto iremos colocar em prática algumas das boas práticas de desenvolvimento de software, como:
</p>

- Clean Architecture
- Clean Code
- SOLID
- DDD
- TDD

<h2>Fluxo do projeto (em estudo)</h2>

1. Pedido verifica estoque
2. Estoque devolve uma resposta para pedido informando se ha o produto
3. Pedido eh criado
4. Pagamento recebe as informacoes do pedido
5. Pagamento realizado
6. Estoque recebe um evento para retirar -1 produto do estoque /
    mudar status do pedido para realizado /
    envio eh iniciado
7. Pedido entregue