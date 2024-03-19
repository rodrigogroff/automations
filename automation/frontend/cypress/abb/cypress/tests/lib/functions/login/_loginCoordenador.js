
import {
  baseUrl,
  baseUrlTst,
  type,
  userCoord,
  userCoordPass,
  click,
  wait,
  checkUrl,
} from '../../_cypress'

import { loginAdminPageObject } from '../../pageObjects/_login'

export function loginCoordenador(ambiente) {
  if (ambiente == 'tst')
    cy.visit(baseUrlTst() + 'Login.aspx')
  else
    cy.visit(baseUrl() + 'Login.aspx')
  let po = loginAdminPageObject();
  click(po.user)
  type(po.user, userCoord())
  click(po.password)
  type(po.password, userCoordPass())
  click(po.btnLogin);
  cy.waitUntil(() => cy.get('#LinkButton1').should('be.visible'), { timeout: 10_000 });
  if (ambiente == 'tst')
    checkUrl(baseUrlTst() + 'default.aspx')
  else
    checkUrl(baseUrl() + 'default.aspx')
}
