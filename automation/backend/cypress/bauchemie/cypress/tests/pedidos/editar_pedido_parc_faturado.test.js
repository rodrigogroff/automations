
describe('Test editar pedido', () => {
  it('automação ', () => {

    /*
        Torna um pedido, através do PUT, como parcialmente faturado
          cod3 nos itens torna os mesmos faturados
          cod2 nos itens torna os mesmos parc-faturados
 
          é possivel deixar apenas 2 de 3 (na quantidade) como parc - faturado

          TESTE MANUAL - NÃO PODE ESTAR NA REGRESSION

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
        id: 5,
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
            id: 5,
            status_label: "Faturado",
            status_code: "cod3",
            danfe_xml: ' 1 2 3',
            message_reject: '',
            products: [
              {
                order_product_id: '27',
                ean: "7898344187869",
                quantity: 1,
                product_status: "cod2", // parc faturado
              },
            ]
          }
        })
          .then((put_response) => {
            cy.writeFile('localStorage_put.txt', put_response)

            /*
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
                id: 5,
              }
            })
              .then((get_response) => {
                cy.writeFile('localStorage_get_after.txt', get_response)
              })
              */
          })
      })
  })
})
