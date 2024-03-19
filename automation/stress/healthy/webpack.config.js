module.exports = {
  mode: 'production',
  entry: {
    FullFlowLoad_1: './src/simulations/login/FullFlowLoad_1.test.js',
    FullFlowLoad_2: './src/simulations/login/FullFlowLoad_2.test.js',
    FullFlowLoad_3: './src/simulations/login/FullFlowLoad_3.test.js',
    FullFlowLoad_4: './src/simulations/login/FullFlowLoad_4.test.js'
  },
  output: {
    path: __dirname + '/dist',
    filename: '[name].test.js',
    libraryTarget: 'commonjs'
  },
  module: {
    rules: [
      { test: /\.js$/, use: 'babel-loader' },
    ]
  },
  stats: {
    colors: true,
    warnings: false
  },
  target: "web",
  externals: /k6(\/.*)?/,
  devtool: 'source-map',
}