
// ----------------------------------------------------------
// Objetos de tradução de tela -> Ids e xpaths 
// ----------------------------------------------------------

export function loginPageObject() {
  return {
    xCpfEmail: '/html/body/div[2]/div[3]/div[2]/section[1]/form/fieldset/div[1]/div/input',
    xSenha: '/html/body/div[2]/div[3]/div[2]/section[1]/form/fieldset/div[3]/div/input',
    xBtnEntrar: '/html/body/div[2]/div[3]/div[2]/section[1]/form/div[5]/button',
    xMsgLoginInvalido: '/html/body/div[2]/div[3]/div[2]/section[1]/form/div[4]/span',
  }
}
