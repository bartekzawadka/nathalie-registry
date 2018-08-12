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

@NgModule({
  declarations: [
    AppComponent,
    RegistriesComponent,
    TemplatesComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [RegistriesService, TemplatesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
