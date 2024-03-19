
describe('Test login - get token', () => {
  it('automação ', () => {
    var login_testData = {
      email: Cypress.env('email'),
      password: Cypress.env('password'),
    }
    cy.request({
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      },
      url: Cypress.env('baseUrl') + 'api/token',
      body: login_testData
    }).then((response) => {
      cy.writeFile("localStorage.txt", response.body.access_token);
      cy.wait(5000)
    })
  })
})
