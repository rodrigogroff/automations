
import { loginAdmin } from '../lib/functions/login/_loginAdmin'
import { loginCoordenador } from '../lib/functions/login/_loginCoordenador'
import { loginPMS } from '../lib/functions/login/_loginPMS'
import { novoOrcamento_industrializado } from '../lib/functions/orcamento/_novoOrcamento_industrializado'
import { analiseDesconto } from '../lib/functions/orcamento/_analiseDesconto'
import { validacaoDesconto } from '../lib/functions/orcamento/_validacaoDesconto'
import { maxRetries } from '../lib/_cypress'

describe('MTO salvar aprovar', () => {
  it('automação ', { retries: { runMode: maxRetries(), openMode: 0 }, }, () => {
    var testData = {
      ambiente: 'tst',
      codCliente: '1018298',
      codProduto: 'PVCX460',
      desconto: '15,00',
      quantidade: '500',
      tipoAnaliseDesconto: 'Outro Motivo',
      parecerVendedor: 'Texto de teste',
      aosCuidados: 'Automação',
      planilha: [
        '1.722,87', // PL2020(7%+9,5%+ñ linear) (liquido)
        '732,22',   // PREÇO SOLICITADO LIQUIDO
        '840,47'    // PREÇO SOLICITADO com ICMS PIS e COFINS
      ],
      faturamento: 'Direto',
      flagMTO: true,
      consumo: 'Comum',
      vlrTotal: '988,79',
      vlrDesc: '840,47'
    }

    loginAdmin(testData.ambiente)
    novoOrcamento_industrializado(testData.ambiente, testData)
    loginCoordenador(testData.ambiente)
    analiseDesconto(testData.ambiente, testData)
    loginPMS(testData.ambiente)
    validacaoDesconto(testData.ambiente, testData)
  })
})
