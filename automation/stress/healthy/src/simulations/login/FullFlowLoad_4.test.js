//import { log } from 'console';
import {
    check
} from 'k6';
import http from 'k6/http';

export let options = {
    stages: [{
            duration: '30s',
            target: 1
        }, // simulate ramp-up
        {
            duration: '30s',
            target: 1
        }, // stay at
        {
            duration: '30s',
            target: 0
        }, // ramp-down
    ],
    // thresholds: {
    //   http_req_duration: ['p(100)<4000'], // 100% of requests must complete below 10 segundos
    // },
};

export default function() {

    //console.log('Hey');

    let url = 'https://idp-api-gtw.azure-api.net/pbm-api-pre/api'

    let response_1 =
        http.post(
            url + '/pbm/preview-sales-order',
            JSON.stringify({
                "Source": "DrugstoreDesk",
                "Shopper": {
                    "VirtualCardNumber": "63957313003795511",
                    "SocialNumber": "03145094378"
                },
                "NetworkInfo": {
                    "Name": null,
                    "FiscalNumber": "99999994002536"
                },
                "State": {
                    "Name": "CE",
                    "City": "FORTALEZA",
                    "District": "CENTRO"
                },
                "SalesOrderItems": [{
                    "EAN": "7891142203410",
                    "ProductQuantity": 1,
                    "MedicalPrescription": null
                }]
            }), {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
            })

    // created
    check(response_1, {
        'preview-sales-order': () => response_1.status == 200
    });

    if (response_1.status == 200) {
        let response_2 =
            http.post(
                url + '/pbm/pre-sales-order',
                JSON.stringify({
                    "Source": "DrugstoreDesk",
                    "Shopper": {
                        "VirtualCardNumber": "63957313003795511",
                        "SocialNumber": "03145094378"
                    },
                    "NetworkInfo": {
                        "Name": null,
                        "FiscalNumber": "99999994002536"
                    },
                    "State": {
                        "Name": "CE",
                        "City": "FORTALEZA",
                        "District": "CENTRO"
                    },
                    "SalesOrderItems": [{
                        "EAN": "7891142203410",
                        "ProductQuantity": 1,
                        "MedicalPrescription": null
                    }]
                }), {
                    headers: {
                        'Content-Type': 'application/json',
                        'Accept': 'application/json'
                    },
                })

        var nsu = response_2.json().UniqueSequentialNumber.Value

        console.log(nsu);

        check(response_2, {
            'pre-sales-order': () => response_2.status == 200
        });

        if (response_2.status == 200) {
            let response_3 =
                http.post(
                    url + '/pbm/sales-order',
                    JSON.stringify({
                        "SalesOrderItems": [{
                            "EAN": "7891142203410",
                            "ProductQuantity": 1,
                            "NetworkGrossPrice": 65.90,
                            "NetworkNetPrice": 52.00,
                            "MedicalPrescription": null
                        }],
                        "UniqueSequentialNumber": {
                            "Value": nsu
                        },
                        "NetworkInfo": {
                            "FiscalNumber": "99999994002536"
                        },
                        "TaxFiscalReceipt": {
                            "TaxNumber": "36598",
                            "TaxType": "NFC",
                            "AccessKey": "xxxx-xxxxx-xxxxx"
                        },
                        "source": "DrugstoreDesk",
                        "SalesDate": ""
                    }), {
                        headers: {
                            'Content-Type': 'application/json',
                            'Accept': 'application/json'
                        },
                    })

            check(response_3, {
                'sales-order': () => response_3.status == 200
            });

            if (response_3.status == 200) {
                let response_4 =
                    http.post(
                        url + '/pbm/sales-order/confirm',
                        JSON.stringify({
                            "UniqueSequentialNumber": {
                                "Value": nsu
                            },
                            "TaxFiscalReceipt": {
                                "TaxNumber": "36598",
                                "TaxType": "NFC",
                                "AccessKey": "xxxx-xxxxx-xxxxx"
                            }
                        }), {
                            headers: {
                                'Content-Type': 'application/json',
                                'Accept': 'application/json'
                            },
                        })
              check(response_4, {
                'sales-order-confirm': () => response_4.status == 200
              });
            }
        }
    }
}