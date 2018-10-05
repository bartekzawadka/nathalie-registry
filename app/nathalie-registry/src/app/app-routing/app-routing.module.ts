import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RegistriesComponent} from "../pages/registries/registries.component";
import {TemplatesComponent} from "../pages/templates/templates.component";
import {TemplateComponent} from "../pages/template/template.component";
import {RegistryComponent} from "../pages/registry/registry.component";
import {RegistryDataComponent} from "../pages/registry-data/registry-data.component";

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
    path: 'registry',
    component: RegistryComponent
  },
  {
    path: 'registry/:id',
    component: RegistryComponent
  },
  {
    path: 'registries/:registryId/entity/:templateName',
    component: RegistryDataComponent
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
