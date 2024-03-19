
import { baseUrl } from '../_cypress'

export function startPortal() {
  cy.visit(baseUrl() + 'search')
  cy.wait(1000)
  // atenção
  cy.xpath('/html/body/app-root/app-disclaimer-of-responsibility/mat-card/mat-card-actions/button').click();
  cy.wait(1000)
  // cookies
  cy.xpath('/html/body/app-root/app-cookies/div/footer/div/button[2]/span[1]').click();
  cy.wait(1000)
}
