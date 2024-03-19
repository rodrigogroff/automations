
import { mainPageObject } from '../lib/pageObjects/_mainPage'
import { baseUrl, maxRetries, typeSlowClear } from '../lib/_cypress'

describe('Test Case 1', () => {
  it('automação ', { retries: { runMode: maxRetries(), openMode: 0 }, }, () => {
    cy.visit(baseUrl())
    cy.wait(2000)
    var po = mainPageObject()
    typeSlowClear(po.TxtCPF, '90511603053')
    cy.wait(2000)
  })
})
