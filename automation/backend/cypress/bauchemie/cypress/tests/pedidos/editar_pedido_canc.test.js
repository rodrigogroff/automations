
describe('Test editar pedido', () => {
  it('automação ', () => {

    /*
        Torna um pedido, através do PUT, como faturado
          cod4 nos itens torna os mesmos cancelados
        */

    cy.request({
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'user': 'admin',
        'pass': 'password'
      },
      url: Cypress.env('baseUrl') + 'api/integration/getOrder',
      body: {
        id: 6,
      }
    })
      .then((get_response) => {
        cy.writeFile('localStorage_get.txt', get_response.body)

        cy.request({
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'user': 'admin',
            'pass': 'password'
          },
          url: Cypress.env('baseUrl') + 'api/integration/updateOrder',
          body: {
            id: 6,
            status_label: "Cancelado",
            message_reject: 'Testes auto',
            products: [
              {
                order_product_id: '17',
                product_id: '55',
                ean: "17898594674963",
                quantity: 5,
                product_status: "cod4",
              },
            ]
          }
        })
          .then((put_response) => {
            cy.writeFile('localStorage_put.txt', put_response.body)

            cy.request({
              method: 'GET',
              headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'user': 'admin',
                'pass': 'password'
              },
              url: Cypress.env('baseUrl') + 'api/integration/getOrder',
              body: {
                id: 6,
              }
            })
              .then((get_response) => {
                cy.writeFile('localStorage_get_after.txt', get_response.body)

                expect(get_response.body.order.products[0].status_product).to.eq('Cancelado')

              })
          })
      })
  })
})
