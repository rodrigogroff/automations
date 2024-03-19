
import {
  baseUrl,
  baseUrlTst,
  type,
  userPMS,
  userPMSPass,
  click,
  wait,
  checkUrl,
} from '../../_cypress'

import { loginAdminPageObject } from '../../pageObjects/_login'

export function loginPMS(ambiente) {
  if (ambiente == 'tst')
    cy.visit(baseUrlTst() + 'Login.aspx')
  else
    cy.visit(baseUrl() + 'Login.aspx')
  let po = loginAdminPageObject();
  click(po.user)
  type(po.user, userPMS())
  click(po.password)
  type(po.password, userPMSPass())
  click(po.btnLogin);
  cy.waitUntil(() => cy.get('#LinkButton1').should('be.visible'), { timeout: 10_000 });
  if (ambiente == 'tst')
    checkUrl(baseUrlTst() + 'default.aspx')
  else
    checkUrl(baseUrl() + 'default.aspx')
}
