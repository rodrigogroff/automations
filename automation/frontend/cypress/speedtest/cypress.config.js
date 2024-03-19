const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportWidth: 800,
  viewportHeight: 600,
  video: true,
  env: {

  },
  e2e: {
    specPattern: [
      'cypress/tests/speedtest/benchmark.test.js',
    ]
  },
});


