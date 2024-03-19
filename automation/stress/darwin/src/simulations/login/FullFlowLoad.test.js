
import { check, sleep } from 'k6';
import http from 'k6/http';

export let options = {
  stages: [
    { duration: '30s', target: 5 }, // simulate ramp-up
    { duration: '30s', target: 5 }, // stay at
    { duration: '30s', target: 0 }, // ramp-down
  ],
  // thresholds: {
  //   http_req_duration: ['p(100)<4000'], // 100% of requests must complete below 10 segundos
  // },
};

export default function () {

  //console.log('Hey');

  let userUrl = 'http://127.0.0.1:5000/'
  let random_user = http.post( userUrl + 'api/randomUser', { headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' }, })
  console.log(random_user);
  var userJson = random_user.json()
  console.log('USR ' + userJson.user + "/" + userJson.pass )
  sleep(30)

    /*
  let url = 'https://seller-hlg.portaldarwin.com.br/'

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
    console.log(response_login)
  }
  */
}
