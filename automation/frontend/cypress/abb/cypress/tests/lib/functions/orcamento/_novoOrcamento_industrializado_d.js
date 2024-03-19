
import {
  baseUrl,
  autocomplete,
  selectOption,
} from '../../_cypress'

import { novoOrcamentoPageObject } from '../../pageObjects/_novoOrcamento'
import { novoOrcamento_finaliza } from './_novoOrcamento_finaliza'

export function novoOrcamento_industrializado_d(ambiente, testData) {
  cy.visit(baseUrl() + 'orcamento/orcamento.aspx')
  let po = novoOrcamentoPageObject();
  cy.waitUntil(() => cy.xpath(po.labelOrcamento, { timeout: 10_000 }).should('be.visible'))
  cy.xpath(po.labelOrcamento).then($value => {
    var sp = $value.text().split("-");
    var orc_number = sp[1].toString() + sp[2].toString();
    cy.writeFile("localStorage.txt", orc_number);
    autocomplete(po.codigoCliente, testData.codCliente);
    selectOption(po.comboCondicaoPagto, testData.condicao);
    novoOrcamento_finaliza(testData);
  });
}
