const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 800,
  viewportHeight: 600,
  env: {
    baseUrl: 'https://sample.com',
    user: 'admin',
    password: 'password',
  },
  e2e: {
    specPattern: [
      'cypress/tests/template/template.test.js',
    ]
  },
});
