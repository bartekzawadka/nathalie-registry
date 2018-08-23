import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {KeyValue} from "../models/key.value";
import {Template} from "../models/template";

@Injectable({
  providedIn: 'root'
})
export class TemplatesService {

  constructor(private http: HttpClient) { }

  getTemplates(){
    return new Promise<any>((resolve, reject) => {
      this.http.get(environment.apiEndpoint+"/templates").subscribe(resolve, reject);
    });
  }

  getTemplateFieldTypes(){
    return new Promise<Array<KeyValue<number>>>((resolve, reject) => {
      this.http.get<Array<KeyValue<number>>>(environment.apiEndpoint+"/templatefields/types").subscribe(resolve, reject);
    });
  }

  addTemplate(template: Template){
    return new Promise<any>((resolve, reject) => {
      this.http.post(environment.apiEndpoint+"/templates", template).subscribe(resolve, reject);
    })
  }
}
