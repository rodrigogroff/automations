
describe('Test login - get', () => {
  it('automação ', () => {
    cy.request({
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      },
      url: Cypress.env('baseUrl') + '/loyalty-system-api/v1/systems?clientId=' + Cypress.env('clientId'),
    }).then((response) => {
      cy.writeFile("localStorage.txt", response.body);
      cy.log('oi')
      cy.log('oi >' + response.body.id + '<')
      expect(response.body.id).to.eq('ADM03324774302G')
    })
  })
})
