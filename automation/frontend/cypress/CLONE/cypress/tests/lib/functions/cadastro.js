
import { baseUrl, checkUrl } from '../_cypress'
import { cadastroPageObject } from '../pageObjects/cadastroPage'

export function cadastro(testData) {

  let po = cadastroPageObject();

  cy.visit(baseUrl())

  // area de visitantes
  cy.xpath('/html/body/header[1]/div[1]/div/div[2]/div[3]/a/span').click()
  cy.wait(500)
  // botão 'crie uma nova conta'
  cy.xpath('/html/body/header[1]/div[1]/div/div[2]/div[3]/div/div/div/div[1]/a').click()
  // verifica o redirecionamento
  checkUrl(baseUrl() + 'minha-conta/cadastro')

  // -----------------
  // NOME
  // -----------------

  if (testData.nome) {
    cy.xpath('/html/body/div[2]/div/form/div/div[1]/div[1]/div[1]/div/input').
      type(testData.nome).
      tab()
  }
  else {
    cy.xpath('/html/body/div[2]/div/form/div/div[1]/div[1]/div[1]/div/input').
      click().
      tab()
  }

  if (testData.fail_nome == true) {
    cy.xpath('/html/body/div[2]/div/form/div/div[1]/div[1]/div[2]/span').
      invoke('text').
      should('eq', 'O nome precisa ter entre 3 e 60 caracteres e não possuir caracteres especiais')
    return;
  }

  // -----------------
  // CPF
  // -----------------

  if (testData.cpf) {
    cy.xpath('/html/body/div[2]/div/form/div/div[1]/div[2]/div[1]/div/input').
      type(testData.cpf).
      tab()
  }
  else {
    cy.xpath('/html/body/div[2]/div/form/div/div[1]/div[2]/div[1]/div/input').
      click().
      tab()
  }

  if (testData.fail_cpf == true) {
    cy.xpath('/html/body/div[2]/div/form/div/div[1]/div[2]/div[2]/span').
      invoke('text').
      should('eq', 'É obrigatório preencher o CPF.')
    return;
  }
}
