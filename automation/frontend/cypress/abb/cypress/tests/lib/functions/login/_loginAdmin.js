
import {
  baseUrl,
  baseUrlTst,
  type,
  userAdm,
  userAdmPass,
  click,
  wait,
  checkUrl,
} from '../../_cypress'

import { loginAdminPageObject } from '../../pageObjects/_login'

export function loginAdmin(ambiente) {
  if (ambiente == 'tst')
    cy.visit(baseUrlTst() + 'Login.aspx')
  else
    cy.visit(baseUrl() + 'Login.aspx')
  let po = loginAdminPageObject();
  click(po.user)
  type(po.user, userAdm())
  click(po.password)
  type(po.password, userAdmPass())
  click(po.btnLogin);
  cy.waitUntil(() => cy.get('#LinkButton1').should('be.visible'), { timeout: 10_000 });
  if (ambiente == 'tst')
    checkUrl(baseUrlTst() + 'default.aspx')
  else
    checkUrl(baseUrl() + 'default.aspx')
}
