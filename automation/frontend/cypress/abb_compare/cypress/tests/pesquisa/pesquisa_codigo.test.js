
import { maxRetries } from '../lib/_cypress'
import { startPortal } from '../lib/functions/startPortal'
import { buscar } from '../lib/functions/buscar'
import { validar } from '../lib/functions/validar'

describe('pesquisa por codigo', () => {
  it('automação ', { retries: { runMode: maxRetries(), openMode: 0 }, }, () => {

    var testData = {
      testOK: true,
      codigoProduto: 'N3004',
    }

    startPortal();
    buscar(testData)
    validar(testData)
  })
})
