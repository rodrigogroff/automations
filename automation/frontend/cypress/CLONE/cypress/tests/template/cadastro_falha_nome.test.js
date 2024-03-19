
import { cadastro } from '../lib/functions/cadastro'

describe('cadastro falha nome', () => {
  it('Automação', () => {

    Cypress.on('uncaught:exception', (err, runnable) => {
      return false
    })

    var testData = {
      testOK: false,
      fail_nome: true,
      nome: '',
    }

    var iterations =
      ['',
        'a',
        '1234567890123456789012345678901234567890123456789012345678901234567890'
      ]

    /*
    iterations.forEach(function (nome) {
      testData.nome = nome
      cadastro(testData)
    })
    */

    for (let i = 0; i < iterations.length; ++i) {
      testData.nome = iterations[i]
      cadastro(testData)
    }
  })
})
