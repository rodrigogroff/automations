
import { baseUrl } from '../_cypress'
import { loginPageObject } from '../pageObjects/loginPage'

export function login(testData) {
  let po = loginPageObject();
  cy.visit(baseUrl() + 'minha-conta/login')
  if (testData.cpf_email)
    cy.xpath(po.xCpfEmail).type(testData.cpf_email)
  if (testData.senha)
    cy.xpath(po.xSenha).type(testData.senha)
  cy.xpath(po.xBtnEntrar).click()
}

export function validarLogin(testData) {
  let po = loginPageObject();
  if (testData.testOK == true) {

  }
  else {
    cy.waitUntil(() => cy.xpath(po.xMsgLoginInvalido, { timeout: 180_000 }))
    cy.waitUntil(() => cy.get('#id_state', { timeout: 180_000 }))

    cy.xpath(po.xMsgLoginInvalido).
      invoke('text').
      should('eq', 'Usuário ou senha inválidos.')
  }
}
