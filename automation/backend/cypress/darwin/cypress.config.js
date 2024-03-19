const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 800,
  viewportHeight: 600,
  env: {
    baseUrl: 'https://seller-hlg.portaldarwin.com.br/',
    email: '_agriconnection@gmail.com',
    password: 'admin@seller2021',
  },
  e2e: {
    specPattern: [
      'cypress/tests/pedidos/listar_status_produto_pedido.test.js',
      'cypress/tests/pedidos/listar_status_pedido.test.js',
      'cypress/tests/pedidos/editar_produtos_pedido.test.js',
      'cypress/tests/pedidos/obter_produtos_pedido.test.js',
      'cypress/tests/pedidos/listar_produtos_pedido.test.js',
      'cypress/tests/pedidos/editar_pedido.test.js',
      'cypress/tests/pedidos/obter_pedido.test.js',
      'cypress/tests/pedidos/listar_pedidos.test.js',
      'cypress/tests/pedidos_02/listar_status_produto_pedido.test.js',
      'cypress/tests/pedidos_02/listar_status_pedido.test.js',
      'cypress/tests/pedidos_02/editar_produtos_pedido.test.js',
      'cypress/tests/pedidos_02/obter_produtos_pedido.test.js',
      'cypress/tests/pedidos_02/listar_produtos_pedido.test.js',
      'cypress/tests/pedidos_02/editar_pedido.test.js',
      'cypress/tests/pedidos_02/obter_pedido.test.js',
      'cypress/tests/pedidos_02/listar_pedidos.test.js',
      'cypress/tests/template/login.test.js',
    ]
  },
});
