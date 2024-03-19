
describe('Test editar pedido', () => {
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
        // EDITAR PEDIDO
        // ------------

        cy.request({
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + login_response.body.access_token
          },
          url: Cypress.env('baseUrl') + 'api/order/600',
          body: {
            status_code: 'cod3'
          }
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

            // verificar se temos resultados
            expect(response.body.order_number).to.eq(1463)
            expect(response.body.status_code).to.eq('cod3')

            // -----------
            // roll_back (edit)
            // -----------

            cy.request({
              method: 'PUT',
              headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + login_response.body.access_token
              },
              url: Cypress.env('baseUrl') + 'api/order/600',
              body: {
                status_code: 'cod2'
              }
            })

          })
        })
      })
  })
})
