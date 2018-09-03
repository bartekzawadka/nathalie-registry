import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RegistriesComponent} from "../pages/registries/registries.component";
import {TemplatesComponent} from "../pages/templates/templates.component";
import {TemplateComponent} from "../pages/template/template.component";

const appRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'registries'
  },
  {
    path: 'registries',
    component: RegistriesComponent
  },
  {
    path: 'templates',
    component: TemplatesComponent
  },
  {
    path: 'template',
    component: TemplateComponent
  },
  {
    path: 'template/:id',
    component: TemplateComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      {
        enableTracing: false, // <-- debugging purposes only
      }
    )
  ],
  exports: [
    RouterModule
  ],
  providers: []
})
export class AppRoutingModule { }
