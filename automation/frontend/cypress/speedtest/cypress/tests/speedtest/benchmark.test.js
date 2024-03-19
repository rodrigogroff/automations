
import { click, wait, } from './lib/_cypress'

describe('Verifica velocidade da internet', () => {
  it('x', () => {

    Cypress.on('uncaught:exception', (err, runnable) => {
      // returning false here prevents Cypress from
      // failing the test
      return false
    })

    cy.visit('https://www.speedtest.net/pt')
    click('#onetrust-accept-btn-handler');
    cy.xpath('/html/body/div[3]/div/div[3]/div/div/div/div[2]/div[3]/div[1]/a/span[4]').click();

    cy.waitUntil(() =>
      cy.xpath('/html/body/div[3]/div/div[3]/div/div/div/div[2]/div[3]/div[3]/div/div[3]/div/div/div[2]/div[4]/div/div/div[2]/div/div/h3',
        { timeout: 60_000 })
    )
    //Teste do Marco pra tentar usar um WAIT melhor.
    cy.get('.result-item-container-align-center > .result-item > .result-data > .result-data-large', { timeout: 120000 })
      .invoke('text')
      .then(parseFloat)
      .should('be.gte', 10.50)

    // cy.xpath('/html/body/div[3]/div/div[3]/div/div/div/div[2]/div[3]/div[3]/div/div[3]/div/div/div[2]/div[2]/div/span[2]/span').
    //   then($pingButton => {
    //     var ping = parseInt($pingButton.text())
    //     cy.wrap(ping).should('be.gt', 10);
    //   })
  })
})
