
import { get, selectOption } from '../_cypress'
import { searchPageObject } from '../pageObjects/_searchPage'

export function buscar(testData) {

  var po = searchPageObject()

  if (testData.codigoProduto) {
    get(po.txtCodigoProduto).type(testData.codigoProduto).tab();
  }

  if (testData.uploadFile) {
    cy.xpath(po.xBtnAttach).click()
    cy.get('[id="fileSelector"]').attachFile("busca.csv", { subjectType: 'drag-n-drop' });
    cy.xpath(po.xBtnAttachDone).click();
  }

  if (testData.modelo)
    get(po.txtModelo).type(testData.modelo)

  if (testData.familia)
    get(po.txtFamiliaProduto).type(testData.familia)

  if (testData.fabricante)
    selectOption(po.dropFabricante, testData.fabricante)

  if (testData.linha)
    selectOption(po.dropLinha, testData.linha)

  cy.xpath(po.xBtnSearch).click()
}

