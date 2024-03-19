
import {
  typeSlow,
  type,
  click,
  clear,
  wait,
  autocomplete,
  selectOption
} from '../../_cypress'

import { novoOrcamentoPageObject } from '../../pageObjects/_novoOrcamento'

export function novoOrcamento_finaliza(testData) {
  let po = novoOrcamentoPageObject();
  click(po.headerProdutos);
  if (testData.arrayProdutos) {
    for (let i = 0; i < testData.arrayProdutos.length; i++) {

      cy.get(po.codigoProduto).scrollIntoView()
      cy.wait(1000)

      clear(po.codigoProduto)
      clear('#MainContent_txtPesquisaProdutoDescricao')

      autocomplete(po.codigoProduto, testData.arrayProdutos[i]);

      cy.get('#MainContent_txtPesquisaProdutoDescricao')
        .invoke('val')
        .then(text => {

          cy.log('>' + text + '<')

          if (text == '') {
            // Não foi encontrado o produto
          }
          else {
            type(po.valorDesconto, testData.desconto)
            type(po.valorQuantidade, testData.quantidade)
            click(po.lupaProduto);
            click(po.botaoIncluirProduto);
          }
        })

      // type(po.valorDesconto, testData.desconto)
      // type(po.valorQuantidade, testData.quantidade)
      // click(po.lupaProduto);
      // click(po.botaoIncluirProduto);
    }
  }
  else {
    autocomplete(po.codigoProduto, testData.codProduto);
    wait(1000)
    typeSlow(po.valorDesconto, testData.desconto)
    typeSlow(po.valorQuantidade, testData.quantidade)
    click(po.lupaProduto);
    wait(1000)
    click(po.botaoIncluirProduto);
    wait(1000)
  }
  click(po.botaoSalvar);
  wait(2000)
  click(po.checkBoxProduto);
  selectOption(po.comboAplicAlt, "Desc. Adic.")
  typeSlow(po.valorDescAplicado, testData.desconto)
  click(po.botaoSalvar);
  wait(3000)
  click(po.sessao1);
  wait(1000)
  click(po.sessao2);
  selectOption(po.comboTipoAnalise, testData.tipoAnaliseDesconto)
  wait(1000)
  typeSlow(po.valorConsultorVendas, testData.parecerVendedor)
  click(po.sessao3);
  wait(1000)
  selectOption('#MainContent_ddlProbabilidade', '100%')
  wait(1000)
  typeSlow(po.valorAosCuidados, testData.aosCuidados)
  click(po.sessao3);
  wait(1000)
  click(po.botaoFinalizar)
  wait(3000)
}

export function novoOrcamento_finaliza_partilha(testData) {
  let po = novoOrcamentoPageObject();
  click(po.headerProdutos);
  wait(100)
  autocomplete(po.codigoProduto, testData.codProduto);
  wait(1000)
  typeSlow(po.valorDesconto, testData.desconto)
  typeSlow(po.valorQuantidade, testData.quantidade)
  click(po.lupaProduto);
  wait(1000)
  click(po.botaoIncluirProduto);
  wait(1000)
  click(po.botaoSalvar);
  wait(5000)
  click(po.sessao1);
  wait(1000)
  click(po.sessao2);
  selectOption(po.comboTipoAnalise, testData.tipoAnaliseDesconto)
  wait(1000)
  typeSlow(po.valorConsultorVendas, testData.parecerVendedor)
  wait(1000)
  click(po.sessao3);
  wait(1000)
  selectOption('#MainContent_ddlProbabilidade', '100%')
  wait(1000)
  typeSlow(po.valorAosCuidados, testData.aosCuidados)
  wait(1000)
  click(po.sessao3);
  wait(1000)
  click(po.botaoFinalizar)
  wait(7000)
}
