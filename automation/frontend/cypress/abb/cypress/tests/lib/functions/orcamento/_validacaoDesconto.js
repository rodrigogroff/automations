
import {
  baseUrl,
  baseUrlTst,
  typeSlowClear,
  click,
  checkTable,
} from '../../_cypress'

import { validacaoDescontoPageObject } from '../../pageObjects/_validacaoDesconto'

export function validacaoDesconto(testData, ambiente) {

  if (ambiente == 'tst')
    cy.visit(baseUrlTst() + 'validacaodesconto/pesquisar.aspx')
  else
    cy.visit(baseUrl() + 'validacaodesconto/pesquisar.aspx')

  cy.readFile('localStorage.txt').then($value => {
    testData.orcamento = $value.trim().substring(3);
    let po = validacaoDescontoPageObject()
    //  typeSlowClear(po.valorOrcamento, testData.orcamento)
    click(po.botaoPesquisar);
    cy.get('#DataTables_Table_0 > tbody > tr > td:nth-child(14) > div > button').click();
    cy.get('#DataTables_Table_0 > tbody > tr > td:nth-child(14) > div > ul > li > a:nth-child(1)').click();
    click(po.abaResumo);
    cy.scrollTo(0, 500)
    click(po.abaValidacao);
    checkTable(po.tabelaDescontos, testData.planilha, [8, 9, 10]);
    click(po.abaResumo);
    cy.scrollTo(0, 500)
    cy.xpath(po.valorTotal).should('include.text', testData.vlrTotal)
    cy.xpath(po.valorTotalDesc).should('include.text', testData.vlrDesc)
    cy.xpath(po.valorConsumo).should('include.text', testData.consumo)
    click(po.abaValidacao);
    typeSlowClear(po.txtObservacao, 'a')
    typeSlowClear(po.txtObservacaoVendedor, 'b')
    click(po.btnAprovaValidacaoDesconto)
  });
}
