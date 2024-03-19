
describe('Test editar pedido faturado', () => {
  it('automação ', () => {

    /*
    Torna um pedido, através do PUT, como faturado
      cod3 nos itens torna os mesmos faturados

      teste enviando ean furado

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
                order_product_id: 1,
                product_id: 68,
                ean: "xxxxx",
                quantity: 1,
                product_status: "cod3",
              },
            ]
          }
        })
          .then((put_response) => {

            cy.writeFile('localStorage_put.txt', put_response.body)

          })
      })
  })
})
