
import { login, validarLogin } from '../lib/functions/login'

describe('Ingresso login', () => {
  it('should display an error message for an invalid login', () => {

    Cypress.on('uncaught:exception', (err, runnable) => {
      return false
    })

    var testData = {
      testOK: false,
      cpf_email: '',
      senha: ''
    }

    login(testData)
    validarLogin(testData);
  })
})
