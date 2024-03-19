
import {
  baseUrl,
  get,
  type,
  click,
  userAdm,
  userAdmPass,
  registerTime,
  prepareLocalStorage,
  selectOption
} from '../../_cypress'

import { pageObjLogin } from '../../pageObjects/login'
import { pageObjPedido } from '../../pageObjects/pedido'

export function parallel()
{
  Cypress.on('uncaught:exception', (err, runnable) => {
      return false;
  });

  Cypress.on('fail', (error, runnable) => {
    // Take a screenshot
    cy.screenshot();
    // Optionally, you can also log the error to the console
    console.error('Test failed:', error.message);
  });

  /*
  Cypress.on('after:run', (results) => {
    if (results && results.stats && results.stats.failures === 0) { } else
    {
      cy.writeFile('failed.txt', '*');
    }
  });
  */

  var logApi = 'http://127.0.0.1:5000/api/'

  cy.request(
    { timeout: 100000,
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      url: logApi + 'regId'
    })
    .then((put_response) =>
    {
      var random_id = put_response.body

      cy.request(
      { timeout: 100000,
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        url: logApi + 'randomUser'
      })
      .then((put_response_usr) =>
      {
        var testData = {
          pdv: '97.222.376/0001-82',
          tipoPagto: 'À Vista',
          ean: '7896241225530',
          qtd: put_response_usr.body.id
        };

        login(logApi, random_id);
        //setarPDV(testData);
        pedido(logApi, random_id, testData);
      })
    })
}

export function login(logApi, random_id) {

  var pagina = pageObjLogin();

  registerTime(logApi, random_id, "UI Visit");

  cy.visit(baseUrl(), {
    onBeforeLoad: (win) => {
      prepareLocalStorage(
        win,
        '_grecaptcha',
        'ca09ABAvrlTx-PMufmgsvM3_g3RwX7ANuy6tn4N2_ZEtgYNooRw6ZklPuLt1rEGh_wkd2VaknS0sKdP8qrpDMd3K6_pd5UWycW2NyewMIwsa')
    }
  })

  registerTime(logApi, random_id, "UI Visit");
  registerTime(logApi, random_id, "UI Login");
  type(pagina.username, userAdm());
  type(pagina.password, userAdmPass(), true, { log: false });
  get(pagina.submit).invoke('prop', 'disabled', false)
  registerTime(logApi, random_id, "Login API");
  get(pagina.submit).click();
  // verifica se a FAQ está disponível
  get('body > div.container > div > div:nth-child(2) > div:nth-child(2) > div > a');
  cy.url().should('be.equal', baseUrl() + '#/home');
  registerTime(logApi, random_id, "Login API");
  registerTime(logApi, random_id, "UI Login");
}

export function setarPDV (testData)
{
  cy.wait(500);
  cy.visit(baseUrl() + '#/distribuidorPreferencia');
  cy.wait(500);
  cy.xpath('/html/body/div[2]/div/div[2]/div[2]/div[1]/div/div/div/input').clear().type(testData.pdv);
  cy.wait(1500);
  click(`ul li:contains(${testData.pdv})`);
  cy.wait(500);

  cy.waitUntil(() =>
  cy.xpath("/html/body/div[2]/div/div[2]/div[2]/div[3]/div[2]/div/div[1]/span/i[2]"),
    {
      timeout: 20000,
      interval: 20000
    });

  cy.xpath('/html/body/div[2]/div/div[2]/div[2]/div[3]/div[2]/div/div[1]/span/i[2]').click();
  cy.wait(500);

  cy.waitUntil(() =>
  cy.xpath('/html/body/div[6]/div[7]/div/button'),
    {
      timeout: 20000,
      interval: 20000
    });

  cy.xpath('/html/body/div[6]/div[7]/div/button').click();

  cy.waitUntil(() =>
  cy.xpath('/html/body/div[2]/div/div[2]/div[2]/div[5]/div[5]/div/button[2]'),
    {
      timeout: 20000,
      interval: 20000
    });

  cy.xpath('/html/body/div[2]/div/div[2]/div[2]/div[5]/div[5]/div/button[2]').click();

  cy.waitUntil(() =>
  cy.xpath('/html/body/div[6]/div[7]/div/button'),
    {
      timeout: 20000,
      interval: 20000
    });

  cy.xpath('/html/body/div[6]/div[7]/div/button').click();
  cy.wait(500);
}

