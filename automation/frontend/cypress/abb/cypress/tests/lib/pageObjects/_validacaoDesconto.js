
// ----------------------------------------------------------
// Objetos de tradução de tela -> Ids e xpaths 
// ----------------------------------------------------------

export function validacaoDescontoPageObject() {
  return {
    valorOrcamento: '#MainContent_txtOrcamento',
    botaoPesquisar: '#MainContent_LinkButton1',
    botaoItemOpcoes: '/html/body/form/div[3]/div[2]/div/div[5]/table/tbody/tr/td[14]/div/button',
    botaoItemVisualizar: '/html/body/form/div[3]/div[2]/div/div[5]/table/tbody/tr/td[14]/div/ul/li/a[1]',
    abaResumo: '#liResumo',
    abaValidacao: '#liValidacao',
    tabelaDescontos: '#tblValidarDescontos',
    valorTotal: '/html/body/form/div[3]/div[2]/div/div[5]/div/div[1]/table[1]/tbody/tr[14]/td[2]/span[3]',
    valorTotalDesc: '/html/body/form/div[3]/div[2]/div/div[5]/div/div[1]/table[1]/tbody/tr[15]/td[2]/span[3]',
    valorConsumo: '/html/body/form/div[3]/div[2]/div/div[5]/div/div[1]/table[1]/tbody/tr[20]/td[2]',
    txtObservacao: '#txtObservacao',
    txtObservacaoVendedor: '#txtObservacaoVendedor',
    btnAprovaValidacaoDesconto: '#btnAprovaValidacaoDesconto'
  }
}