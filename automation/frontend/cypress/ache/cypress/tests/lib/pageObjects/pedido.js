
export function pageObjPedido() {
return {
    divLoadingHome: 'loading-alert',
    navPedidos: '#menu-92',
    navPedido: '#menu-213',



    //
    inputBuscaPDV: '#selecionar-loja',

    divLoading: '.loading-alert',
    divLoadingProdutos: '.loading-alert',
    divLoadingBusca: '.loading-alert',

    //divLoadingBusca: 'loading-alert hideSweetAlert',

    //Selecionar pedido
    pedidoPadrao: '.tipoPedido-descricao-padrao',
    pedidoRep: '.tipoPedido-descricao-rep',
    pedidoBonif: '.tipoPedido-descricao-bonificado',
    pedidoFlex: '[ng-show="exibirPedidoFlex"] > .tipoPedido-descricao',
    pedidoEspecial: '[ng-show="exibirPedidoEsp && exibirBotaoCarregarPedidoEsp"] > .tipoPedido-descricao',
    btnTabloide: '.tabloide-item',

    //Prazo Pagamento
    slcPrazoPagamento:  '#slcPrazoPagamento',
    slcPrazoPagamentoFlex:  'select[ng-model="prazoSelecionado"]',

    //Distribuidor
    //slcDistribuidor:  '#slcPrazoPagamento',
    slcDistribuidorFlex: 'select[ng-model="distribuidorSelecionado"]',
    iconSetaDuplaDireita: '.fa-angle-double-right',
    btnAvancarDistribuidor: '.btn-margin',

    //Aviso Mix Ideal
    btnCancelarMixIdeal: '.cancel',

    //Selecionar Produtos
    btnAvancarProduto: 'button[ng-click="avancar()"]',

    btnAvancarPedido: '.align-right > .btn-margin',

    btnConfirmarMsgDescMinimo: '.confirm',

    btnEnviarPedido: '[ng-show="!pedidoSalvo"] > .align-right > .col-md-12 > .form-group > .btn-margin',

     btnConfirmarMsgPedidoEnviado: '.confirm',

    //visualizae Espelhp
    btnVisualizarEspelho: '[ng-show="pedidoSalvo"] > .align-right > .col-md-12 > .form-group > .btn-margin',


  }
}