const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 800,
  viewportHeight: 600,
  env: {
    baseUrl_ABB: 'https://abb-qa.ecs.com.br/',
    baseUrl_ABB_Test: 'http://abb-tst.ecs.com.br/',
    userAdm_ABB: 'suporteentire@email.com.br',
    userAdmPassword_ABB: 'A123456',
    userCoord_ABB: 'coordenador@br.abb.com',
    userCoordPassword_ABB: 'A123456',
    userPMS_ABB: 'pms@br.abb.com',
    userPMSPassword_ABB: 'A123456',
    maxRetry: '3',
  },
  e2e: {
    specPattern: [
      'cypress/tests/orcamento/Test Case 105408 Validar preço líquido - Difal-Consumo-Acrescimo.test.js',
      'cypress/tests/orcamento/Test Case 105373 Validar preço líquido - Difal-Consumo-Decrescimo.test.js',
      'cypress/tests/orcamento/Test Case 105367 Validar preço líquido - Partilha-Consumo-Padrão.test.js',
      'cypress/tests/orcamento/Test Case 105361 Validar preço líquido - Comum-Indust-Padrão.test.js',
      'cypress/tests/orcamento/Test Case 105365 Validar preço líquido - Difal-Consumo-Padrão.test.js',
      'cypress/tests/orcamento/Test Case 105369 Validar preço líquido - Comum-Indust-Decrescimo.test.js',
      'cypress/tests/orcamento/Test Case 105369 Validar preço líquido - Comum-Indust-Acrescimo.test.js',
      'cypress/tests/orcamento/Test Case 105410 Validar preço líquido - Comum-Revenda-Padrão.test.js',
      'cypress/tests/orcamento/Test Case 105409 Validar preço líquido - Partilha-Consumo-Acrescimo.test.js',
      'cypress/tests/orcamento/Test Case 105374 Validar preço líquido - Partilha-Consumo-Decrescimo.test.js',
      'cypress/tests/orcamento/Test Case 105375 Validar preço líquido - Comum-Indust-Acrescimo.test.js',
    ]
  },
});
