
// ----------------------------------------------------------
// Objetos de tradução de tela -> Ids e xpaths 
// ----------------------------------------------------------

export function searchPageObject() {
  return {
    txtCodigoProduto: '#txtCodigoProduto',
    txtFamiliaProduto: '#2',
    txtModelo: '#1',
    dropFabricante: '#3',
    dropLinha: '#4',
    xBtnSearch: '/html/body/app-root/main/app-search/app-search-form/form/div/div[2]/button',
    xTableResultsFirst: '/html/body/app-root/main/app-search/app-results-table/div/table/tbody/tr[1]/td[3]/div/div/p/span',
    xFailResults: '/html/body/app-root/main/app-search/app-researched/div/p',
    xBtnCompare: '/html/body/app-root/main/app-search/app-results-table/div/table/tbody/tr[1]/td[6]/button',
    xBtnNext: '/html/body/app-root/main/app-search/app-results-table/div/div/app-pagination/div/button[2]',
    xBtnAttach: '/html/body/app-root/main/app-search/app-search-form/form/div/div[1]/button',
    xBtnAttachDone: '/html/body/div[3]/div[2]/div/mat-dialog-container/app-upload-file-modal/div/div[2]/button[2]/span[1]/span',
  }
}
