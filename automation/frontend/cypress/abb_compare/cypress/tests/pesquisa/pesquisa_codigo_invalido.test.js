
import { maxRetries } from '../lib/_cypress'
import { startPortal } from '../lib/functions/startPortal'
import { buscar } from '../lib/functions/buscar'
import { validar } from '../lib/functions/validar'

describe('pesquisa por codigo invalido', () => {
  it('automação ', { retries: { runMode: maxRetries(), openMode: 0 }, }, () => {

    var testData = {
      testOK: false,
      codigoProduto: 'N3004xxx',
      modelo: '',
      familia: '',
      fabricante: '',
      linha: ''
    }

    startPortal();
    buscar(testData)
    validar(testData)
  })
})
