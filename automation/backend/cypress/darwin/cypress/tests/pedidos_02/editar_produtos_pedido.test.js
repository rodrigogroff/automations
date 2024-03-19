
describe('Test editar produtos pedido', () => {
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

        // ------------
        // EDITAR PRODUTOS PEDIDO
        // ------------

        cy.request({
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + login_response.body.access_token
          },
          url: Cypress.env('baseUrl') + 'api/order/605/products',
          body:
            [
              {
                quote_product_id: '2202',
                status_code: 'cod6'
              },
              {
                quote_product_id: '2203',
                status_code: 'cod6'
              }
            ]
        }).then((response) => {

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
            url: Cypress.env('baseUrl') + 'api/order/600',
          }).then((response) => {

            cy.writeFile("localStorage.txt", response.body);



          })
        })
      })
  })
})
