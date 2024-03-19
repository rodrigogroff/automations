
import { searchPageObject } from '../pageObjects/_searchPage'
import { comparePageObject } from '../pageObjects/_comparePage'

export function validar(testData) {

  var po = searchPageObject()
  var poComp = comparePageObject();

  if (testData.testOK == true) {
    // verificar codigo direto no relatorio
    if (testData.codigoProduto) {
      cy.waitUntil(() => cy.xpath(po.xTableResultsFirst, { timeout: 10_000 }))
      cy.xpath(po.xTableResultsFirst).
        invoke('text').should('eq', ' ' + testData.codigoProduto + ' ')
    }
    // entrar na pagina de comparação
    cy.xpath(po.xBtnCompare).click();

    // aguardar carga    
    cy.waitUntil(() => cy.xpath(poComp.xLabelCodigo, { timeout: 10_000 }))

    if (testData.codigoProduto)
      cy.xpath(poComp.xLabelCodigo).invoke('text').should('eq', testData.codigoProduto)

    if (testData.modelo)
      cy.xpath(poComp.xLabelModelo).invoke('text').should('eq', testData.modelo)

    if (testData.familia)
      cy.xpath(poComp.xLabelFamilia).invoke('text').should('eq', testData.familia)

    if (testData.fabricante)
      cy.xpath(poComp.xLabelFabricante).invoke('text').should('eq', testData.fabricante)

    if (testData.linha)
      cy.xpath(poComp.xLabelLinha).invoke('text').should('eq', testData.linha)
  }
  else { // falha generica
    cy.waitUntil(() => cy.xpath(po.xFailResults, { timeout: 10_000 }))
    cy.xpath(po.xFailResults).invoke('text').
      should('eq', 'Produto não encontrado, tente refazer a pesquisa.')
  }
}
