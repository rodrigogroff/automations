
import {
  baseUrl,
  baseUrlTst,
  getX,
  autocomplete,
  autocompleteSlow,
  wait,
} from '../../_cypress'

import { novoOrcamentoPageObject } from '../../pageObjects/_novoOrcamento'
import { novoOrcamento_finaliza } from './_novoOrcamento_finaliza'

export function novoOrcamento_industrializado(ambiente, testData) {
  if (ambiente == 'tst')
    cy.visit(baseUrlTst() + 'orcamento/orcamento.aspx')
  else
    cy.visit(baseUrl() + 'orcamento/orcamento.aspx')
  let po = novoOrcamentoPageObject();
  cy.waitUntil(() => cy.xpath(po.labelOrcamento, { timeout: 40_000 }).should('be.visible'))
  cy.xpath(po.labelOrcamento).then($value => {
    var sp = $value.text().split("-");
    var orc_number = sp[1].toString() + sp[2].toString();
    cy.writeFile("localStorage.txt", orc_number);

    cy.log(testData.codCliente)
    //autocomplete(po.codigoCliente, testData.codCliente);
    cy.wait(500)
    autocompleteSlow(po.codigoCliente, testData.codCliente);
    novoOrcamento_finaliza(testData);
  });
}
