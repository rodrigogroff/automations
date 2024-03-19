const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 800,
  viewportHeight: 600,
  env: {
    baseUrl: 'https://cpap-app.azurewebsites.net/initial',
    maxRetry: '0',
  },
  e2e: {
    specPattern: [
      // 'cypress/tests/pesquisa/inicio.test.js',
      'cypress/tests/pesquisa/inicio2.test.js',
    ]
  },
});