export function pedido(logApi, random_id, testData) {

  var pagina = pageObjPedido();

  /*
  ----------------------------------
  ESCOLHER PDV [tab 1]
  ----------------------------------
  */

  registerTime(logApi, random_id, "UI Pdv");
  cy.wait(500);
  cy.log('vai chamar a url')

  cy.visit(baseUrl() + '#/pedido?resetPedido=true');
  // auto-complete do PDV
  type(pagina.inputBuscaPDV, testData.pdv);
  registerTime(logApi, random_id, "Pdv API");
  // selecionar pdv (via click)
  click(`ul li:contains(${testData.pdv})`);

  get('body > div.container > div > div:nth-child(2) > div.internal-pages.ng-scope > form > div:nth-child(3) > div > div:nth-child(1) > div.tipoPedido-item.tipoPedido-descricao-rep');

  registerTime(logApi, random_id, "Pdv API");
  registerTime(logApi, random_id, "UI Pdv");

  /*
  ----------------------------------
  ESCOLHER DISTRIBUIDOR [tab 2]
  ----------------------------------
  */

  registerTime(logApi, random_id, "Params Loja API");
  // obter dados da loja, clicar para avançar
  click(pagina.pedidoRep);

  // aguardar mudar a tab
  get('body > div.container > div > div:nth-child(2) > div.internal-pages.ng-scope > pedido-header > div > div:nth-child(1) > div:nth-child(1)');
  registerTime(logApi, random_id, "Params Loja API");

  // a vista
  selectOption(pagina.slcPrazoPagamento, testData.tipoPagto)
  // escolher todos
  cy.xpath('/html/body/div[2]/div/div[2]/div[2]/div[2]/div[2]/div/div[2]/span/i[2]').
  should('be.visible', { timeout: 930000 }).
  click();

  /*
  ----------------------------------
  ESCOLHER PRODUTOS [tab 3]
  ----------------------------------
  */

  registerTime(logApi, random_id, "UI Produtos");
  registerTime(logApi, random_id, "Setup Produtos API");

  // avançar
  cy.xpath('/html/body/div[2]/div/div[2]/div[2]/div[3]/div/div/button[3]').
  should('be.visible', { timeout: 930000 }).
  click();

  // input do produto pronta
  get('body > div.container > div > div:nth-child(2) > div.internal-pages.pedido-item.ng-scope > div > div.row.top25.filtroCategoriaProduto.filtroCategoriaProdutoColor.ng-scope > div > ul > li:nth-child(1) > a');

  registerTime(logApi, random_id, "Setup Produtos API");

  var prod = testData.ean;

  type('body > div.container > div > div:nth-child(2) > div.internal-pages.pedido-item.ng-scope > div > div.filtro-produtos.row > div.col-md-5 > div > input', prod);

  var rnd = testData.qtd + '{enter}';

  // digitar quantidade rnd
  cy.get('body > div.container > div > div:nth-child(2) > div.internal-pages.pedido-item.ng-scope > div > div:nth-child(4) > div.col-md-10.ng-scope > div > table > tbody > tr > td:nth-child(6) > div > div > input',
   { timeout: 930000 }).
   eq(0).
   type(rnd);

  registerTime(logApi, random_id, "UI Produtos");

  /*
  ----------------------------------
  GERAR PEDIDO [tab 4]
  ----------------------------------
  */

  registerTime(logApi, random_id, "UI Gerar Pedido");
  registerTime(logApi, random_id, "Gerar Pedido API");
  // avançar
  cy.xpath('/html/body/div[2]/div/div[2]/div[4]/div/div[2]/div[4]/div/button[2]')
  .should('be.visible', { timeout: 930000 })
  .click();
  // enviar
  get('body > div.container > div > div:nth-child(2) > div.internal-pages.pedido-item.ng-scope > div:nth-child(5) > div.row.align-right > div > div > button.btn-custom-default.btn-margin').click();
  // aviso
  get('body > div.sweet-alert.showSweetAlert.visible > h2');

  get("body > div.sweet-alert.showSweetAlert.visible > p").invoke('text').then(text => {
    cy.writeFile("pedido" + text+ ".txt", text + '\n', { flag: 'a+' });
  });

  registerTime(logApi, random_id, "Gerar Pedido API");
  registerTime(logApi, random_id, "UI Gerar Pedido");
}
