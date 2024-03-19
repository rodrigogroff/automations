
describe('Teste obter produtos pedido', () => {
  it('automação ', () => {

    // ------------
    // LOGIN
    // ------------

    cy.request({
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      },
      url: Cypress.env('baseUrl') + 'api/token',
      body: {
        email: Cypress.env('email'),
        password: Cypress.env('password'),
      }
    })
      .then((login_response) => {

        // ------------------------
        // OBTER PRODUTOS PEDIDO
        // ------------------------

        cy.request({
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + login_response.body.access_token
          },
          url: Cypress.env('baseUrl') + 'api/order/600/products/2182',
        }).then((response) => {

          cy.writeFile("localStorage.txt", response.body);
          // verificar se temos resultados
          expect(response.body.name).to.eq('PIRIPROXIFEM 100 EC GL4x5L')
        })
      })

  })
})
