
describe('Test obter pedido', () => {
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

      cy.writeFile("localStorage.txt", login_response);

      // ------------
      // OBTER PEDIDO
      // ------------

      cy.request({
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + login_response.body.access_token
        },
        url: Cypress.env('baseUrl') + 'api/order/614',
      }).then((response) => {

        cy.writeFile("localStorage.txt", response.body);
        // verificar se temos resultados
        expect(response.body.order_number).to.eq(1476)
        expect(response.body.status_code).to.eq('cod2')
      })
    })
  })
})
