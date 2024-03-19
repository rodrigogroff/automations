
// ----------------------------------------------------------
// arquivo de comandos básicos do cypress
// ----------------------------------------------------------

export function get(id) {
  cy.wait(500);
  return cy.get(id);
}

export function clear(id) {
  get(id).clear();
}

export function click(id) {
  get(id).click();
}

export function type(id, text, _clear, options) {
  if (_clear == true)
    clear(id)
  get(id).type(text, options);
}

export function typeSlow(id, text) {
  get(id).type(text, { delay: 200 });
}

export function typeSlowClear(id, text) {
  clear(id)
  get(id).type(text, { delay: 200 });
}

export function autocomplete(id, text) {
  get(id)
    .type(text, { delay: 150 })
    .wait(500)
    .type('{enter}');

  get(id).type('{enter}');

  cy.wait(500);
}

export function checkTable(id, values_check, indexes) {
  let values = []
  cy.get(id)
    .find('td')
    .each(($el, $index) => {
      cy.wrap($el)
        .invoke('text')
        .then(text => {
          for (let i = 0; i < indexes.length; i++) {
            if ($index == indexes[i]) {
              values.push(text.trim())
            }
          }
        })
    })
    .then(() => {
      expect(values).to.deep.eq(values_check)
    })
}

export function getValueFromTable(id, indexTo) {
  cy.get(id)
    .find('td')
    .each(($el, $index) => {
      cy.wrap($el)
        .invoke('text')
        .then(text => {
          if ($index == indexTo) {
            return text.trim()
          }
        })
    })
}

export function checkTextContains(id, text) {
  get(id).should('include.text', text)
}

export function checkTextValue(id, text) {
  get(id).should('have.value', text)
}

export function wait(ms) {
  cy.wait(ms);
}

export function baseUrl() {
  return Cypress.env('baseUrl_ABB')
}

export function selectOption(id, option_text) {
  get(id).select(option_text);
}

export function checkSelectOptionSelected(id, text) {
  get('select' + id + ' option:selected').should('have.text', text)
}

export function checkUrl(url) {
  cy.url().should('eq', url)
}

export function maxRetries() {
  return parseInt(Cypress.env('maxRetry'))
}

export function gerarCpf(mascara) {
  const num1 = aleatorio();
  const num2 = aleatorio();
  const num3 = aleatorio();
  const dig1 = dig(num1, num2, num3);
  const dig2 = dig(num1, num2, num3, dig1);

  if (mascara == true)
    return `${num1}.${num2}.${num3}-${dig1}${dig2}`;
  else
    return `${num1}${num2}${num3}${dig1}${dig2}`;
}

export function dig(n1, n2, n3, n4) {
  const nums = n1.split("").concat(n2.split(""), n3.split(""));
  if (n4 !== undefined) {
    nums[9] = n4;
  }

  let x = 0;
  for (let i = (n4 !== undefined ? 11 : 10), j = 0; i >= 2; i--, j++) {
    x += parseInt(nums[j]) * i;
  }

  const y = x % 11;
  return y < 2 ? 0 : 11 - y;
}

export function aleatorio() {
  const aleat = Math.floor(Math.random() * 999);
  return ("" + aleat).padStart(3, '0');
}

export function aleatorio(casasDecimais) {
  const aleat = Math.floor(Math.random() * 999);
  return ("" + aleat).padStart(casasDecimais, '0');
}

export function getRandomUserId() {
  return Math.floor(Math.random() * 4232242122)
}
