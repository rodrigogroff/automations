(()=>{"use strict";var e={n:t=>{var r=t&&t.__esModule?()=>t.default:()=>t;return e.d(r,{a:r}),r},d:(t,r)=>{for(var a in r)e.o(r,a)&&!e.o(t,a)&&Object.defineProperty(t,a,{enumerable:!0,get:r[a]})},o:(e,t)=>Object.prototype.hasOwnProperty.call(e,t),r:e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})}},t={};e.r(t),e.d(t,{default:()=>i,options:()=>s});const r=require("k6"),a=require("k6/http");var o=e.n(a),s={stages:[{duration:"30s",target:1},{duration:"30s",target:1},{duration:"30s",target:0}]};function i(){var e="https://idp-api-gtw.azure-api.net/pbm-api-pre/api",t=o().post(e+"/pbm/preview-sales-order",JSON.stringify({Source:"DrugstoreDesk",Shopper:{VirtualCardNumber:"63957313003795511",SocialNumber:"03145094378"},NetworkInfo:{Name:null,FiscalNumber:"99999994002536"},State:{Name:"CE",City:"FORTALEZA",District:"CENTRO"},SalesOrderItems:[{EAN:"7891142203410",ProductQuantity:1,MedicalPrescription:null}]}),{headers:{"Content-Type":"application/json",Accept:"application/json"}});if((0,r.check)(t,{"preview-sales-order":function(){return 200==t.status}}),200==t.status){var a=o().post(e+"/pbm/pre-sales-order",JSON.stringify({Source:"DrugstoreDesk",Shopper:{VirtualCardNumber:"63957313003795511",SocialNumber:"03145094378"},NetworkInfo:{Name:null,FiscalNumber:"99999994002536"},State:{Name:"CE",City:"FORTALEZA",District:"CENTRO"},SalesOrderItems:[{EAN:"7891142203410",ProductQuantity:1,MedicalPrescription:null}]}),{headers:{"Content-Type":"application/json",Accept:"application/json"}}),s=a.json().UniqueSequentialNumber.Value;if(console.log(s),(0,r.check)(a,{"pre-sales-order":function(){return 200==a.status}}),200==a.status){var i=o().post(e+"/pbm/sales-order",JSON.stringify({SalesOrderItems:[{EAN:"7891142203410",ProductQuantity:1,NetworkGrossPrice:65.9,NetworkNetPrice:52,MedicalPrescription:null}],UniqueSequentialNumber:{Value:s},NetworkInfo:{FiscalNumber:"99999994002536"},TaxFiscalReceipt:{TaxNumber:"36598",TaxType:"NFC",AccessKey:"xxxx-xxxxx-xxxxx"},source:"DrugstoreDesk",SalesDate:""}),{headers:{"Content-Type":"application/json",Accept:"application/json"}});if((0,r.check)(i,{"sales-order":function(){return 200==i.status}}),200==i.status){var n=o().post(e+"/pbm/sales-order/confirm",JSON.stringify({UniqueSequentialNumber:{Value:s},TaxFiscalReceipt:{TaxNumber:"36598",TaxType:"NFC",AccessKey:"xxxx-xxxxx-xxxxx"}}),{headers:{"Content-Type":"application/json",Accept:"application/json"}});(0,r.check)(n,{"sales-order-confirm":function(){return 200==n.status}})}}}}var n=exports;for(var u in t)n[u]=t[u];t.__esModule&&Object.defineProperty(n,"__esModule",{value:!0})})();
//# sourceMappingURL=FullFlowLoad.test.js.map