
import {
  baseUrl,
  baseUrlTst,
  typeSlow,
  click,
} from '../../_cypress'

import { analiseDescontoPageObject } from '../../pageObjects/_analiseDesconto'

export function analiseDesconto(testData, ambiente) {

  cy.log(JSON.stringify(testData))
  cy.wait(1000)

  cy.readFile('localStorage.txt').then($locSto => {
    let po = analiseDescontoPageObject()

    cy.log($locSto)
    cy.wait(1000)

    cy.log($locSto.trim().substring(3))
    cy.wait(1000)

    testData.orcamento = $locSto.trim().substring(3);

    if (ambiente == 'tst')
      cy.visit(baseUrlTst() + 'specialdeal/pesquisar.aspx')
    else
      cy.visit(baseUrl() + 'specialdeal/pesquisar.aspx')

    cy.wait(1000)
    typeSlow(po.valorOrcamento, testData.orcamento)
    click(po.botaoPesquisar);
    cy.xpath(po.botaoOpcaoItemRelatorio).click();
    cy.xpath(po.botaoOpcaoAnalise).click();
    cy.xpath(po.tabAnalise).click();
    typeSlow(po.obs1, 'auto-obs1')
    typeSlow(po.obs2, 'auto-obs2')
    click(po.botaoAprovar);
    cy.wait(2000)
  });
}
