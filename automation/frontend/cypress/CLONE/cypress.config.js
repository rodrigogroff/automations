const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 1380,
  viewportHeight: 1200,
  //video: false, 
  env: {
    baseUrl: 'https://www.ingresso.com/',
    maxRetry: '0',
  },
  e2e: {
    specPattern: [
      //'cypress/tests/template/login.test.js',
      // 'cypress/tests/template/cadastro_falha_nome.test.js',
      'cypress/tests/template/cadastro_falha_cpf.test.js',
    ]
  },
});
