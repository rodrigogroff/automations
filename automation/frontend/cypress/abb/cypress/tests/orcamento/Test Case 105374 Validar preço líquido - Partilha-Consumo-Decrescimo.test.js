import { loginAdmin } from '../lib/functions/login/_loginAdmin'
import { loginCoordenador } from '../lib/functions/login/_loginCoordenador'
import { loginPMS } from '../lib/functions/login/_loginPMS'
import { novoOrcamento_consumo_partilha_cond } from '../lib/functions/orcamento/_novoOrcamento_consumo'
import { analiseDesconto } from '../lib/functions/orcamento/_analiseDesconto'
import { validacaoDesconto } from '../lib/functions/orcamento/_validacaoDesconto'
import { maxRetries } from '../lib/_cypress'

describe('Test Case 105374: Validar preço líquido - Partilha/Consumo/Decrescimo', () => {
  it('automação ', { retries: { runMode: maxRetries(), openMode: 0 }, }, () => {
    var testData = {
      codCliente: '1016861',
      codProduto: 'PVCX4601',
      desconto: '15,00',
      quantidade: '1',
      tipoAnaliseDesconto: 'Outro Motivo',
      parecerVendedor: 'Texto de teste',
      aosCuidados: 'Automação',
      planilha: [
        '1.722,87', // PL2020(7%+9,5%+ñ linear) (liquido)
        '764,73',   // PREÇO SOLICITADO LIQUIDO
        '1.035,96'    // PREÇO SOLICITADO com ICMS PIS e COFINS
      ],
      faturamento: 'Direto',
      consumo: 'Partilha',
      condicao: '28D/42D/56D/72D/84D/102D',
      vlrTotal: '1.218,78',
      vlrDesc: '1.035,96'
    }
    //setup
    loginAdmin()
    novoOrcamento_consumo_partilha_cond(testData)
    loginCoordenador()
    analiseDesconto(testData)
    //check      
    loginPMS()
    validacaoDesconto(testData)
  })
})
