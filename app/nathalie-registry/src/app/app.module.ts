import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {MaterialModule} from "./material/material.module";
import { RegistriesComponent } from './pages/registries/registries.component';
import {AppRoutingModule} from "./app-routing/app-routing.module";
import { TemplatesComponent } from './pages/templates/templates.component';
import {RegistriesService} from "./services/registries.service";
import {HttpClientModule} from "@angular/common/http";
import {TemplatesService} from "./services/templates.service";
import { TemplateComponent } from './pages/template/template.component';
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    RegistriesComponent,
    TemplatesComponent,
    TemplateComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [RegistriesService, TemplatesService],
  bootstrap: [AppComponent]
})
export class AppModule { }