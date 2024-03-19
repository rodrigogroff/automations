
describe('Test listar status pedidos', () => {
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
    }).then((login_response) => {

      // ------------
      // PEDIDOS
      // ------------

      cy.request({
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + login_response.body.access_token
        },
        url: Cypress.env('baseUrl') + 'api/order/status',
      }).then((response) => {

        cy.writeFile("localStorage.txt", response.body);
        // verificar se temos resultados
        expect(response.body.length).to.eq(6)
      })
    })
  })
})
