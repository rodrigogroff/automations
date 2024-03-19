
const { defineConfig } = require("cypress");

module.exports = defineConfig({
  projectId: "kpnug3",
  numTestsKeptInMemory: 1,
  responsetimeout: 999999999,
  screenshotOnRunFailure: false,
  viewportWidth: 1380,
  viewportHeight: 720,
  video: false,
  env: {
    baseUrl: 'https://biolabecs.pharmalinkonline.com.br/',
    user: 'rep.ecs',
    pass: 'A123456@',
    maxRetry: '0',
  },
  e2e: {
    specPattern: [
      'cypress/tests/orcamento/1/template0.test.js',

    ]
  },
});
