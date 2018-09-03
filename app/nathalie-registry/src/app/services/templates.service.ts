import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {KeyValue} from "../models/key.value";
import {Template} from "../models/template";
import {TemplateField} from "../models/template.field";

@Injectable({
  providedIn: 'root'
})
export class TemplatesService {

  constructor(private http: HttpClient) {
  }

  getTemplates() {
    return new Promise<any>((resolve, reject) => {
      this.http.get(environment.apiEndpoint + "/templates").subscribe(resolve, reject);
    });
  }

  getTemplate(id: number) {
    return new Promise<Template>((resolve, reject) => {
      this.http.get<Template>(environment.apiEndpoint + "/templates/" + id).subscribe(data => {
        resolve(data);
      }, reject);
    })
  }

  getTemplateFieldTypes() {
    return new Promise<Array<KeyValue<number>>>((resolve, reject) => {
      this.http.get<Array<KeyValue<number>>>(environment.apiEndpoint + "/templatefields/types").subscribe(resolve, reject);
    });
  }

  upsertTemplate(template: Template) {
    return new Promise<any>((resolve, reject) => {
      if (!template.id) {
        this.http.post(environment.apiEndpoint + "/templates", template).subscribe(resolve, reject);
      } else {
        this.http.put(environment.apiEndpoint + "/templates/" + template.id, template).subscribe(resolve, reject);
      }
    });
  }

  deleteTemplate(id: string) {
    return new Promise((resolve, reject) => {
      this.http.delete(environment.apiEndpoint + "/templates/" + id).subscribe(resolve, reject);
    })
  }

  isFormulaValid(formula: string, fieldNames: Array<TemplateField>, isCalculated: boolean) {
    return new Promise<boolean>((resolve, reject) => {
      let data = {
        formula: formula,
        isCalculated: isCalculated,
        fieldNameCollection: fieldNames
      };
      this.http.post(environment.apiEndpoint + "/templatefields/isFieldFormulaValid", data).subscribe(resolve, reject);
    })
  }
}
