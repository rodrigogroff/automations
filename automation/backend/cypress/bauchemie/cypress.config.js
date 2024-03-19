const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 800,
  viewportHeight: 600,
  env: {
    baseUrl: 'https://mcbauchemie-dev.ecs.com.br/index.php?route=',
    user: 'admin',
    password: 'password',
  },
  e2e: {
    specPattern: [
      // 'cypress/tests/pedidos/editar_pedido_canc.test.js',
      // 'cypress/tests/pedidos/editar_pedido_parc_faturado.test.js', // teste manual!
      // 'cypress/tests/pedidos/editar_pedido_faturado.test.js',
      'cypress/tests/pedidos/editar_pedido_faturado_sujo.test.js',
      // 'cypress/tests/pedidos/danfe.test.js',
    ]
  },
});
