
describe('Test editar pedido faturado', () => {
  it('automação ', () => {

    /*
    Torna um pedido, através do PUT, como faturado
      cod3 nos itens torna os mesmos faturados
    */

    cy.writeFile('localStorage_get_after.txt', '')
    cy.writeFile('localStorage_get.txt', '')
    cy.writeFile('localStorage_put.txt', '')

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
        id: 4,
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
            id: 4,
            status_label: "Faturado",
            products: [
              {
                order_product_id: 14,
                product_id: 68,
                ean: "7898344184400",
                quantity: 1,
                product_status: "cod3",
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
                id: 4,
              }
            })
              .then((get_response) => {
                cy.writeFile('localStorage_get_after.txt', get_response.body)
                expect(get_response.body.order.products[2].status_product).to.eq('Faturado')
                expect(get_response.body.order.products[2].ean).to.eq('7898344184400')
                expect(get_response.body.order.products[2].order_product_id).to.eq('14')
              })
          })

      })
  })
})
