

export function pageObjLogin() {
  return {
    username: '#login',
    password: '#senha',
    nobot: '.recaptcha-checkbox .goog-inline-block .recaptcha-checkbox-unchecked .rc-anchor-checkbox',
    submit: '.btn-custom-default',

    divLoadingLogin: '.loading-alert',

    //logout
    btnMinhaConta:'#simple-btn-keyboard-nav',
    btnSair: ':nth-child(5) > .corMenu',

  }
}