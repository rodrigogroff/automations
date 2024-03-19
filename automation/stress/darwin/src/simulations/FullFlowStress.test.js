
import { group } from 'k6';

export let options = {
  stages: [
    { duration: '30s', target: 1 },
    { duration: '30s', target: 1 },
    { duration: '30s', target: 0 },
  ],
  // thresholds: {
  //   http_req_duration: ['p(99)<1500'], // 99% of requests must complete below 1.5s
  // },
};

export default function () {

  let url = 'https://seller-hlg.portaldarwin.com.br/'
  let userUrl = 'http://127.0.0.1:5000/'

  let random_user =
    http.post(
      userUrl + 'api/randomUser',
      JSON.stringify({ }), {
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      },
    })

    var userJson = random_user.json()

    console.log('USR ' + userJson.user + "/" + userJson.password ) //401 unauthorized

  let response_login =
    http.post(
      url + 'api/token',
      JSON.stringify({
        email: '_agriconnection@gmail.com',
        password: 'admin@seller2021'
      }), {
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      },
    })

  // created
  check(response_login, { 'login status 201': () => response_login.status == 201 });

  if (response_login.status == 201) {

    var token = response_login.json().access_token

    if (token) {

      let response_get = http.get(url + 'api/order/614', {
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + token
        }
      })

      // ok
      check(response_get, { 'get order 614 status 200': () => response_get.status == 200 });

      if (response_get.status != 200) {
        console.log('GET ' + response_get.status) //401 unauthorized
      }
    }
  }
  else {
    console.log('LOGIN ' + response_login.status)
  }

}