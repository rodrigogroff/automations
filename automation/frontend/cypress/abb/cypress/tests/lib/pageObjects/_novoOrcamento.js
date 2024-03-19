
// ----------------------------------------------------------
// Objetos de tradução de tela -> Ids e xpaths 
// ----------------------------------------------------------

export function novoOrcamentoPageObject() {
  return {
    labelOrcamento: '/html/body/form/div[3]/div[2]/div/div[1]/div/div/h4/label',
    codigoCliente: '#MainContent_txtCodigo',
    comboCondicaoPagto: '#MainContent_ddlCondicaoPagamento',
    comboUtilizacaoProduto: '#MainContent_ddlPesquisaProdutoUtilizacao',
    botaoNovo: '#MainContent_btNovo',
    headerProdutos: '#MainContent_upHeaderProdutos',
    codigoProduto: '#MainContent_txtPesquisaProdutoRef',
    valorDesconto: '#MainContent_txtPesquisaProdutoN3',
    valorQuantidade: '#MainContent_txtPesquisaProdutoQtd',
    lupaProduto: '#Span6',
    botaoIncluirProduto: '#btPesquisarProduto2',
    botaoSalvar: '#MainContent_btSalvar',
    botaoFinalizar: '#MainContent_btFinalizar',
    sessao1: '#secao1',
    sessao2: '#secao2',
    sessao3: '#secao3',
    comboTipoAnalise: '#MainContent_ddlTipoSpecialDeal',
    checkBoxProduto: '#MainContent_rptProduto_chkExcluir_0',
    comboAplicAlt: '#MainContent_dropAplicarAlteracao',
    valorDescAplicado: '#MainContent_txtAplicarValorN3',
    valorConsultorVendas: '#MainContent_txtParaConsultorVendas',
    valorAosCuidados: '#MainContent_txtAosCuidadosde'
  }
}
