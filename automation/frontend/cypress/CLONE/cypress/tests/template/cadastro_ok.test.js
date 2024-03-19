
import { cadastro } from '../lib/functions/cadastro'

describe('cadastro OK', () => {
  it('Automação', () => {

    Cypress.on('uncaught:exception', (err, runnable) => {
      return false
    })

    var testData = {
      testOK: true,
      nome: 'rodrigo groff',
      cpf: '90511603053',
    }

    cadastro(testData)
  })
})

