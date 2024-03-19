
const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 1380,
  viewportHeight: 1200,
  video: true,
  env: {
    baseUrl_ABB: 'https://app-hlg.abbcompare.com/',
    maxRetry: '0',
  },
  e2e: {
    specPattern: [
      'cypress/tests/pesquisa/pesquisa_codigo_upload.test.js',
      // 'cypress/tests/pesquisa/pesquisa_codigo.test.js',
      // 'cypress/tests/pesquisa/pesquisa_codigo_modelo.test.js',
      // 'cypress/tests/pesquisa/pesquisa_codigo_modelo_familia.test.js',
      // 'cypress/tests/pesquisa/pesquisa_codigo_modelo_familia_fab.test.js',
      // 'cypress/tests/pesquisa/pesquisa_codigo_modelo_familia_fab_linha.test.js',
      // 'cypress/tests/pesquisa/pesquisa_codigo_invalido.test.js',
    ]
  },
});
