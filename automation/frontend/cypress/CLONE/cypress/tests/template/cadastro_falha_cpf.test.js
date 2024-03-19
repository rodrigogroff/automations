
import { cadastro } from '../lib/functions/cadastro'

describe('cadastro falha cpf', () => {
  it('Automação', () => {

    Cypress.on('uncaught:exception', (err, runnable) => {
      return false
    })

    var testData = {
      testOK: false,
      fail_cpf: true,
      cpf: '',
    }

    // vazio
    // mascara incompleta
    // letras
    // só numeros incompletos
    // espaços
    var iterations = ['', '123.456', 'aaaaaa', '1231231320', '    a123']

    for (let i = 0; i < iterations.length; ++i) {
      testData.cpf = iterations[i]
      cadastro(testData)
    }

  })
})

