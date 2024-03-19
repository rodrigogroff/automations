import { loginAdmin } from '../lib/functions/login/_loginAdmin'
import { loginCoordenador } from '../lib/functions/login/_loginCoordenador'
import { loginPMS } from '../lib/functions/login/_loginPMS'
import { novoOrcamento_revenda } from '../lib/functions/orcamento/_novoOrcamento_revenda'
import { analiseDesconto } from '../lib/functions/orcamento/_analiseDesconto'
import { validacaoDesconto } from '../lib/functions/orcamento/_validacaoDesconto'
import { maxRetries } from '../lib/_cypress'

describe('Test Case 105410: Validar preço líquido - Comum/Revenda/Padrão', () => {
  it('automação ', { retries: { runMode: maxRetries(), openMode: 0 }, }, () => {
    var testData = {
      codCliente: '1018298',
      codProduto: 'PVCX4601',
      desconto: '15,00',
      quantidade: '1',
      tipoAnaliseDesconto: 'Outro Motivo',
      parecerVendedor: 'Texto de teste',
      aosCuidados: 'Automação',
      planilha: [
        '1.722,87', // PL2020(7%+9,5%+ñ linear) (liquido)
        '732,22',   // PREÇO SOLICITADO LIQUIDO
        '840,47'    // PREÇO SOLICITADO com ICMS PIS e COFINS
      ],
      faturamento: 'Direto',
      consumo: 'Comum',
      vlrTotal: '988,79',
      vlrDesc: '840,47'
    }
    //setup
    loginAdmin()
    novoOrcamento_revenda(testData)
    loginCoordenador()
    analiseDesconto(testData)
    //check      
    loginPMS()
    validacaoDesconto(testData)
  })
})
