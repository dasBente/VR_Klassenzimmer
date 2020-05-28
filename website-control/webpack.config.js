const path = require('path')

module.exports = {
  entry: path.join(__dirname, 'src', 'index.js'),
  output: {
    path: path.join(__dirname, 'js/'),
    filename: 'bundle.js'
  },

  mode: 'development',

  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader'
        }
      }
    ]
  },

  resolve: {
    alias: {
      actions: path.resolve(__dirname, 'src', 'actions'),
      components: path.resolve(__dirname, 'src', 'components'),
      reducers: path.resolve(__dirname, 'src', 'reducers'),
      utilities: path.resolve(__dirname, 'src', 'utilities'),
      constants: path.resolve(__dirname, 'src', 'constants')
    },

    extensions: ['*', '.js', '.jsx']
  },

  devtool: 'inline-source-map',
  devServer: {
    contentBase: path.join(__dirname, '.')
  }
}
