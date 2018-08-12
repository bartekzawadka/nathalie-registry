import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

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
}
