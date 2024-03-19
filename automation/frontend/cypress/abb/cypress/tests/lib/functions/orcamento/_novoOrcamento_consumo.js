
import {
  baseUrl,
  wait,
  autocomplete,
  selectOption
} from '../../_cypress'

import { novoOrcamentoPageObject } from '../../pageObjects/_novoOrcamento'
import { novoOrcamento_finaliza, novoOrcamento_finaliza_partilha } from './_novoOrcamento_finaliza'

export function novoOrcamento_consumo(testData) {
  cy.visit(baseUrl() + 'orcamento/orcamento.aspx')
  let po = novoOrcamentoPageObject();
  cy.waitUntil(() => cy.xpath(po.labelOrcamento, { timeout: 10_000 }).should('be.visible'))
  cy.xpath(po.labelOrcamento).then($value => {
    var sp = $value.text().split("-");
    var orc_number = sp[1].toString() + sp[2].toString();
    cy.writeFile("localStorage.txt", orc_number);
    autocomplete(po.codigoCliente, testData.codCliente);
    selectOption(po.comboUtilizacaoProduto, "Consumo")
    novoOrcamento_finaliza(testData);
  });
}

export function novoOrcamento_consumo_opt(testData) {
  cy.visit(baseUrl() + 'orcamento/orcamento.aspx')
  let po = novoOrcamentoPageObject();
  cy.waitUntil(() => cy.xpath(po.labelOrcamento, { timeout: 10_000 }).should('be.visible'))
  cy.xpath(po.labelOrcamento).then($value => {
    var sp = $value.text().split("-");
    var orc_number = sp[1].toString() + sp[2].toString();
    cy.writeFile("localStorage.txt", orc_number);
    autocomplete(po.codigoCliente, testData.codCliente);
    selectOption(po.comboUtilizacaoProduto, "Consumo")
    selectOption(po.comboCondicaoPagto, testData.condicao);
    novoOrcamento_finaliza(testData);
  });
}

export function novoOrcamento_consumo_partilha(testData) {
  cy.visit(baseUrl() + 'orcamento/orcamento.aspx')
  let po = novoOrcamentoPageObject();
  cy.waitUntil(() => cy.xpath(po.labelOrcamento, { timeout: 10_000 }).should('be.visible'))
  cy.xpath(po.labelOrcamento).then($value => {
    var sp = $value.text().split("-");
    var orc_number = sp[1].toString() + sp[2].toString();
    cy.writeFile("localStorage.txt", orc_number);
    autocomplete(po.codigoCliente, testData.codCliente);
    selectOption(po.comboUtilizacaoProduto, "Consumo")
    novoOrcamento_finaliza_partilha(testData);
  });
}

export function novoOrcamento_consumo_partilha_cond(testData) {
  cy.visit(baseUrl() + 'orcamento/orcamento.aspx')
  let po = novoOrcamentoPageObject();
  cy.waitUntil(() => cy.xpath(po.labelOrcamento, { timeout: 10_000 }).should('be.visible'))
  cy.xpath(po.labelOrcamento).then($value => {
    var sp = $value.text().split("-");
    var orc_number = sp[1].toString() + sp[2].toString();
    cy.writeFile("localStorage.txt", orc_number);
    autocomplete(po.codigoCliente, testData.codCliente);
    selectOption(po.comboUtilizacaoProduto, "Consumo")
    selectOption(po.comboCondicaoPagto, testData.condicao);
    novoOrcamento_finaliza_partilha(testData);
  });
}
