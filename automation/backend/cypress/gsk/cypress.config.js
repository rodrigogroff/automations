const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 800,
  viewportHeight: 600,
  env: {
    baseUrl: 'https://aks-dev.interplayers.com.br',
    clientId: 'd2e16669-1f9a-4fe9-95e8-dd60116830d7',
  },
  e2e: {
    specPattern: [
      'cypress/tests/pedidos/login.test.js',
    ]
  },
});
